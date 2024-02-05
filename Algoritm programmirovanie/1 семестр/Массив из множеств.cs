using System;
using System.Linq;

class HelloWorld
{
    static void Main()
    {
        Console.WriteLine("Введите размер ступенчатого массива");
        int N = Convert.ToInt32(Console.ReadLine());
        int[][] Arr = new int[N][];
        for (int i = 0; i < N; i++)
        {
            Console.WriteLine("Введите размер массива");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] ar = new int[size];

            Console.WriteLine("Введите элементы массива");
            for (int k = 0; k < size; k++)
            {
                int a = Convert.ToInt32(Console.ReadLine());
                ar[k] = a;
            }
            Arr[i] = ar;
        }

        int sum = 0;
        for (int i = 0; i < N; ++i)
        {
            sum += Arr[i].Length;
            for (int j = 0; j < Arr[i].Length; ++j)
            {
                Console.WriteLine("\t", i, j, Arr[i][j]);
            }
        }

        // объединение
        int[] Ob = new int[sum];

        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < Arr[i].Length; j++)
            {
                Ob = Ob.Concat(new int[] { Arr[i][j] }).ToArray();
            }
        }

        Ob = Ob.Distinct().ToArray(); 
        Ob = Ob.Skip(1).ToArray();
        Console.WriteLine("Объединение всех множеств: ");
        foreach (int u in Ob)
        {
            Console.Write(u);
            Console.Write(" ");
        }
        Console.WriteLine();
        // пересечение
        int[] Per = Arr[0]; 
        for (int i = 1; i < N; i++) 
        {
            Per = Per.Intersect(Arr[i]).ToArray();
        }
        Console.WriteLine("Пересечение всех множеств: ");
        foreach (int j in Per)
        {
            Console.Write(j);
            Console.Write(" ");
        }

        Console.WriteLine();
        // дополнение
        for (int i = 0; i < N; i++)
        {
            int[] Dop = Ob;

            for (int j = 0; j < Arr[i].Length; j++)
            {
                Dop = Dop.Where(val => val != Arr[i][j]).ToArray();
            }

            Console.WriteLine($"Дополнение для множества {i+1}: ");
            foreach (int v in Dop)
            {
                Console.Write(v);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
}