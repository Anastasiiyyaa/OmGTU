using System;
public class Fond
{
    public int Mesta { get; set; }
    public int Pro { get; set; }
    public int Komp { get; set; }
    public int Etaj { get; set; }
    public int Num { get; set; }
    public Fond(int mesta, int pro, int komp, int etaj, int num)
    {
        Mesta = mesta;
        Pro = pro;
        Komp = komp;
        Etaj = etaj;
        Num = num;
    }
    public void PrintAud()
    {
        string p;
        string k;
        int kol;
        string Nomer;
        if (Pro == 1) { p = "есть"; }
        else { p = "нет"; }
        if (Komp == 1) { k = "есть"; kol = Mesta; }
        else { k = "нет"; kol = 0; }
        if (Num > 9) { Nomer = Convert.ToString(Etaj) + Convert.ToString(Num); }
        else { Nomer = Convert.ToString(Etaj) + "0" + Convert.ToString(Num); }
        Console.WriteLine($"Номер аудитории: {Nomer}, Количество мест: {Mesta}, Наличие проектора: {p}, Наличие и количество компьютеров: {k}, {kol}");
    }
}
public class Menu
{
    static Fond[] auds;

    static void Main(string[] args)
    {
        ZapAuds();
        while (true)
        {
            Console.WriteLine("Выберите :");
            Console.WriteLine("1. Добавить аудиторию (введите 1)");
            Console.WriteLine("2. Изменить данные аудитории (введите 2)");
            Console.WriteLine("3. Вывести перечень запросов (введите 3)");
            Console.WriteLine("4. Выйти (введите 4)");
            int ans = ogranichenie();
            switch (ans)
            {
                case 1:
                    DobAud();
                    break;
                case 2:
                    if (auds.Length != 0)
                    {
                        IzmAud();
                    }
                    else { Console.WriteLine("Добавьте хотя бы одну аудиторию"); }
                    break;
                case 3:
                    if (auds.Length != 0)
                    {
                        Console.WriteLine("Перечень запросов: ");
                        Console.WriteLine("1. Вывести список аудиторий с количеством посадочных мест больше, либо равно заданному (введите 1)");
                        Console.WriteLine("2. Вывести список аудиторий с проектором и количеством посадочных мест больше, либо равно заданному (введите 2)");
                        Console.WriteLine("3. Вывести список аудиторий с компьютерами и количеством посадочных мест больше, либо равно заданному (введите 3)");
                        Console.WriteLine("4. Вывести список аудиторий на заданном этаже (введите 4)");
                        Console.WriteLine("5. Вывести полный список аудиторий (введите 5)");
                        Console.WriteLine("6. Выйти в меню (введите 6)");
                        int per = ogranichenie();
                        switch (per)
                        {
                            case 1:
                                Console.WriteLine("Введите необходимое количество мест");
                                int mesta = ogranichenie();
                                Viborka1(mesta);
                                break;
                            case 2:
                                Console.WriteLine("Введите необходимое количество мест");
                                mesta = ogranichenie();
                                Viborka2(mesta);
                                break;
                            case 3:
                                Console.WriteLine("Введите необходимое количество мест");
                                mesta = ogranichenie();
                                Viborka3(mesta);
                                break;
                            case 4:
                                Console.WriteLine("Введите номер искомого этажа");
                                int etaj = ogranichenieetaj();
                                Viborka4(etaj);
                                break;
                            case 5:
                                Viborka5();
                                break;
                            case 6:
                                break;
                            default:
                                Console.WriteLine("Неверный ввод. Введите число от 1 до 6.");
                                break;
                        }
                    }
                    else { Console.WriteLine("Добавьте хотя бы одну аудиторию"); }

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Если хотите вернуться в меню - введите 1. Если хотите окончательно выйти из программы - 0");
                    int exit = ogranicheniekp();
                    if (exit==1){break;}
                    if (exit==0){return;}
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Введите число от 1 до 4.");
                    break;
            }
        }
    }
    static void ZapAuds()
    {
        Console.WriteLine("Введите количество аудиторий");
        int n = ogranichenie();
        auds = new Fond[n];
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Введите информацию об аудитории {0}:", i + 1);
            Fond aud = new Fond(0, 0, 0, 0, 0);

            Console.Write("Введите номер этажа: ");
         
            int Etaj = ogranichenieetaj();

            Console.Write("Введите номер аудитории: ");

            int Num = ogranichenienum();

            Console.Write("Введите количество мест в аудитории: ");
            int Mesta = ogranichenie();
            Console.Write("Наличие проектора (1 - есть, 0 - нет): ");
            int Pro = ogranicheniekp();
            Console.Write("Наличие компьютера (1 - есть, 0 - нет): ");
            int Komp = ogranicheniekp();



            auds[i] = new Fond(Mesta, Pro, Komp, Etaj, Num);
        }
        Console.WriteLine("Все аудитории заполнены");
    }
    static void DobAud()
    {
        Console.WriteLine("Введите информацию о новой аудитории");
        Console.WriteLine("Введите номер этажа: ");
        int Etaj = ogranichenieetaj();
        Console.WriteLine("Введите номер аудитории: ");
        int Num = ogranichenienum();

        bool proverka = true;
        foreach (Fond a in auds)
        {
            if (a.Etaj == Etaj && a.Num == Num)
            { proverka = false; }
        }

        if (!proverka) { Console.WriteLine("Такая аудитория уже существует"); }
        else
        {
            Fond aud = new Fond(0, 0, 0, 0, 0);
            Console.WriteLine("Введите количество мест в аудитории: ");
            int Mesta = ogranichenie();

            Console.WriteLine("Наличие проектора (1 - есть, 0 - нет): ");
            int Pro = ogranicheniekp();

            Console.WriteLine("Наличие компьютеров (1 - есть, 0 - нет): ");
            int Komp = ogranicheniekp();

            Array.Resize(ref auds, auds.Length + 1);
            auds[auds.Length - 1] = new Fond(Mesta, Pro, Komp, Etaj, Num);
            Console.WriteLine("  Аудитория добавлена ");

        }

    }
    static void IzmAud()
    {
        Console.WriteLine("Введите номер этажа: ");
        int etaj = ogranichenieetaj();
        Console.WriteLine("Введите номер аудитории: ");
        int num = ogranichenienum();
        bool found = false;
        foreach (Fond aud in auds)
        {
            if (aud.Etaj == etaj && aud.Num == num)
            {
                Console.Write("Введите новое количество мест: ");
                int mesta = ogranichenie();

                Console.Write("Наличие проектора (1 - есть/0 - нет): ");
                int pro = ogranicheniekp();

                Console.Write("Наличие компьюетров (1 - есть/0 - нет): ");
                int komp = ogranicheniekp();
                aud.Pro = pro;
                aud.Mesta = mesta;
                aud.Komp = komp;

                Console.WriteLine("Данные об аудитории обновлены");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine("Аудитория не найдена");
        }
    }
    static void Viborka1(int mesta)
    {
        foreach (Fond aud in auds)
        {
            if (aud.Mesta >= mesta)
            {
                aud.PrintAud();
            }
        }
    }
    static void Viborka2(int mesta)
    {
        foreach (Fond aud in auds)
        {
            if (aud.Mesta >= mesta && aud.Pro == 1)
            {
                aud.PrintAud();
            }
        }
    }
    static void Viborka3(int mesta)
    {
        foreach (Fond aud in auds)
        {
            if (aud.Mesta >= mesta && aud.Komp == 1)
            {
                aud.PrintAud();
            }
        }
    }
    static void Viborka4(int etaj)
    {
        foreach (Fond aud in auds)
        {
            if (aud.Etaj == etaj)
            {
                aud.PrintAud();
            }
        }
    }
    static void Viborka5()
    {
        foreach (Fond aud in auds)
        {
            aud.PrintAud();
        }
    }
    static int ogranichenie()
    {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
        {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                if (vvod>=0){
                isNumeric = true;}
                else {Console.WriteLine("Неверный формат ввода. Вводимое число не может быть отрицательным");}
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
    static int ogranicheniekp()
    {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
        {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                if (vvod == 0 || vvod == 1) { isNumeric = true; }
                else { Console.WriteLine("Введите 0 или 1"); isNumeric = false; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
    static int ogranichenieetaj()
    {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
        {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                if (vvod <= 9 && vvod > 0) { isNumeric = true; }
                else { Console.WriteLine("Максимум 9 этажей, введите число от 1 до 9"); isNumeric = false; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
    static int ogranichenienum()
    {
        bool isNumeric = false;
        int vvod = 0;
        while (!isNumeric)
        {
            try
            {
                vvod = Convert.ToInt32(Console.ReadLine());
                if (vvod <= 99 && vvod > 0) { isNumeric = true; }
                else { Console.WriteLine("На каждом этаже максимум 99 аудиторий, введите число от 1 до 99"); isNumeric = false; }
            }
            catch (FormatException)
            {
                Console.WriteLine("Неверный формат ввода. Введите целое число.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Введенное число слишком большое. Введите целое число в допустимом диапазоне.");
            }
        }
        return vvod;
    }
}