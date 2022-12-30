using System;
using System.Timers;
using System.Collections.Generic;
using System.IO;
using Timer = System.Timers.Timer;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

partial class Programm
{
    public static void Main(string[] args)
    {
        System.Timers.Timer aTimer = CreateTimer();
        while (true)
        {
            aTimer.Start();
        }
    }

    private static int elapsedTime = 0;
    private static int timerInterval = 1000;
    private static List<SubtitleData> testSubtitles = new List<SubtitleData>
    {
        new SubtitleData { StartTime = timerInterval, EndTime = 3 * timerInterval, Text = ReadFile(0) },
        new SubtitleData { StartTime = timerInterval, EndTime = 3 * timerInterval, Text = ReadFile(1) },
        new SubtitleData { StartTime = 2 * timerInterval, EndTime = 6 * timerInterval, Text = ReadFile(2) },
        new SubtitleData { StartTime = 4 * timerInterval, EndTime = 7 * timerInterval, Text = ReadFile(3) },
        new SubtitleData { StartTime = 7 * timerInterval, EndTime = 15 * timerInterval, Text = ReadFile(4) }
    };

    private static void SubtitleReturn(Object source, ElapsedEventArgs e)
    {
        Console.Clear();


        Console.SetCursorPosition(2, 2);
        Console.Write("╔");
        for (int i = 0; i < Console.WindowWidth - 7; i++)
        {
            Console.Write("═");
        }
        Console.Write("╗");

        //Console.SetCursorPosition(2, 3);
        for (int i = 0; i < 20; i++)
        {
            Console.SetCursorPosition(2, i + 3);
            Console.WriteLine("║");
            Console.SetCursorPosition(Console.WindowWidth - 4, i + 3);
            Console.WriteLine("║");
        }

        Console.SetCursorPosition(3, 23);
        for (int i = 0; i < Console.WindowWidth - 7; i++)
        {
            Console.Write("═");
        }
        Console.SetCursorPosition(Console.WindowWidth - 4, 23);
        Console.WriteLine("╝");
        Console.SetCursorPosition(2, 23);
        Console.WriteLine("╚");

        int k = 0;
        string k1 = "0";
        foreach (SubtitleData subtitle in testSubtitles)
        {
            bool isSubtitleVisible = elapsedTime >= subtitle.StartTime
                 && elapsedTime <= subtitle.EndTime;
         
            if (isSubtitleVisible)
            {
                switch (k1)
                {
                    case "0":
                        Console.SetCursorPosition(Console.WindowWidth / 2 - (subtitle.Text.Length / 2), 3);  //hello
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "1":
                        Console.SetCursorPosition(Console.WindowWidth / 2 - (subtitle.Text.Length / 2), Console.WindowHeight - 9); //world
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;
                    case "2":
                        Console.SetCursorPosition(Console.WindowWidth - 8, 12);  //yes
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                    case "3":
                        Console.SetCursorPosition(3, 12);  //no
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case "4":
                        Console.SetCursorPosition(Console.WindowWidth / 2 - (subtitle.Text.Length / 2), Console.WindowHeight - 8);  //bill
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }
                Console.WriteLine(subtitle.Text); //пишем текст
                Console.ResetColor();
            }
            k++;
            k1 = k.ToString();
        }

        elapsedTime += timerInterval;
    }


    static string ReadFile(int neededindex)
    {
        int currentindex = 0;
        string[] array;
        array = new string[6];
        string text = "";
        using (StreamReader fs = new StreamReader(@"laba8.txt"))
        {
            for (int i = 0; i < 6; i++)
            {
                array[currentindex] = fs.ReadLine(); // Читаем строку из файла во временную переменную.
                // Если достигнут конец файла, прерываем считывание
                if (array[currentindex] is null) break;
                currentindex++;
            }
        }
        return array[neededindex];
    }


    public static System.Timers.Timer CreateTimer()
    {
        var timer = new Timer(timerInterval);
        timer.Elapsed += SubtitleReturn;

        return timer;
    }
}