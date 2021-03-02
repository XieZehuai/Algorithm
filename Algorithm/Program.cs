using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            A a = new B();
            a.Show();
        }
    }


    class A
    {
        public virtual void Show()
        {
            Console.WriteLine(GetType());
        }
    }

    class B : A
    {
        public override void Show()
        {
            base.Show();
        }
    }
}
