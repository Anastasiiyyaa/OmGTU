using System;
using System.Collections;

namespace ConsoleApplication5
{
    class Program
    {
    static void Main()
    {
    Console.WriteLine("Введите n");
    int n = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Введите количество городов");
    int k = Convert.ToInt32(Console.ReadLine());
    int[] city = new int[k];
    bool f1 = false;

    for (int i = 0; i < k; i++)
    city[i] = int.Parse(Console.ReadLine());

    int r = k;
int minR = int.MaxValue;
int minI = 0;
for (int i = 1; i < k; i++)
r += city[i];

for (int i = 0; i < city[city.Length - 1]; i++)
{
bool f2 = true;
foreach (int gorod in city)
{
if (gorod >= i)
r-=1;
else
r+=1;
if (Math.Abs(gorod - i) < n)
f2 = false;
}
if (f2==true)
{
f1 = true;
if (r < minR)
{
minR = r;
minI = i;
}
}
}
if (f1==true)
Console.WriteLine("На километре " + minI + " минимальное расстояние " + minR);
else
Console.WriteLine("Нельзя");
}
}
}