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
            string pathToSave = "C:\\Users\\fzhil\\Downloads\\vk\\";
            string content = "";

            //          паблик     топ 10  (.)  дней назад (10)
            string arg1 = Const.s1 + " --top 2 -w 8 -d 10";
            string arg2 = Const.s2 + " --top 2 -w 8 -d 10";
            string arg3 = Const.s3 + " --top 2 -w 8 -d 10";
            string arg4 = Const.s4 + " --top 2 -w 8 -d 10";
            string arg5 = Const.s5 + " --top 2 -w 8 -d 10";
            string arg6 = Const.s6 + " --top 2 -w 8 -f 01.10.2018";

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
                procCommand.WaitForExit();
            });

            Task finalTask = Task.Factory.ContinueWhenAll(new Task[] { task1, task2, task3, task4, task5, task6 }, ant =>
            {
                int i = 0;
                Console.WriteLine(content);
                List<string> ListURLImages = Parser_Images_From_Posts(content);

                using (WebClient client = new WebClient())
                {
                    foreach (string image in ListURLImages)
                    {
                        i++;
                        client.DownloadFile(image, pathToSave + i.ToString() + ".jpg");
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
    }
}
