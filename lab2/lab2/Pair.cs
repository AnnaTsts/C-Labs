using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    abstract class Pair
    {

        protected int hight;
        protected int small;
        public static Pair operator +(Pair A, Pair B) { return A; }
        public static Pair operator -(Pair A, Pair B) { return A; }
        public static Pair operator *(Pair A, Pair B) { return A; }
        public static Pair operator /(Pair A, Pair B) { return A; }
        public static bool operator ==(Pair A, Pair B)
            {if (A.small == B.small && A.hight == B.hight)
                return true;
            return false;
        }
        public static bool operator !=(Pair A, Pair B)
        {
            if (A.small != B.small && A.hight != B.hight)
                return true;
            return false;
        }
        public virtual String toString() { return "Общий класс"; }


        public  bool EqualstoPair(Pair A)
        {
            if (A.small == small && A.hight == hight)
                return true;
           else  return false;
        }
        
        
        public abstract Pair DeepCopy();
       
    }
}
