using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBackup;
using System.IO;
using MobileBackup.Configs;
namespace MobileBackup.OPPO
{
    public class BackupAnalyzerOPPO : MobileBackupAnalyzer
    {
        protected override void processData()
        {
            var dataPath = SourcePath + "\\Data\\";
            if (!System.IO.Directory.Exists(dataPath))
            {
                onTaskStateChanged(this, new TaskStateChangedEventArgs()
                {
                    TaskState = TaskState.DataProc,
                    Description = "未找到一般数据的备份目录，跳过该步。"
                });
                return;
            }

            var outpath = DestinationPath + "\\Data\\";

            onTaskStateChanged(this, new TaskStateChangedEventArgs()
            {
                TaskState = TaskState.DataProc,
                Description = "开始还原一般数据..."
            });
            FileCopyHelper.CopyDirectory(dataPath, outpath);

            onTaskStateChanged(this, new TaskStateChangedEventArgs()
            {
                TaskState = TaskState.DataProc,
                Description = "一般数据还原完成，输出目录：" + outpath
            });

        }

        protected override bool appCheckExist(ConfigeAppOption option, string[] Files, out string filePath)
        {
            filePath = appSrcPath + option.PackageName_Android + ".tar";
            return Files.Contains(filePath);
        }
        protected override void appProcessSingle(string tarPath)
        {
            UnTarHelper.unTarFile(tarPath, appDesPath);
        } 

        public BackupAnalyzerOPPO(string config, string source, string destination)
            : base(config)
        {
            SourcePath = source;
            DestinationPath = destination;
            appSrcPathSub = "\\App\\";
            appDesPathSub = "\\";
        }
    }
}
