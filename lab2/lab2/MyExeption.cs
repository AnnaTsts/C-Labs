using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab2
{
    public class MyException:Exception
    {
     public   MyException()
        { Console.WriteLine("Что-то пошло не так :( "); }
     public   MyException(string msg)
        { Console.WriteLine(msg); }

    }
}
