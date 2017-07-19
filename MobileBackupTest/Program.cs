using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBackup.ZTE;
using MobileBackup.OPPO;
using MobileBackup;

namespace MobileBackupTest
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var BackupAnalyzer =
               new BackupAnalyzerZTE(
                       @"F:\工作项目\华为备份\DataCollectConfig.and",
                       @"F:\工作项目\中兴手机备份数据\backups\backup",
                       @"F:\工作项目\输出目录");
            */
            var BackupAnalyzer =
               new BackupAnalyzerOPPO(
                       @"F:\工作项目\备份恢复\华为备份\DataCollectConfig.and",
                       @"F:\工作项目\备份恢复\OPPO\App",
                       @"F:\工作项目\备份恢复\测试目录");

            BackupAnalyzer.OnTaskStateChanged += OnChanged;

            BackupAnalyzer.DoWork();

            Console.ReadLine();
        }

        static void OnChanged(object sender, TaskStateChangedEventArgs e)
        {
            if (e.TaskState != TaskState.AppProc)
            {
                Console.WriteLine("{0} - {1}", e.TaskState, e.Description);
            }
            else
            {
                Console.WriteLine("{0} - {1}, 任务ID:{2}", e.TaskState, e.Description, e.TaskID);
            }
        }
    }
}
