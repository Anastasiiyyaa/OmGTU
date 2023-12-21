using System;

class Animal
{
    public string Name { get; set; }
    public int Year { get; set; }
    public Animal(string name, int year)
    {
        Name = name;
        Year = year;
    }
}

class Dog : Animal
{
    public string Poroda { get; set; }
    public string Okras { get; set; }

    public Dog(string name, int year, string poroda, string okras)
        : base(name, year)
    {
        Poroda = poroda;
        Okras = okras;
    }

    public void dogPrintInfo()
    {
        Console.WriteLine($"Имя собачки: {Name}, Дата рождения собачки: {Year}, Окрас собачки: {Okras}, Порода собачки: {Poroda}");
    }
}

class Cat : Animal
{
    public string Poroda { get; set; }
    public string Okras { get; set; }

    public Cat(string name, int year, string poroda, string okras)
        : base(name, year)
    {
        Poroda = poroda;
        Okras = okras;
    }

    public void catPrintInfo()
    {
        Console.WriteLine($"Имя кошечки: {Name}, Дата рождения кошечки: {Year},  Окрас кошечки: {Okras}, Порода кошечки: {Poroda}");
    }
    public void ChangePoroda(string newPoroda)
    {
        Poroda = newPoroda;
    }
}

class Program
{
    static Dog[] dogs;
    static Cat[] cats;

    static void Main()
    {
        Console.WriteLine("Введите количество собачек: ");
        int d = Convert.ToInt32(Console.ReadLine());
        dogs = new Dog[d];
        Console.WriteLine("Введите количество кошечек: ");
        int c = Convert.ToInt32(Console.ReadLine());
        cats = new Cat[c];
        InputAnimals();
        SearchPorodaDogs();
        SearchOkrasCats();
        Console.WriteLine("Хотите изменить породу кошечки? (Да/Нет)");
        string otvet = Console.ReadLine();
        if (otvet.ToLower() == "да")
        {
            Console.Write("Введите номер кошечки, для которой хотите изменить породу: ");
            int catIndex = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Введите новую породу кошечки: ");
            string newPoroda = Console.ReadLine();
            cats[catIndex].ChangePoroda(newPoroda);
            Console.WriteLine("Порода кошечки изменена");
            foreach (var cat in cats)
            {
                cat.catPrintInfo();
            }
        }
    }
    static void InputAnimals()
    {
        for (int i = 0; i < dogs.Length; i++)
        {
            Console.WriteLine($"Введите информацию о собачке №{i + 1}:");
            Console.Write("Введите имя собачки: ");
            string name = Console.ReadLine();
            Console.Write("Введите год рождения собачки: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите породу собачки: ");
            string poroda = Console.ReadLine();
            Console.Write("Введите окраску собачки: ");
            string okras = Console.ReadLine();
            dogs[i] = new Dog(name, year, poroda, okras);
        }

        for (int i = 0; i < cats.Length; i++)
        {
            Console.WriteLine($"Введите информацию о кошечке №{i + 1}:");
            Console.Write("Введите имя кошечки: ");
            string name = Console.ReadLine();
            Console.Write("Введите год рождения кошечки: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите породу кошечки: ");
            string poroda = Console.ReadLine();
            Console.Write("Введите окраску кошечки: ");
            string okras = Console.ReadLine();
            cats[i] = new Cat(name, year, poroda, okras);
        }
    }

    static void SearchPorodaDogs()
    {
        Console.WriteLine("Введите искомую породу собачки: ");
        string dogporoda = Console.ReadLine();
        Console.WriteLine("Собачки породы " + dogporoda + ":");
        foreach (var dog in dogs)
        {
            if (dog.Poroda == dogporoda)
            {
                dog.dogPrintInfo();
            }
        }
    }
    static void SearchOkrasCats()
    {
        Console.WriteLine("Введите искомый окрас кошечки: ");
        string catokras = Console.ReadLine();
        Console.WriteLine("Кошечки окраса " + catokras + ":");
        foreach (var cat in cats)
        {
            if (cat.Okras == catokras)
            {
                cat.catPrintInfo();
            }
        }
    }
}