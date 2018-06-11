using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
   public class MyInvalidCastException:MyException
    {
        public MyInvalidCastException()
            : base()
        { }

        public MyInvalidCastException(string msg)
            : base(msg)
        { }

    }
}
