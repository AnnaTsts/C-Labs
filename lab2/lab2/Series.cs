using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Series
    {

        Pair[] Arr;
        public delegate void SeriesStatus(string message);
        public event SeriesStatus Added;
        public event SeriesStatus Removed;
        public event SeriesStatus Changed;


        public Series(Pair n)
        {
            Listen Test = new Listen(this);
            Arr = new Pair[1];
            Arr[0] = n.DeepCopy();
        }


        public Series(Pair[] A)
        {
            Listen Test = new Listen(this);
            DeepCopy(A);
        }

        public void Add(Pair A)
        {

            Pair[] Cur = new Pair[Arr.Length + 1];
            for (int i = 0; i < Arr.Length; i++)
            {
                Cur[i] = Arr[i].DeepCopy();
            }
            Cur[Arr.Length] = A.DeepCopy();
            Arr = Cur;
            if (Added != null)
            { Added("Добавлен элемент " + A.toString()); }
        }


        public void Remove(Pair A)
        {
            int l;
            Pair[] Cur = new Pair[Arr.Length-1];
            try
            {
                 l = GetId(A)-1;
            }
            catch (MyIndexOutOfRangeException) { return; }
            for (int i = 0; i < l; i++)
            { Cur[i] = Arr[i].DeepCopy(); }

            for (int i = l; i < Arr.Length-1; i++)
            { Cur[i] = Arr[i+1].DeepCopy(); }

            DeepCopy(Cur);
            // int i;
           
            
            if (Removed != null)
            { Removed("Удален элемент" + A.toString()); }

        }

        public int GetId(Pair A)
        {
            for (int i = 0; i < Arr.Length; i++)
                if (Arr[i].EqualstoPair(A))
                    return i+1;
            throw new MyIndexOutOfRangeException();
            //return 999;

        }


         public void Change(int index)
         {
            
            Console.WriteLine("Хотите ввести дробь(1-да/0-нет)");
            int d = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("На какое значение поменять введите большую часть");
            int h = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("На какое значение поменять введите меньшую часть");
            int s= Convert.ToInt32(Console.ReadLine());

            
            {
                if (index < Arr.Length)
                {
                    Changed("Элемент под номером " + (index + 1) + " заменен на элемент со значениями " + h + " " + s);
                    if (d == 1)
                    { Arr[index] = new Fractional(h, s); }
                    else
                    { Arr[index] = new LongLong(h, s); }

                }

                else throw new MyIndexOutOfRangeException("Нет элемента с таким индексом")   ;
            }
            
        }

        public string toString()
        {
            String Str = "";
            for (int i = 0; i < Arr.Length; i++)
            { Str += Arr[i].toString();
                Str += "    ";
            }
            return Str;
        }


        public class Listen
        {
           public Listen(Series Testing) { 
            Testing.Added += show;
            Testing.Changed += show;
            Testing.Removed += show;}
            static void show(string message)
            { Console.WriteLine(message); }
        }


        public void DeepCopy(Pair[] A)
        {
            Arr = new Pair[A.Length];
            for (int i = 0; i < A.Length; i++)
                Arr[i] = A[i].DeepCopy();

        }
    }


}
