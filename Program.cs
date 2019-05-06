using System;
using System.IO;
using System.Net;
using System.Text;

namespace DownloadUrlFile
{
    class Program
    {

        // 读取下载地址文件

        static void Main(string[] args)
        {
            //DownloadImageFromTxt(@"d:\zzz\uri.txt");
            DownloadImage();
        }


        static void DownloadImage()
        {
            using (WebClient client = new WebClient())
            {
                int Count = 30;
                string URL_Templet = @"http://www.nstrs.cn/Admin/PdfViewDynamicImg/Talentaylor/400008634--2013YQ130429-15/2019-04-12/2.5/A{0}.Jpeg";

                for (int i = 1; i <= Count; i++)
                {
                    
                    string url_current = string.Format(URL_Templet, i);
                    Console.WriteLine(url_current + " " + i);
                    Uri uri = new Uri(url_current);
                    if (uri != null)
                    {
                        string filename = Path.GetFileName(uri.LocalPath);
                        client.DownloadFile(uri, @"d:\zzz\" + filename);
                        Console.WriteLine("文件：" + filename + " 下载成功！" + " 计数：" + i);
                    }
                    else
                    {
                        Console.WriteLine("路径：" + url_current + " 不是下载地址！失败序号：" + i);
                    }

                }
            }

            Console.WriteLine("下载完成！");
            Console.ReadKey();
        }

        static void DownloadImageFromTxt(string text_file)
        {
            //StreamReader读取
            int count = 0;
            using (Stream readerStream = new FileStream(text_file, FileMode.Open))
            using (StreamReader reader = new StreamReader(readerStream, Encoding.UTF8))
            using (WebClient client = new WebClient())
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                    Console.WriteLine(line + " " + count);
                    Uri uri = new Uri(line);
                    if (uri != null)
                    {
                        string filename = Path.GetFileName(uri.LocalPath);
                        client.DownloadFile(uri, @"d:\zzz\" + filename);
                        Console.WriteLine("文件：" + filename + " 下载成功！" + " 计数：" + count);
                    }
                    else
                    {
                        Console.WriteLine("路径：" + line + " 不是下载地址！失败序号：" + count);
                    }
                }
            }

            Console.WriteLine("下载完成！");
            Console.ReadKey();
        }

    }
}
