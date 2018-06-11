using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    public class MyDivideByZeroException : MyException
    {
        public MyDivideByZeroException()
            : base()
        { }

        public MyDivideByZeroException(string msg)
            : base(msg)
        { }


    }
}
