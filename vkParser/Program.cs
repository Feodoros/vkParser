using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace vkParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathToSave0 = "C:\\Users\\Александр\\Desktop\\Мемы_Приколы\\";
            string pathToSave1 = "C:\\Users\\Александр\\Desktop\\мемная_папка\\";
            string pathToSave2 = "C:\\Users\\Александр\\Desktop\\МЕМЫ\\";
            string pathToSave3 = "C:\\Users\\Александр\\Desktop\\MDK\\";
            string pathToSave4 = "C:\\Users\\Александр\\Desktop\\абстрактные_мемы_для_элиты_всех_сортов\\";
            string pathToSave5 = "C:\\Users\\Александр\\Desktop\\сомнительные_картинки_и_подписи_к_ним\\";
            string pathToSave6 = "C:\\Users\\Александр\\Desktop\\Даркнет_который_мы_заслужили\\";
            string pathToSave7 = "C:\\Users\\Александр\\Desktop\\4ch\\";
            string pathToSave8 = "C:\\Users\\Александр\\Desktop\\ЗШ\\";
            string pathToSave9 = "C:\\Users\\Александр\\Desktop\\DESUCHAN\\";            

            string content = "";

            //          паблик     топ 50  (.)  дней назад (100)
            string arg1 = Const.s1 + " --top 50 -w 8 -d 100";
            string arg2 = Const.s2 + " --top 50 -w 8 -d 100";
            string arg3 = Const.s3 + " --top 50 -w 8 -d 100";
            string arg4 = Const.s4 + " --top 50 -w 8 -d 100";
            string arg5 = Const.s5 + " --top 50 -w 8 -d 100";
            string arg6 = Const.s6 + " --top 50 -w 8 -d 100";
            string arg7 = Const.s7 + " --top 50 -w 8 -d 100";
            string arg8 = Const.s8 + " --top 50 -w 8 -d 100";
            string arg9 = Const.s9 + " --top 50 -w 8 -d 100";
            string arg10 = Const.s10 + "--top 50 -w 8 -d 100";

            Task task1 = Task.Run(() =>
            {
                Console.WriteLine("1");
                // создаем процесс command с параметрами arg
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg1);

                // скрываем окно запущенного процесса
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;

                // запускаем процесс
                Process procCommand = Process.Start(psiOpt);

                // получаем ответ запущенного процесса
                StreamReader srIncoming = procCommand.StandardOutput;

                //заполняем текстовый файл (content) инфой
                content += srIncoming.ReadToEnd();

                // закрываем процесс
                procCommand.WaitForExit();
                Console.WriteLine(content);

            });         

            Task task2 = task1.ContinueWith(ant =>
            {
                Console.WriteLine("2");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg2);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);
                procCommand.WaitForExit();
            });

            Task task3 = task2.ContinueWith(ant =>
            {
                Console.WriteLine("3");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg3);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                procCommand.WaitForExit();
                Console.WriteLine(content);

            });

            Task task4 = task3.ContinueWith(ant =>
            {
                Console.WriteLine("4");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg4);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });

            Task task5 = task4.ContinueWith(ant =>
            {
                Console.WriteLine("5");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg5);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });

            Task task6 = task5.ContinueWith(ant =>
            {
                Console.WriteLine("6");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg6);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });

            Task task7 = task6.ContinueWith(ant =>
            {
                Console.WriteLine("7");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg7);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });

            Task task8 = task7.ContinueWith(ant =>
            {
                Console.WriteLine("8");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg8);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });

            Task task9 = task8.ContinueWith(ant =>
            {
                Console.WriteLine("9");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg9);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });

            Task task10 = task9.ContinueWith(ant =>
            {
                Console.WriteLine("10");
                ProcessStartInfo psiOpt = new ProcessStartInfo(Const.command, arg10);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                StreamReader srIncoming = procCommand.StandardOutput;
                content += srIncoming.ReadToEnd();
                Console.WriteLine(content);

                procCommand.WaitForExit();
            });


            Task finalTask = Task.Factory.ContinueWhenAll(new Task[] { task1, task2, task3, task4, task5, task6, task7, task8, task9, task10 }, ant =>
            {
                int i = 0;
               // Console.WriteLine(content);
                List<string> ListURLImages = Parser_Images_From_Posts(content);

                using (WebClient client = new WebClient())
                {
                    foreach (string image in ListURLImages)
                    {
                       if (i/50 == 0)
                        client.DownloadFile(image, pathToSave0 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 1)
                            client.DownloadFile(image, pathToSave1 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 2)
                            client.DownloadFile(image, pathToSave2 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 3)
                            client.DownloadFile(image, pathToSave3 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 4)
                            client.DownloadFile(image, pathToSave4 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 5)
                            client.DownloadFile(image, pathToSave5 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 6)
                            client.DownloadFile(image, pathToSave6 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 7)
                            client.DownloadFile(image, pathToSave7 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 8)
                            client.DownloadFile(image, pathToSave8 + (i % 50).ToString() + ".jpg");
                        if (i / 50 == 9)
                            client.DownloadFile(image, pathToSave9 + (i % 50).ToString() + ".jpg");
                        i++;
                    }
                }

                Console.WriteLine("Готово.");
            });


            Console.ReadKey();
        }


        public static List<string> Parser_Images_From_Posts(string content)
        {
            int i1 = 0;
            string[] arrayContent = content.Split(' ');
            List<string> s1 = arrayContent.ToList().FindAll(i => i.StartsWith("http") == true); //Список ссылок на посты
            List<string> List_HTML_Data = new List<string>();  //Список постов в формате HTML
            List<string> List_URL_Images = new List<string>(); //Список адресов картинок из постов

            if (s1.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ссылки на посты:");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (string match in s1)
                {
                    i1++;
                    Console.WriteLine(i1.ToString() + " " + match);

                    if (ScrapeData(match) != null)
                        List_URL_Images.Add(ScrapeData(match));
                    else
                        Console.WriteLine(match + " - пост из нескольких картинок.");
                }
            }
            else
            {
                Console.WriteLine("Ссылок не нашел.");
            }

            return List_URL_Images;
        }

        public static string ScrapeData(string page)
        {
            var web = new HtmlWeb();

            var doc = web.Load(page);

            var Post = doc.DocumentNode.SelectNodes("//*[@class = 'page_post_sized_thumbs  clear_fix']"); //Парсим HTML страницу по классам


            string[] separators = new string[2];
            separators[0] = "<a";
            separators[1] = "a>";

            try
            {
                string[] Post_HTML_View = Post[0].InnerHtml.ToString().Split(separators, StringSplitOptions.RemoveEmptyEntries); //Картинка поста - первый по порядку див-класс (поэтому нулевой), картинки в коментах - [1],...,[n]

                if (Post_HTML_View.Count() < 2) //Проверяем состоит ли пост из нескольких мемов
                {
                    string[] tempArray = Post_HTML_View[0].ToString().Split('(', ')');
                    List<string> ListURLImages = tempArray.ToList().FindAll(i => i.StartsWith("http") == true);

                    return ListURLImages[0]; //Возвращаем ссылку на картинку поста
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
                return null;
            }

        }
    }
}
