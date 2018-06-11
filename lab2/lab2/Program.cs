using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Лабораторна робота 2 ";
           LongLong Test = new LongLong(-44,34223);
            LongLong Test2 = new LongLong(0,4);
            Console.WriteLine(Test.toString());
            Console.WriteLine(Test2.toString());

            Console.WriteLine((Test *Test2).toString());

            Fractional A = new Fractional(-3, 8);
            Fractional B = new Fractional(-2, 5);
            Fractional C = new Fractional(-3, 5);
            Console.WriteLine(C.toString());


             Series Testing = new Series(Test);
            Console.WriteLine(Testing.toString());
            Testing.Add(Test2);
            Testing.Add(B);
            Testing.Add(C);
            Console.WriteLine(Testing.toString());
            Console.WriteLine("Поменяем 1 элемент");
            Testing.Change(1);
            Console.WriteLine(Testing.toString());
            Testing.Remove(Test);
            Console.WriteLine(Testing.toString());
            Console.WriteLine("Найдем индекс " + B.toString());
            Console.WriteLine(Testing.GetId(B));

            Console.WriteLine("Добавим к массиву сумму,разницу,результат деления и умножения чисел "+A.toString()+" "+B.toString());
            Testing.Add(A+B);
            Testing.Add(A-B);
            Testing.Add(A/B);
            Testing.Add(A * B);

            LongLong A2 =new  LongLong(2,644569924);
            LongLong B2 =new LongLong (0, 84399477);
            Console.WriteLine("Добавим к массиву сумму,разницу,результат деления и умножения чисел " + A2.toString() + " " + B2.toString());
           // Testing.Add(A2 + B2);
           // Testing.Add(A2 - B2);
           
           
             Testing.Add(A2 + B2);
             Testing.Add(A2 - B2); 
            Testing.Add(A2 / B2);
            Testing.Add(A2 * B2);


            Console.ReadKey();

        }

        static void show(string message)
        { Console.WriteLine(message); }
    }
}
