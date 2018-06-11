 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace lab2
{
 
    class LongLong:Pair
    {
        const int miliard = 1000000000;
         int thebigerNumberOfInt = 2147483647;
       // int hight;
      //  int small;

        public LongLong()
        {
          hight =0;
          small = 0;
        }
        public LongLong(int hight, int small)
        {
            this.hight = hight;

            if (small < miliard)
                this.small = small;
            else
            { this.small = small%miliard;
                this.hight += (int)(small/miliard);
            }
            if (this.small < 0&&hight!=0)
                this.small = -this.small;
        }
        public LongLong(int n)
        { hight = n;

            if (n < miliard)
                small = n;
            else
            {
                small = n % miliard;
                hight += (int)(n / miliard);
            }
                if (small < 0)
                    small = -small;
            
            
        }

        public LongLong addPlusPlus(LongLong A)
        {
            LongLong Result = new LongLong();
            int plusToHightPart=0;
            int s = this.small + A.small; //сума меньших частей
            int h = this.hight + A.hight; //сума больших частей

            if (s< miliard)
                Result.small = s;
            else
            { plusToHightPart=(int)(s / miliard);   //количествомилиардов добавить к большей части чтобы не было переполнения
                Result.small =s % miliard;
            }


            if (h + plusToHightPart < thebigerNumberOfInt)
            { Result.hight = h + plusToHightPart; }
            else
            {
                throw new MyOutOfMemoryException();

            }
            return Result;
        }

        public LongLong addPlusMinus(LongLong A)  //если добавляем числа разных знаков
        {


            LongLong Result = new LongLong();
            Result.hight = this.hight + A.hight;
            if (Result.hight > 0)
            {
                if (this.small > A.small)
                    Result.small = this.small - A.small;
                else
                {
                    Result.hight -= 1;
                    Result.small = this.small - A.small + miliard;
                }
            }

            else {
                if (A.small > this.small)
                    Result.small = A.small - this.small;
                else
                { Result.small = A.small - this.small + miliard;
                    Result.hight += 1;
                }

            }
            return Result;
        }

        public override String  toString()
        {
            String Str;
            if (hight != 0)
            {
                Str = hight.ToString() + ' ';
            }
            else Str = small > 0 ? "+" : "-"+"0 ";
            for (int i = miliard / 10; i > 1; i = i / 10)
                {
                    if ((int)(small / i) == 0)
                        Str += '0';
                    else break;
                }
                Str +=small>0? small.ToString():((-small).ToString());
            
           
            return Str;
        }

        public LongLong addHightIsNULL(LongLong A)  //если добавляем числа разных знаков
        {

            LongLong Result = new LongLong();
            if (this.hight != 0)
            {
                Result.hight = this.hight;
                if (this.hight > 0 && A.small > 0 || this.hight > 0 && A.small < 0)
                    Result.small = this.small + A.small;
                else
                    Result.small = this.small - A.small;
            }
            else if (A.hight != 0)
            {
                Result.hight = A.hight;
                if (A.hight > 0 && this.small > 0 || A.hight > 0 && this.small < 0)
                    Result.small = this.small + A.small;
                else
                    Result.small = A.small - this.small;
            }
            else {

                Result.small = this.small + A.small;

            }

            if (Result.small < 0 && Result.hight > 0)
            {

                Result.hight = -1;
                Result.small += miliard;
            }
            else if (Result.small < -miliard && Result.hight < 0)
            {

                Result.hight = -1;
                Result.small += miliard;
            }
            else if (Result.hight == 0)
            {

                if (Result.small > miliard)
                {
                    Result.hight = 1;
                    Result.small -=miliard;
                }
                else if(Result.small<-miliard)
                { Result.hight =- 1;
                    Result.small += miliard;
                }
            }
            return Result;

        }

        public static LongLong  operator +(LongLong A, LongLong B)
        {   if (A.hight == 0 || B.hight == 0)
               return A.addHightIsNULL(B);
            else if ((B.hight > 0 && A.hight > 0) ||
                (B.hight < 0 && A.hight < 0))
                return A.addPlusPlus(B);
            else if (A.hight > 0) return A.addPlusMinus(B);
            else return B.addPlusMinus(A);
        }

        public static LongLong operator -(LongLong A, LongLong B)
        {
            LongLong C = new LongLong((-B.hight), (-B.small));

            return (A + C);
        }

        public static LongLong operator /(LongLong A, LongLong B)
        {
            LongLong Result = new LongLong();

            bool plusA = A.isPlus();
            bool plusB = B.isPlus();

            Console.WriteLine(B.toString());

            A.hight = Math.Abs(A.hight);
            A.small = Math.Abs(A.small);
            B.hight = Math.Abs(B.hight);
            B.small = Math.Abs(B.small);

            if (Math.Abs(A.hight) < Math.Abs( B.hight))
            {
           
                return Result;
            }
            else
            {
                if (B.hight != 0)
                {

                    Result.small= (int)A.hight / B.hight;
                    int FloatPart = A.hight % B.hight;
                    if (FloatPart > A.hight / 2 && FloatPart > 0)
                        Result.small++;
                    else if (Math.Abs(FloatPart) > Math.Abs(A.hight / 2))
                        Result.small--;
                }
                else if (B.hight == 0 && B.small != 0)
                {
                    Result.hight = A.hight / B.small;
                    Result.small = A.small / B.small;
                }
                else
                {
                    throw new MyDivideByZeroException();
                }

                if (plusA != plusB)
                {
                    if (Result.hight != 0)
                        Result.hight = -Result.hight;
                    else Result.small = -Result.small;
                }
                return Result;
            }
        }

        public static LongLong operator *(LongLong A, LongLong B)
        {

            bool isPlusA, isplusB;
            isPlusA = A.isPlus();
            isplusB = B.isPlus();

            A.hight = Math.Abs(A.hight);
            A.small = Math.Abs(A.small);
            B.hight = Math.Abs(B.hight);
            B.small = Math.Abs(B.small);




            LongLong Result = new LongLong();
            Result.hight = (int)(A.small * B.small) / miliard;
            Result.small = (A.small * B.small) % miliard;
            
            if (A.hight != 0 && B.hight != 0)
            {
                throw new MyOutOfMemoryException();
            }
            
            else if (A.hight != 0)
            {
                
                if ((A.hight * B.small)+Result.hight < A.thebigerNumberOfInt)
                    Result.hight += A.hight * B.small;
                else
                {
                    throw new MyOutOfMemoryException();
                }
            }
            else if (B.hight != 0)
            {

                if ((B.hight * A.small) + Result.hight < A.thebigerNumberOfInt)
                    Result.hight += A.hight * B.small;
                else
                {
                    throw new MyOutOfMemoryException();
                }
            }

            if (isPlusA != isplusB)
            { if (Result.hight != 0)
                    Result.hight = -Result.hight;
                else
                    Result.small = -Result.small;
            }

            return Result;
        }

        public bool EqualstoPair(LongLong A)
        {

            if (A.small == small && A.hight == hight)
                return true;
            else return false;
        }

        public bool EqualstoPair(Fractional A)
        { return false; }



        bool isPlus()
        {

            if (hight == 0)
            { return small > 0 ? true : false; }
            else return hight > 0 ? true : false;
         
        }

        public override Pair  DeepCopy()
        {
            LongLong k= new LongLong(hight, small);
            return (k); }

    }
}

