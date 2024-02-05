using System;
class HelloWorld {
static void Main() {
int a=0, b=0;
a = Convert.ToInt32(Console.ReadLine());
b = Convert.ToInt32(Console.ReadLine());
a = a + b;
b = a - b;
a = a - b;
Console.WriteLine(a);
Console.WriteLine(b);
}
}