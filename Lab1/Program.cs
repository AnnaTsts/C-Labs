using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    /*
     * 
     * В поселке с N домами, которые расположены вдоль прямой дороги с одной стороны на равных расстояниях,
     * прокладывают телефонную связь. Известно, сколько телефонных аппаратов необходимо установить в
     * каждом доме. Каждый из телефонов должен быть соединен с АТС отдельным кабелем. 
     * Определить, в каком доме не обходимо установить АТС, для того чтобы суммарная длина кабеля была минимальной.
     Я невнимательно прочитала условие поэтому сделала и для улицы с домами на разных сторонах дороги
  */
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Matrix Test;

            float d, h;
            int decision;
          
            try
            {
                Console.WriteLine("Желаете ввести количество домов на улице(1-да/2-нет)");
                decision = Convert.ToInt32(Console.ReadLine());
                if (decision != 1 && decision != 2)
                    throw (new Exception());
            }
            catch (Exception e)
            {
                Console.WriteLine("Вы ввели некоректное значение,поэтому количество будет сгенерировано автоматически");
                decision = 2;
            }

            if (decision == 1)
            { Console.WriteLine("Введите количество домов");
              int  n = Convert.ToInt32(Console.ReadLine());
                Test = new Matrix(n);
            }
            else
                Test = new Matrix(5);
            Test.Menu();
           
            //Test.print();
           // Test.GetNumber();
            Console.WriteLine();
          //  Test.print2();
            Console.WriteLine("***************************************");
            Console.WriteLine("Количество точек доступа");
            Test.print2();
            Console.WriteLine();
            Console.WriteLine("Длинна кабеля для соеденения");
            Test.print();
            Console.WriteLine();
            Console.WriteLine("Дом с минимальной затратой кабеля "+Test.FindNumberOfHouse());

            System.Threading.Thread.Sleep(300000);
        }
    }

   public class Matrix
    {
        float[,] Distance;
        int n = 10;
        int[] Number;

        //если пользователь не захотел вводить количество домов ,взять n=10
       public Matrix()
        {Distance = new float[n,n];
            Number = new int[n];
        }
        
        //создать количество домов указаное пользователем
       public Matrix(int n)
        {Distance = new float[n,n];
            Number = new int[n]; 
            this.n = n;
        }

        public void GetArrayforOneSide(float d)
        {
           //вседомана одной стороне 1-2-3-4 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    Distance[i, j] = d * (i - j);
                    Distance[j, i] = Distance[i, j];
                }
            }
        }


       public void GetArray(float h,float d)
        
        {
            //вид улицы
         //     1 -  3 -  5  
         //     ===========
         //     2 -  4  - 6

            for (int i = 0; i < n ; i++)
            {
                for (int j=0;j<i;j++)
                {

                    if (i % 2 == j % 2) //заполнение растояния между домами по одну сторону улицы
                    {
                        Distance[i, j] = d * ((int)((i - j) / 2));
                        Distance[j, i] = Distance[i, j];
                    }
                    else if (i == j - 1 && (i % 2) == 1)    //заполнение растояния между домами напротив друг друга
                    {
                        Distance[i, j] = h;
                        Distance[j, i] = h;
                    }
                    //заполнение растояния между домами по диагонали
                    else if ((i % 2) == 1)
                    {
                        Distance[i, j] = FindHypotenuse(Distance[j, i - 1], h);
                        Distance[j, i] = Distance[i, j];
                    }
                    else {
                        Distance[i, j] = FindHypotenuse(Distance[i,j-1],h);
                        Distance[j, i] = Distance[i, j];
                    }
            }
    }
}
        //функция нахождения гипотенузы по двум сторонам
        public float FindHypotenuse(float a,float b)
        {
            double c = (double)(b * b) + (a * a);
            return (float)Math.Sqrt(c);
        }

        //ввод количества точек доступу
        public void GetNumber()
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите нужное количество точек доступа в " + (i+1)  + " доме" );
                string str = Console.ReadLine();
                int num = Convert.ToInt32(str);
                Number[i] = num;
            }
        }

        //выбор случайным образом количества точек доступу
        public void GetRandomNumber()
        {
            Random rand = new Random();
            for (int i = 0; i < n; i++)
            {
                Number[i] = rand.Next(5);
            }
        }

        //выводномера дома к которому стоит прокладывать все маршруты
        public int FindNumberOfHouse()
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                { Distance[i, j] = Distance[i, j] * Number[i]; }
            }

            float[] ResultMeters = new float[n];    //результирующая матрица - в которой каждую строку умножаем на количество точек доступа
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                { ResultMeters[j] += Distance[i, j]; }      //результующий подсчет кабеля ,который берется по суме всех значений в столбце
            }

            Console.WriteLine();
            Console.WriteLine("Результирующие количество кабеля с учетом точек доступа");
            print();
 
            Console.WriteLine("***************************************");
            for (int i = 0; i < n; i++)
                Console.Write(ResultMeters[i] + "    ");
            return FindMinIndex(ResultMeters) + 1;
        }

        //нахождение минимального значения в массиве
        private int FindMinIndex(float[] arr) 
        {
            float min = arr[0];
            int index = 0;
            for (int i = 1; i < arr.Length; i++)
            { if (arr[i] < min)
                {
                    min = arr[i];
                    index = i;
                }
            }
            return index;
        }

        //выведение длинны кабеля
       public void print()
        {for (int i = 0; i < n; i++)
            { Console.WriteLine();
                for (int j = 0; j < n; j++)
                    Console.Write(String.Format("{0,10:0.0}",Distance[i, j]));
            }
        }
        //выведение количества точек доступа
        public void print2()
        {

                for (int j = 0; j < n; j++)
                    Console.Write(Number[j] + " ");
            
        }

        public void Menu()
        {
            float h, d;
            int decision;
            int typeOf;
            typeOf = GetDecision("На одной стороне улицы(1-да/2-нет)");
          
            decision = GetDecision("Желаете ввести растояния между домами(1-да/2-нет)");
            if (typeOf == 2)
            {
           
                if (decision == 1)
                {
                    Console.WriteLine("Введите растояние между домами через улицу по прямой");
                    h = (float)Convert.ToDouble(Console.ReadLine());

                    Console.WriteLine("Введите растояние между домами по соседству");
                    d = (float)Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    d = 4;
                    h = 3;
                }
                GetArray(h, d);
            }
            else
            {
       
                if (decision == 1)
                {
                
                    Console.WriteLine("Введите растояние между домами по соседству");
                    d = (float)Convert.ToDouble(Console.ReadLine());
                }
                else
                {
                    d = 4;
                }
                GetArrayforOneSide(d);
            }
            decision = GetDecision("Желаете ввести количество точек доступа в каждом дома на улице(1-да/2-нет)");

            if (decision == 1)
            { GetNumber(); }
            else GetRandomNumber();
        }

        public int GetDecision(String S)
        {
            int decision = 1;
            try
            {
                Console.WriteLine(S);
                decision = Convert.ToInt32(Console.ReadLine());
                if (decision != 1 && decision != 2)
                    throw (new Exception());
            }
            catch (Exception e)
            {
                Console.WriteLine("Вы ввели некоректное значение,поэтому количество будет сгенерировано автоматически");
                decision = 2;
            }
            return decision;
        }

    }

    

}
