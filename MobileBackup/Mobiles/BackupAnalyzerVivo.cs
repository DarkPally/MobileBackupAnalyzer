using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobileBackup;
using System.IO;
using MobileBackup.Configs;
namespace MobileBackup.Vivo
{
    public class BackupAnalyzerVivo : MobileBackupAnalyzer
    {
        protected override void processData()
        {
            
        }

        protected override bool appDataCheckExist(ConfigeAppOption option, string[] Files, out string filePath)
        {
            filePath = appSrcPath + option.PackageName_Android + ".zip";
            return Files.Contains(filePath);
        }
        protected override void appDataProcessSingle(string tarPath)
        {
            UnZipHelper.unZipFile(tarPath, appDataDesPath);
        } 

        public BackupAnalyzerVivo(string config, string source, string destination)
            : base(config)
        {
            SourcePath = source;
            DestinationPath = destination;
            appSrcPathSub = "\\thirdapp\\";
            appDataDesPathSub = "\\data\\data\\";
        }
    }
}
