using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using ICSharpCode.SharpZipLib.Checksums;  
using ICSharpCode.SharpZipLib.Zip;   

namespace MobileBackup
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Count()==0)
            {
                Console.WriteLine("请输入文件地址");
                return;
            }
            if (args.Count() > 2)
            {
                Console.WriteLine("目前仅支持最多两个参数");
                return;
            }

            try
            {
                var file=new FileInfo(args[0]);
                string p1=file.FullName;
                string p2;
                if (args.Count()== 2)
                {
                    p2 = args[1];
;                }
                else
                {
                   
                    p2 = Path.GetDirectoryName(p1)+"\\"+ Path.GetFileNameWithoutExtension(p1);
                }

                UnTarFloClass a = new UnTarFloClass();
                var s=a.unTarFile(p1, p2);
                if(s=="")
                {
                    Console.WriteLine("成功解压文件\n 输出目录:{0}", p2);

                }
                else 
                {
                    Console.WriteLine("解压失败\n {0}", s);
                }

            }
               
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
