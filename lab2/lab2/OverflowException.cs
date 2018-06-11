using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    class MyOverflowException:MyException
    {
        public MyOverflowException()
            : base()
        { }

        public MyOverflowException(string msg)
            : base(msg)
        { }
    }
}
