using System;
using System.Collections.Generic;

class Program
{
    static bool Scob(string stroka)
    {
        Stack<char> stack = new Stack<char>();
        foreach (char ch in stroka)
        {
            switch (ch)
            {
                case '{':
                case '(':
                case '[':
                    stack.Push(ch);
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{')
                        return false;
                    break;

                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(')
                        return false;
                    break;

                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[')
                        return false;
                    break;
            }
        }
        return stack.Count == 0;
    }
    static void Main()
    {
        Console.WriteLine("Введите выражение со скобками");
        string stroka = Console.ReadLine();
        bool TorF = Scob(stroka);
        if (TorF == true){
            Console.WriteLine($"Скобки в выражении: {stroka} расставлены верно");}
        else{Console.WriteLine($"Скобки в выражении: {stroka} расставлены неправильно");}
    }
}