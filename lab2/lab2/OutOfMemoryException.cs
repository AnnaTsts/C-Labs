using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    public class MyOutOfMemoryException:MyException
    {
        public MyOutOfMemoryException()
            : base()
        { }

        public MyOutOfMemoryException(string msg)
            : base(msg)
        { }
    }
}
