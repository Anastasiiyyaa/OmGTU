using System;
class HelloWorld {
  static void Main() {
    int k = 0; int n = 0; int summa = 0; int proizved = 1;
    for (int i=0; i<10; i++){
    int a = Convert.ToInt32(Console.ReadLine());
    if (a<0)
    {
        k+=1;
    }
    if (((Math.Abs(a))%10)==3)
    {
        n+=1;
    }
    if (Math.Abs(a)%3==Math.Abs(a)%5)
    {
        summa+=a;
    }
    if (((Math.Abs(a))%2==0) && (a>=0))
    {
        proizved*=a;
    }
    }
Console.WriteLine("Количество отрицательных: " + k);
Console.WriteLine("Количество оканчивающихся на 3: " + n);
Console.WriteLine("Сумма элементов которые в трочиной и пятеричной системе оканч. одинаково: " + summa);
Console.WriteLine("Произведение неотрицательных четных элементов: " + proizved);
  }
}