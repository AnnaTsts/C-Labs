using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class Fractional:Pair
    {
       // int hight;
       // int small;

      public  Fractional(int h, int s)
        {
            if (s == 0)
                throw (new DivideByZeroException());
            if (h < 0 && s < 0)
            {
                h = Math.Abs(h);
                s = Math.Abs(s);
            }
            else if (s < 0)
            {
                h = (-h);
                s = Math.Abs(s);
            }
            hight = h;
            small = s;
            
            ReduceFraction();
        }

       public Fractional(int n)
        { hight = n;
            small = 1;
        }

      public  Fractional()
        { hight = 1;
            small = 1;
        }

          public static Fractional operator +(Fractional A, Fractional B)
          { Fractional Result = new Fractional();

            Result.small = A.small * B.small;
            Result.hight = (A.hight * B.small) + (B.hight * A.small);
            Result.ReduceFraction();

            return Result;
        }


        public static Fractional operator -(Fractional A, Fractional B)
        {
            Fractional Result = new Fractional();

            Result.small = A.small * B.small;
            Result.hight = (A.hight * B.small) -  (B.hight * A.small);
            Result.ReduceFraction();

            return Result;
        }


        public static Fractional operator *(Fractional A, Fractional B)
        {
            Fractional Result = new Fractional();

            Result.small = A.small * B.small;
            Result.hight = (A.hight *B.hight);
            Result.ReduceFraction();

            return Result;
        }

        public static Fractional operator /(Fractional A, Fractional B)
        {

            bool isPlusA = A.hight > 0 ? true : false;
            bool isPlusB = B.hight > 0 ? true : false;

            A.hight = Math.Abs(A.hight);
            B.hight = Math.Abs(B.hight);

            Fractional Result = new Fractional();

            
            Result.hight = (A.hight * B.small);
            Result.small = A.small * B.hight;

            if (isPlusA != isPlusB)
            { Result.hight = -Result.hight; }

            Result.ReduceFraction();

            return Result;
        }


        public int CommonDivisor(int a, int b)
        {
            while (b != 0)
            { int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public void ReduceFraction()
        {
            int Divisor = CommonDivisor(hight, small);
            if (Divisor != -1)
            {
                hight = hight / Divisor;
                small = small / Divisor;
            }
        }

        public override String toString()
        { String s = hight + "/" + small;
            return s;
        }

        public override Pair DeepCopy()
        { return new Fractional(hight, small); }

        public bool EqualstoPair(Fractional A)
        {
            
            if (A.small == small && A.hight == hight)
                return true;
            else return false;
        }

        public bool EqualstoPair(LongLong A)
        { return false; }
    }
}
