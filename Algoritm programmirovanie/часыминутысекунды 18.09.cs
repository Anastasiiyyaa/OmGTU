using System;
class HelloWorld {
static void Main() {
int k = 0;
k = Convert.ToInt32(Console.ReadLine());
int f,g, h, m, n, s;
h = k/3600;
m =(k-h*3600) /60;
s = k - (h*3600 + m*60);




Console.WriteLine(h);
Console.WriteLine(m);
Console.WriteLine(s);

}
}