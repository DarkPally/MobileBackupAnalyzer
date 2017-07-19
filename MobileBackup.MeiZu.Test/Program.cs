using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBackup.MeiZu;
using MobileBackup;

namespace MobileBackupTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var BackupAnalyzer =
               new BackupAnalyzerMeiZu(
                       @"F:\工作项目\华为备份\123.txt",
                       @"F:\工作项目\20161029173838魅族",
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
