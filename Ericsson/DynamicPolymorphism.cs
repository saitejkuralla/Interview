using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ericsson
{
    class DynamicPolymorphism
    {
        public class BaseClass
        {
            public virtual void Show()
            {
                Console.WriteLine("Base Class");
            }
        }

        public class FirstClass : BaseClass
        {
            public override void Show()
            {
                Console.WriteLine("First Class");
            }
        }

        public class SecondClass : FirstClass
        {
            public new void Show()
            {
                Console.WriteLine("Second Class");
            }
        }

    }
}
