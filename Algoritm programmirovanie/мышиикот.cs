using System;
using System.Linq;
class HelloWorld {
  static void Main() {
Console.WriteLine("Количество мышей");
int k = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Каждую какую мышь съедает кот");
int m = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Номер белой мыши");
int n = Convert.ToInt32(Console.ReadLine());

int[]mouse = new int[k];
for (int j = 0; j < k; j++)
{
    mouse[j] = j + 1;
}

int i = 0;
int start = i;

while (mouse.Length > 1)
{
    i = (i + m - 1) % mouse.Length;
    int[]t = new int[mouse.Length - 1];
    Array.Copy(mouse, 0, t, 0, i);
    Array.Copy(mouse, i + 1, t, i, mouse.Length - i - 1);
    mouse = t;
}

if (mouse[0] != n)
{
    int r = mouse[0] - start;
    int pervi = n - r;
    if (pervi < 0)
    {
        pervi = k + pervi;
    }
    Console.WriteLine(pervi);
}
else
{
    Console.WriteLine(start);
}

    }
    
  }