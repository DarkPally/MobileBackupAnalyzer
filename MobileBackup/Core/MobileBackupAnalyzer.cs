using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using MobileBackup.Configs;

using System.IO;
using System.Xml.Serialization;

namespace MobileBackup
{
    public class MobileBackupAnalyzer
    {
        //
        Task mTask;
        CancellationTokenSource tokenSource;
        CancellationToken token;
        public string SourcePath { get; set; }
        public string DestinationPath { get; set; }
        public TaskStateChangedEventHandler OnTaskStateChanged { get; set; }
        protected void onTaskStateChanged(object sender, TaskStateChangedEventArgs e)
        {
            if (OnTaskStateChanged != null)
            {
                OnTaskStateChanged(sender, e);
            }
        }

        DataCollectConfig config;
        public List<ConfigeAppOption> AppOptions { get; set; }
        public List<ConfigOptionBase> CollectOptions { get; set; }
        public MobileBackupAnalyzer(string config_path)
        {
            FileStream fs = new FileStream(config_path, FileMode.Open);
            var xml = new XmlSerializer(typeof(DataCollectConfig));
            DataCollectConfig myConfig = (DataCollectConfig)xml.Deserialize(fs);
            config = myConfig;
            fs.Close();

            AppOptions = new List<ConfigeAppOption>();
            AppOptions.AddRange(myConfig.BLOGOptions);
            AppOptions.AddRange(myConfig.BrowserOptions);
            AppOptions.AddRange(myConfig.CloudOptions);
            AppOptions.AddRange(myConfig.MailOptions);
            AppOptions.AddRange(myConfig.LocationOptions);
            AppOptions.AddRange(myConfig.IMOptions);
            AppOptions.AddRange(myConfig.BusinessOptions);
            
            CollectOptions = new List<ConfigOptionBase>();
            CollectOptions.AddRange(myConfig.CollectOptions);
            CollectOptions.AddRange(myConfig.CollectExtendOptions);

            totalNumber = AppOptions.Count;
        }

        int totalNumber;
        protected string appSrcPathSub { get; set; }

        protected string appDataDesPathSub { get; set; }

        protected string appSrcPath;

        protected string appDataDesPath;

        protected string appApkDesDirectoryPath;
        protected void onFindAppFile(ConfigeAppOption option, int currentNum)
        {
            onTaskStateChanged(this, new TaskStateChangedEventArgs()
                   {
                       TaskState = TaskState.AppProc,
                       Description = "已找到应用数据备份：" + option.PackageName_Android + " 正在还原...",
                       TaskID = option.ID,
                       CurrentNumber = currentNum,
                       TotalNumber = totalNumber
                   });
        }

        protected virtual bool appApkCheckExist(ConfigeAppOption option, string[] Files, out string filePath)
        {
            filePath = appSrcPath + option.PackageName_Android+".apk";
            return Files.Contains(filePath);
        }
        protected virtual void appApkProcessSingle(string apkPath)
        {
            FileCopyHelper.CopyFile(apkPath, appApkDesDirectoryPath);
        }
        protected virtual bool appDataCheckExist(ConfigeAppOption option, string[] Files, out string filePath)
        {
            filePath = appSrcPath + option.PackageName_Android;
            return false;
        }
        protected virtual void appDataProcessSingle(string tarPath)
        {

        }
        public void DoWork()
        {
            if (String.IsNullOrEmpty(SourcePath) || String.IsNullOrEmpty(DestinationPath))
            {
                onTaskStateChanged(this, new TaskStateChangedEventArgs()
                    {
                        TaskState = TaskState.Error,
                        Description = "请输入源目录地址和目标目录地址。"
                    });
                return;
            }
            tokenSource = new CancellationTokenSource();
            token = tokenSource.Token;  
            mTask = new Task(() =>
            {
                try
                {
                    //一般是不要数据的
                    //processData();
                    if (token.IsCancellationRequested)
                    {
                        throw new OperationCanceledException(token);
                    }
                    processApp();
                }
                catch (Exception e)
                {
                    if (!(e is OperationCanceledException))
                    {
                        onTaskStateChanged(this, new TaskStateChangedEventArgs()
                        {
                            TaskState = TaskState.Error,
                            Description = e.Message,
                        });
                    }
                    else 
                    {
                        onTaskStateChanged(this, new TaskStateChangedEventArgs()
                        {
                            TaskState = TaskState.Finish,
                            Description = "任务已取消",
                        });
                    }
                    return;
                }

                onTaskStateChanged(this, new TaskStateChangedEventArgs()
                {
                    TaskState = TaskState.Finish,
                    Description = "任务结束",
                });
            }, token);

            mTask.Start();
        }
        protected virtual void processData()
        {
        }
        void processApp()
        {
            appSrcPath = SourcePath + appSrcPathSub;
            appDataDesPath = DestinationPath + appDataDesPathSub;
            appApkDesDirectoryPath = DestinationPath + "\\data\\app";
            var Files = Directory.GetFiles(appSrcPath);

            if (!Directory.Exists(appApkDesDirectoryPath))
            {
                //在指定的路径创建文件夹
                Directory.CreateDirectory(appApkDesDirectoryPath);
            }
            int count = 0;
            foreach (var option in AppOptions)
            {
                if (token.IsCancellationRequested)
                {
                    throw new OperationCanceledException(token);
                }
                ++count;
                string filePath;

                if (appApkCheckExist(option, Files, out filePath))
                {
                    onTaskStateChanged(this, new TaskStateChangedEventArgs()
                    {
                        TaskState = TaskState.AppProc,
                        Description = "已找到应用程序备份：" + option.PackageName_Android + " 正在复制...",
                        TaskID = option.ID,
                        CurrentNumber = count,
                        TotalNumber = totalNumber,
                    });
                    appApkProcessSingle(filePath);
                }

                if (appDataCheckExist(option, Files, out filePath))
                {
                    onTaskStateChanged(this, new TaskStateChangedEventArgs()
                    {
                        TaskState = TaskState.AppProc,
                        Description = "已找到应用数据备份：" + option.PackageName_Android + " 正在还原...",
                        TaskID = option.ID,
                        CurrentNumber = count,
                        TotalNumber = totalNumber,
                    });
                    appDataProcessSingle(filePath);
                }
            }
        }

        public void Cancel()
        {
            tokenSource.Cancel();
        }
    }
}
