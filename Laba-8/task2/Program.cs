using System;
using System.Security.Cryptography.X509Certificates;

class Programm
{
    public static void Main()
    {
        int integer;
        int conditionaloperator = 0;
        int summ;
        summ = int.Parse(ReadFile(0));
        //Console.WriteLine(summ);

        int[] amount;
        amount = new int[20];

        string[] data;
        data = new string[20];

        string[] opreation;
        opreation = new string[20];

        string[] a1;
        a1 = new string[20];


        for (int i = 1; i <= 6; i++)
        {
            int meaning = 0;
            string str = ReadFile(i);
            a1 = str.Split("|");
            foreach (var sub in a1)
            {
                if (meaning == 0) 
                    data[i-1] = sub; 
                if (meaning == 1) if (int.TryParse(sub.Replace(" ", ""), out integer)) 
                        amount[i-1] = int.Parse(sub.Replace(" ", "")); 
                    else opreation[i - 1] = sub.Replace(" ", "");
                if (meaning == 2) 
                    opreation[i-1] = sub.Replace(" ", "");
                meaning++;  
            }
        }


        int count;
        while (true)
        {
            count = opreation.Length;
            Console.WriteLine("Введите дату и время. Будет выведено кол-во средств на счету карты на этот момент времени" + "\nПример ввода даты и времени: 2021-06-01 12:05 " + "\nПосле времени должен быть пробел " + "\nУвидеть итоговый остаток введите q");
            string datatime = Console.ReadLine();
            if (datatime == "q") break;
            for (int i = 0; i < data.Length; i++)
                if (datatime == data[i]) 
                { 
                    count = i+1; 
                    conditionaloperator = 1; 
                    break;  
                }
            if (count != opreation.Length) break; else Console.WriteLine("Некорректный ввод");
        }

        for (int i = 0; i < count; i++)
        {
            switch (opreation[i])
            {
                case "in":
                    summ += amount[i]; 
                    break;
                case "out":
                    summ -= amount[i];
                    break;
                case "revert":
                    if (opreation[i-1] == "on") summ -= amount[i-1];
                    else summ += amount[i-1];
                    break;
            }
        }
        if (conditionaloperator == 0)
            if (summ >= 0) Console.WriteLine("Итоговый остаток средвств - " + summ);
            else Console.WriteLine("Ошибка. Расход превысил остаток по карте");
        else Console.WriteLine("Кол-во средств на счету карты на этот момент времени - " + summ);
    }
    static string ReadFile(int neededindex)
    {
        int currentindex = 0;
        string[] array;
        array = new string[8];
        string text = "";
        using (StreamReader fs = new StreamReader(@"lab.txt"))
        {
            while (true)
            {
                array[currentindex] = fs.ReadLine();
                if (array[currentindex] == null) break;
                currentindex++;
            }
        }
        return array[neededindex];
    }
}
