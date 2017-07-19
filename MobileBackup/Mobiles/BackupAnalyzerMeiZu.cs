using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBackup;
using System.IO;

using MobileBackup.Configs;
namespace MobileBackup.MeiZu
{
    public class BackupAnalyzerMeiZu : MobileBackupAnalyzer
    {
        protected override void processData()
        {
            
        }

        protected override bool appCheckExist(ConfigeAppOption option, string[] Files, out string filePath)
        {
            filePath = appSrcPath + option.PackageName_Android + ".zip";
            return Files.Contains(filePath);
        }
        protected override void appProcessSingle(string tarPath)
        {
            UnZipHelper.unZipFile(tarPath, appDesPath);     
        } 

        public BackupAnalyzerMeiZu(string config,string source,string destination)
            : base(config)
        {
            SourcePath = source;
            DestinationPath = destination;
            appSrcPathSub = "\\App\\";
            appDesPathSub="\\data\\data\\";
        }
    }
}
