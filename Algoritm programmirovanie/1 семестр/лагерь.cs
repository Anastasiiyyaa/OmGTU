using System;
using System.Linq;
using System.Collections;
namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            float speed = GetFloat("Скорость км/ч: ") * 1000 / 60;
            int number = (int)GetFloat("Количество пунктов: ");
            float[] m = new float[number + 1];
            m[0] = 0;

            for (int i = 1; i <= number; i++)
                m[i] = GetFloat("Расстояние км: ") * 1000; 

            float startHour = GetFloat("Часы восхода: ");
            float startMinutes = GetFloat("Минуты восхода: ");
            float endHour = GetFloat("Часы заката: ");
            float endMinutes = GetFloat("Минуты захода: ");

            startMinutes += startHour * 60;
            endMinutes += endHour * 60;

            float dayTime = endMinutes - startMinutes;

            float thisDay = dayTime;
            int days = 1;
            int[] stop = new int[number];
            int index = 0;

            for (int i = 1; i <= number; i++)
            {
                if (thisDay <= (m[i] - m[i - 1]) / speed)
                {
                    stop[index++] = i - 1;
                    days += 1;
                    thisDay = dayTime - (m[i] - m[i - 1]) / speed;
                }
                else
                {
                    thisDay -= (m[i] - m[i - 1]) / speed;
                }

            }

            foreach (var e in stop)
                Console.Write(e + " ");
            Console.WriteLine("\n " + days + " дней");
            Console.ReadLine();
        }

        public static float GetFloat(string prompt)
        {
            Console.Write(prompt);
            return float.Parse(Console.ReadLine());
        }
    }

}
    
    