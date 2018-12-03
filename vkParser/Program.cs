using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Dom;

namespace vkParser
{
    class Program
    {
        static void Main(string[] args)
        {
            string content = "";
            string command = @"C:\Phyton37\Scripts\vktop.exe";

            string s1 = "https://vk.com/ru9gag";
            string s2 = "https://vk.com/amfet1";
            string s3 = "https://vk.com/pixel_memes";
            string s4 = "https://vk.com/greatmem";
            string s5 = "https://vk.com/dobriememes";
            string s6 = "https://vk.com/mudakoff";

            //          паблик     топ 10  (.)  дней назад (10)
            string arg1 = s1 + " --top 1 -w 8 -d 10";
            string arg2 = s2 + " --top 1 -w 8 -d 10";
            string arg3 = s3 + " --top 1 -w 8 -d 10";
            string arg4 = s4 + " --top 1 -w 8 -d 10";
            string arg5 = s5 + " --top 1 -w 8 -d 10";
            string arg6 = s6 + " --top 1 -w 8 -d 10";

            Task task1 = Task.Run(() =>
            {
                Console.WriteLine("1");
                // создаем процесс command с параметрами arg
                ProcessStartInfo psiOpt = new ProcessStartInfo(command, arg1);

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


            //Task task2 = task1.ContinueWith(ant =>
            //{
            //    Console.WriteLine("2");
            //    ProcessStartInfo psiOpt = new ProcessStartInfo(command, arg2);
            //    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            //    psiOpt.RedirectStandardOutput = true;
            //    psiOpt.UseShellExecute = false;
            //    psiOpt.CreateNoWindow = true;
            //    Process procCommand = Process.Start(psiOpt);
            //    StreamReader srIncoming = procCommand.StandardOutput;
            //    content += srIncoming.ReadToEnd();
            //    procCommand.WaitForExit();
            //});

            //Task task3 = task2.ContinueWith(ant =>
            //{
            //    Console.WriteLine("3");
            //    ProcessStartInfo psiOpt = new ProcessStartInfo(command, arg3);
            //    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            //    psiOpt.RedirectStandardOutput = true;
            //    psiOpt.UseShellExecute = false;
            //    psiOpt.CreateNoWindow = true;
            //    Process procCommand = Process.Start(psiOpt);
            //    StreamReader srIncoming = procCommand.StandardOutput;
            //    content += srIncoming.ReadToEnd();
            //    procCommand.WaitForExit();
            //});

            //Task task4 = task3.ContinueWith(ant =>
            //{
            //    Console.WriteLine("4");
            //    ProcessStartInfo psiOpt = new ProcessStartInfo(command, arg4);
            //    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            //    psiOpt.RedirectStandardOutput = true;
            //    psiOpt.UseShellExecute = false;
            //    psiOpt.CreateNoWindow = true;
            //    Process procCommand = Process.Start(psiOpt);
            //    StreamReader srIncoming = procCommand.StandardOutput;
            //    content += srIncoming.ReadToEnd();
            //    procCommand.WaitForExit();
            //});

            //Task task5 = task4.ContinueWith(ant =>
            //{
            //    Console.WriteLine("5");
            //    ProcessStartInfo psiOpt = new ProcessStartInfo(command, arg5);
            //    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            //    psiOpt.RedirectStandardOutput = true;
            //    psiOpt.UseShellExecute = false;
            //    psiOpt.CreateNoWindow = true;
            //    Process procCommand = Process.Start(psiOpt);
            //    StreamReader srIncoming = procCommand.StandardOutput;
            //    content += srIncoming.ReadToEnd();
            //    procCommand.WaitForExit();
            //});

            //Task task6 = task5.ContinueWith(ant =>
            //{
            //    Console.WriteLine("6");
            //    ProcessStartInfo psiOpt = new ProcessStartInfo(command, arg6);
            //    psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            //    psiOpt.RedirectStandardOutput = true;
            //    psiOpt.UseShellExecute = false;
            //    psiOpt.CreateNoWindow = true;
            //    Process procCommand = Process.Start(psiOpt);
            //    StreamReader srIncoming = procCommand.StandardOutput;
            //    content += srIncoming.ReadToEnd();
            //    procCommand.WaitForExit();
            //});

            Task finalTask = Task.Factory.ContinueWhenAll(new Task[] { task1, /*task2, task3, task4, task5, task6*/ }, ant =>
            {
                Console.WriteLine(content);
                List<string> ListURLImages = Parser_Images_From_Posts(content);

                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(ListURLImages[0], AppDomain.CurrentDomain.BaseDirectory + "test.jpg");
                    Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
                }


            });


            Console.ReadKey();
        }


        public static List<string> Parser_Images_From_Posts(string content)
        {
            string[] arrayContent = content.Split(' ');
            List<string> s1 = arrayContent.ToList().FindAll(i => i.StartsWith("http") == true);

            List<string> htmlList = new List<string>();

            if (s1.Count > 0)
            {
                foreach (string match in s1)
                {
                    Console.WriteLine(match);
                    htmlList.Add(new WebClient().DownloadString(new Uri(match)));
                }
            }            
            else
            {
                Console.WriteLine("Ссылок не нашел.");
            }

            string[] arrayContentParsed = htmlList[0].Split('(', ')');
            List<string> ListURLImages = arrayContentParsed.ToList().FindAll(i => i.StartsWith("https://pp") == true);

            return ListURLImages;
        }

        //private static void DownloadFiles(string site)
        //{
        //    WebClient client = new WebClient();

        //    // Получаем содержимое страницы
        //    string data;
        //    using (Stream stream = client.OpenRead(site))
        //    {
        //        using (StreamReader reader = new StreamReader(stream))
        //        {
        //            data = reader.ReadToEnd();
        //        }
        //    }

        //    // Парсим теги изображений
        //    Regex regex = new Regex(@"\<img.+?src=\""(?<imgsrc>.+?)\"".+?\>", RegexOptions.ExplicitCapture);
        //    MatchCollection matches = regex.Matches(data);

        //    // Регекс для проверки на корректную ссылку картинки
        //    Regex fileRegex = new Regex(@"[^\s\/]\.(jpg|png|gif|bmp)\z", RegexOptions.Compiled);

        //    // Получаем ссылки на картинки
        //    var imagesUrl = matches
        //        .Cast<Match>()
        //        // Данный из группы регулярного выражения
        //        .Select(m => m.Groups["imgsrc"].Value.Trim())
        //        // Добавляем название сайта, если ссылки относительные
        //        .Select(url => url.Contains("http://") ? url : (site + url))
        //        // Получаем название картинки
        //        .Select(url => new { url, name = url.Split(new[] { '/' }).Last() })
        //        // Проверяем его
        //        .Where(a => fileRegex.IsMatch(a.name))
        //        // Удаляем повторяющиеся элементы
        //        .Distinct()
        //        ;
        //    try
        //    {
        //        // Загружаем картинки
        //        foreach (var value in imagesUrl)
        //        {
        //            Console.WriteLine(value);
        //            // Директория для загрузки
        //            string directory = "C:\\Users\\fzhil\\Downloads\\vk";
        //            Directory.CreateDirectory(directory);
        //            Console.WriteLine(directory);
        //            client.DownloadFile(value.url, Path.Combine(directory, value.name));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //    }

        //}
    }
}
