using System;

class Tovar
{
    public string[] M1 { get; set; }
    public int[][] M2 { get; set; }
    public string Name { get; set; }
    public int Srok { get; set; }

    public Tovar(string[] m1, int[][] m2, string name, int srok)
    {
        M1 = m1;
        M2 = m2;
        Name = name;
        Srok = srok;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Дата поставки: {M1[0]}, Дата изготовления: {M1[1]}, Количество товара: {M1[2]}, Стоимость товара: {M1[3]}");
        Console.WriteLine($"Количество продаж: {M2.GetLength(0)}");

        Console.WriteLine("Даты продаж: ");
        for (int i = 0; i < M2.GetLength(0); i++)
        {
            int date = M2[i][0]*100 + M2[i][1];
            int month = date % 100;
            int day = (date / 100) ;
            Console.WriteLine($"{day}.{month}");
        }

        Console.WriteLine($"Наименование товара: {Name}");
        Console.WriteLine($"Срок годности товара: {Srok}");
    }
}

class Program
{
    static Tovar[] tovars;

    static void Main()
    {
        Console.WriteLine("Введите количество видов товара: ");
        int n = Convert.ToInt32(Console.ReadLine());
        tovars = new Tovar[n];

        InputTovarsData();
        SearchOstatokGodnogo();
        SearchNaSpisanie();
        Summasales();
    }

    static void InputTovarsData()
    {
        for (int i = 0; i < tovars.Length; i++)
        {
            Console.WriteLine($"Введите информацию о товаре {i + 1}:");
            Console.Write("Введите дату поставки (день.месяц): ");
            string[] M1 = new string[4];
            M1[0] = Console.ReadLine();
            Console.Write("Введите дату изготовления (день.месяц): ");
            M1[1] = Console.ReadLine();
            Console.Write("Введите количество товара: ");
            M1[2] = Console.ReadLine();
            Console.Write("Введите стоимость товара за единицу: ");
            M1[3] = Console.ReadLine();

            Console.Write("Введите количество продаж: ");
            int prodCount = Convert.ToInt32(Console.ReadLine());
            int[][] M2 = new int[prodCount][];
            for (int j = 0; j < prodCount; j++)
            {
                Console.Write($"Введите дату продажи {j + 1} (день.месяц): ");
                string date = Console.ReadLine();
                int day = Convert.ToInt32(date.Split('.')[0]);
                int month = Convert.ToInt32(date.Split('.')[1]);
                M2[j] = new int[] { day, month };
            }
            Console.Write("Введите наименование товара: ");
            string name = Console.ReadLine();
            Console.Write("Введите срок годности в днях: ");
            int srok = Convert.ToInt32(Console.ReadLine());

            tovars[i] = new Tovar(M1, M2, name, srok);
        }
    }



    static void SearchOstatokGodnogo()
    {
        Console.WriteLine($"Список годного товара:");
        int count = 0;
        foreach (Tovar tovar in tovars)
        {
            int dateIzgotovleniyaDay = Convert.ToInt32(tovar.M1[1].Split('.')[0]);
            int dateIzgotovleniyaMonth = Convert.ToInt32(tovar.M1[1].Split('.')[1]);
            int srokGodnosti = tovar.Srok;
            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;

            int otklad = (currentMonth - dateIzgotovleniyaMonth) * 30 + (currentDay - dateIzgotovleniyaDay);

            if (otklad <= srokGodnosti)
            {
                tovar.PrintInfo();
                count += Convert.ToInt32(tovar.M1[2]);
            }
        }
        Console.WriteLine($"Общее количество годного товара: {count}");
    }
    static void SearchNaSpisanie()
    {
        Console.WriteLine($"Список товара с истёкшим сроком годности:");
        int spis = 0;
        foreach (Tovar tovar in tovars)
        {
            int dateIzgotovleniyaDay = Convert.ToInt32(tovar.M1[1].Split('.')[0]);
            int dateIzgotovleniyaMonth = Convert.ToInt32(tovar.M1[1].Split('.')[1]);
            int srokGodnosti = tovar.Srok;
            int currentDay = DateTime.Now.Day;
            int currentMonth = DateTime.Now.Month;

            int otklad = (currentMonth - dateIzgotovleniyaMonth) * 30 + (currentDay - dateIzgotovleniyaDay);

            if (otklad > srokGodnosti)
            {
                tovar.PrintInfo();
                spis+= Convert.ToInt32(tovar.M1[2]);
            }
        }
        Console.WriteLine($"Общее количество товара с истёкшим сроком годности: {spis}");
    }
    static void Summasales()
    {
        Console.WriteLine("Сумма, на которую продан каждый товар: ");
        int allsumma = 0;
        foreach (Tovar tovar in tovars)
        {
            int kolvo = Convert.ToInt32(tovar.M1[2]);
            int price = Convert.ToInt32(tovar.M1[3]);
            int summa = kolvo * price;
            allsumma += summa;
            Console.WriteLine($"Сумма, на которую продано товара {tovar.Name}: {summa}");
        }
        Console.WriteLine($"Общая сумма проданного товара: {allsumma}");
    }
}
    
    