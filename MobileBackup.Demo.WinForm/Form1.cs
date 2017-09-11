using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MobileBackup;
using MobileBackup.MeiZu;
using MobileBackup.OPPO;
using MobileBackup.ZTE;
using MobileBackup.Vivo;

using AndroidMUBackup;

namespace MobileBackup.Demo.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;
            this.button2.Enabled = false;
        }
        private void button_config_addr_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string file = ofd.FileName;
                textBox_config_addr.Text = file;
            }
        }
        private void button_backup_addr_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            if (path.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_backup_addr.Text = path.SelectedPath;  
            } 
        }
        private void button_output_addr_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            if (path.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                this.textBox_output_addr.Text = path.SelectedPath;
            } 
        }
        void ChangeProgress(string text, int progressvalue, bool isWorking)
        {            
            if (this.InvokeRequired)
            {
                var param = new object[] { text, progressvalue, isWorking };
                this.Invoke(new ChangeProgressEventHandler(ChangeProgress), param);
            }
            else
            {
                label_msg.Text = text;
                progressBar1.Value = progressvalue;
                this.button1.Enabled = !isWorking;
                this.button2.Enabled = isWorking;
            }

        }
        delegate void ChangeProgressEventHandler(string text,int progressvalue,bool isWorking);

        void OnChanged(object sender, TaskStateChangedEventArgs e)
        {
            string temp;
            if (e.TaskState != TaskState.AppProc)
            {
                temp = string.Format("{0} - {1}", e.TaskState, e.Description);
                if (e.TaskState == TaskState.DataProc)
                {
                    ChangeProgress(temp, 0, true);
                }
                else 
                {
                    ChangeProgress(temp, 100, false);
                }
            }
            else 
            {
                temp = string.Format("{0} - {1}, 任务ID:{2}", e.TaskState, e.Description, e.TaskID);
                ChangeProgress(temp, e.CurrentNumber * 100 / e.TotalNumber, true);
            }
        }
        void OnMUChangedAsyn(object sender, AndroidMUBackup.TaskStateChangedEventArgs e)
        {
            string result = string.Format(
                "应用id:{0};总个数:{1};已完成的个数:{2};任务描述:{3}",
                e.ID,
                e.Total,
                e.Cur,
                e.Description);
            ChangeProgress(result, e.Cur * 100 / e.Total, true);
        }
        void OnMUCompletedAsyn(object sender, AndroidMUBackup.TaskCompletedEventArgs e)
        {
            string result;
            if (e.Cancelled)
            {
                result = "任务被取消";
            }
            else if (e.Error != null)
            {
                result = e.Description;
            }
            else
            {
                int finishNum = e.FinishedNum;          //完成数量
                string description = e.Description;     //任务完成描述字段
                bool flag = e.IsFinished;               //标识任务过程中是否曾发生过异常
                result = string.Format("还原数量:{0};还原过程成功:{1};任务状态:{2}", finishNum, flag, description);
            }
            ChangeProgress(result, 100, false);
        }

        string mobileType;
        string configPath;
        string backupPath;
        string outputPath;
        MobileBackupAnalyzer BackupAnalyzer;
        MUBackupParser muBackupParser;
        bool doAnalyze()
        {
            BackupAnalyzer = null;
            muBackupParser = null;
            switch (mobileType)
            {
                case "魅族":
                    BackupAnalyzer =
                        new BackupAnalyzerMeiZu(
                       configPath,
                       backupPath,
                       outputPath);
                       
                    
                    break;
                case "OPPO":
                    BackupAnalyzer =
                        new BackupAnalyzerOPPO(
                       configPath,
                       backupPath,
                       outputPath);
                    break;
                case "VIVO":
                    BackupAnalyzer =
                        new BackupAnalyzerVivo(
                       configPath,
                       backupPath,
                       outputPath);
                    break;
                case "中兴":
                    BackupAnalyzer =
                        new BackupAnalyzerZTE(
                       configPath,
                       backupPath,
                       outputPath);
                    break;
                case "小米":

                    muBackupParser = new MUBackupParser(
                         configPath,
                       backupPath,
                       outputPath);
                    muBackupParser.TaskCompleted += new MUBackupParser.TaskCompletedEventHandler(OnMUCompletedAsyn);
                    muBackupParser.TaskStateChanged += new MUBackupParser.TaskStateChangedEventHandler(OnMUChangedAsyn);

                    bool firResult = muBackupParser.DoWorkAsyn();
                    
                    break;
                default:
                    return false;
            }
            if (BackupAnalyzer!=null)
            {
                BackupAnalyzer.OnTaskStateChanged += OnChanged;
                BackupAnalyzer.DoWork();
            }            
            return true ;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeProgress("任务进行中..",0,true);
                
                mobileType = comboBox1.Text;
                configPath = textBox_config_addr.Text;
                backupPath = textBox_backup_addr.Text;
                outputPath = textBox_output_addr.Text;

                if (!doAnalyze())
                {
                    ChangeProgress("错误:无效的手机厂商", 100, false);
                }
                
            }
            catch(Exception ex)
            {
                ChangeProgress("异常错误:请检测参数是否正确", 100, false);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if(BackupAnalyzer!=null)
            {
                this.label_msg.Text = "任务取消中...";
                BackupAnalyzer.Cancel();
            }
            if (muBackupParser != null)
            {
                this.label_msg.Text = "任务取消中...";
                muBackupParser.CancelAsync();
            }
        }

    }
}
