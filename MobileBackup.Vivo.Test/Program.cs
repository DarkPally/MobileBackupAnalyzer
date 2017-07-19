using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBackup.Vivo;
using MobileBackup;

namespace MobileBackupTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var BackupAnalyzer =
               new BackupAnalyzerVivo(
                       @"F:\工作项目\华为备份\DataCollectConfig.and",
                       @"F:\工作项目\vivo Y51 20161107223830.vbak",
                       @"F:\工作项目\输出目录");

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
