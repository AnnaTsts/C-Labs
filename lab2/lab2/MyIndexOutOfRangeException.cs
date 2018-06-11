using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    public class MyIndexOutOfRangeException:Exception
    {
        public MyIndexOutOfRangeException()
            : base()
        { }

        public MyIndexOutOfRangeException(string msg)
            : base(msg)
        { }
    }
}
