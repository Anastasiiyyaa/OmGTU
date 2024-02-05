using System;
using System.Linq;
class HelloWorld
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите размер матрицы:");
        int m = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[,] mas = new int[m, n];
        Console.WriteLine("Заполните матрицу");
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                mas[i, j] = int.Parse(Console.ReadLine());
            }
        }

        //1 задача
        int k = 0;
        for (int j = 0; j < n; j++)
        {
            int sum = 0; int pr = 1;
            for (int i = 0; i < m; i++)
            {
                sum += mas[i, j];
                pr *= mas[i, j];
            }
            if (sum < 0 && pr > 0)
            {
                k += 1;
            }
        }
        Console.WriteLine("1 задача " + k);

        //2 задача
        int chetn = 0;
        for (int i = 0; i < m; i++)
        {
            int min = 1000;
            for (int j = 0; j < n; j++)
            {
                if (mas[i, j] < min) { min = mas[i, j]; }
            }
            if (Math.Abs(min) % 2 == 0) { chetn += 1; }
        }
        if (chetn == m) { Console.WriteLine("2 задача ДА!!:)"); }
        else { Console.WriteLine("2 задача НЕТ!!:("); }
        //3 задача
        int nul = 0;
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (mas[i, j] != 0) { nul += 1; }
            }
        }
        Console.WriteLine("3 задача " + nul);

        //4 задача
        for (int j = 0; j < n; j++)
        {
            int max = -10001;
            for (int i = 0; i < m; i++)
            {
                if (mas[i, j] > max && (Math.Abs(mas[i, j]) % 2 == 0)) { max = mas[i, j]; }
            }
            if (Math.Abs(max) % 2 == 0) { Console.WriteLine("4 задача " + max); }
            else { Console.WriteLine("4 задача " + "Все элементы столбца нечетные"); }
        }

        //5 задача
        int[,] rez = new int[m, 3];
        for (int i = 0; i < m; i++)
        {
            int sum2 = 0; int pr2 = 1; int countnul = 0;
            for (int j = 0; j < n; j++)
            {
                sum2 += mas[i, j];
                pr2 *= mas[i, j];
                if (mas[i, j] == 0) { countnul++; }

             
                    rez[i, 0] = sum2;
                    rez[i, 1] = pr2;
                    rez[i, 2] = countnul;
               
            }
        }

        int col = 0;

        for (int x = 0; x < m - 1; x++)
        {
            for (int y = x + 1; y < m; y++)
            {
                bool o = true;
                for (int u = 0; u < 3; u++)
                {
                    if (rez[x, u] != rez[y, u])
                    {
                        o = false;
                        break;
                    }
                }
                if (o == true)
                {
                    col += 1; 
                }
            }
        }

        Console.WriteLine("5 задача " + col);

    }
}