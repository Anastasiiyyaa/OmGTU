using System;

class Program
{
static void Main()
{
int N = Convert.ToInt32(Console.ReadLine()); 

int[,] pairs = new int[N, 2]; //двумерный массив в котором будут храниться пары


for (int i = 0; i < N; i++)
{
string[] input = Console.ReadLine().Split(); //строка из 2 чисел разбивается на подстроки
pairs[i, 0] = int.Parse(input[0]); //каждая из подстрок сохраняется в соответствующий элемент массива
pairs[i, 1] = int.Parse(input[1]);
}

int[,] dp = new int[N + 1, 3]; //массив для хранения промежуточных рез-ов

for (int i = 0; i <= N; i++)
{
for (int j = 0; j < 3; j++)
{
dp[i, j] = -1; //для всех элементов = -1
}
}

dp[0, 0] = 0; // начальная сумма = 0 и %3 = 0


for (int i = 0; i < N; i++)  //перебор каждой пары чисел
{
int a = pairs[i, 0];
int b = pairs[i, 1];

for (int j = 0; j < 3; j++)
{
if (dp[i, j] != -1) 
{
if (dp[i + 1, (j + a) % 3] < dp[i, j] + a)
dp[i + 1, (j + a) % 3] = dp[i, j] + a;
if (dp[i + 1, (j + b) % 3] < dp[i, j] + b)
dp[i + 1, (j + b) % 3] = dp[i, j] + b;
}
}
}

if (dp[N, 0] <= 0)
Console.WriteLine("Нельзя");
else
Console.WriteLine(dp[N, 0]);
}
}