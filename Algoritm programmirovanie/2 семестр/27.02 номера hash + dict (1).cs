using System;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите количество звонков");
        int kol = Convert.ToInt32(Console.ReadLine());
        var queue = new Queue<string>();
        var queue2 = new Queue<string>();
        Console.WriteLine("Введите номер телефона (только цифры), дату разговора (год-месяц-день), время начала разговора (часы:минуты), количество минут через пробелы");
        for (int i = 0; i < kol; i++)
        {
            string dannie = Console.ReadLine();
            queue.Enqueue(dannie);
            queue2.Enqueue(dannie);
        }

        var Dictionary = new Dictionary<string, int>();
        var Hashtable = new Hashtable();

        while (queue.Count > 0)
        {
            var inf = queue.Dequeue().Split(' ');
            var phoneNumber = inf[0];
            var min = int.Parse(inf[3]);

            if (Dictionary.ContainsKey(phoneNumber))
            {
                Dictionary[phoneNumber] += min;
            }
            else
            {
                Dictionary.Add(phoneNumber, min);
            }

            if (Hashtable.ContainsKey(phoneNumber))
            {
                Hashtable[phoneNumber] = (int)Hashtable[phoneNumber] + min;
            }
            else
            {
                Hashtable.Add(phoneNumber, min);
            }
        }

        Console.WriteLine("Словарь:");
        foreach (var dc in Dictionary)
        {
            Console.WriteLine($"Номер: {dc.Key}, Минуты: {dc.Value}");
        }

        Console.WriteLine("Хеш-таблица:");
        foreach (DictionaryEntry hsh in Hashtable)
        {
            Console.WriteLine($"Номер: {hsh.Key}, Минуты: {hsh.Value}");
        }
        Dictionary<DateTime, int> MinutDict = new Dictionary<DateTime, int>();
        Hashtable MinutHash = new Hashtable();

        while (queue2.Count > 0)
        {
            var call = queue2.Dequeue().Split(' ');
            var data = call[1].Split('-');
            if (data.Length == 3 && int.TryParse(data[0], out int year) && int.TryParse(data[1], out int month) && int.TryParse(data[2], out int day))
            {
                DateTime date1 = new DateTime(year, month, day);

                var znach = int.Parse(call[3]);

                if (MinutDict.ContainsKey(date1))
                {
                    MinutDict[date1] += znach;
                }
                else
                {
                    MinutDict.Add(date1, znach);
                }

                if (MinutHash.ContainsKey(date1))
                {
                    MinutHash[date1] = (int)MinutHash[date1] + znach;
                }
                else
                {
                    MinutHash.Add(date1, znach);
                }
            }
            else { Console.WriteLine("Неверный формат данных");
            }
        }
        Console.WriteLine("Словарь:");
        foreach (var dc2 in MinutDict)
        {
            Console.WriteLine($"Дата: {(dc2.Key).ToShortDateString()}, Минуты: {dc2.Value}");
        }
        Console.WriteLine("Хеш-таблица:");
        foreach (DictionaryEntry hsh2 in MinutHash)
        {
            DateTime dateKey = (DateTime)hsh2.Key;
            Console.WriteLine($"Дата: {dateKey.ToShortDateString()}, Минуты: {hsh2.Value}");
        }

    }
}