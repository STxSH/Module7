namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.2.4

        class BaseClass
        {
            public virtual int Counter
            {
                get;
                set;
            }
        }

        class DerivedClass : BaseClass
        {
            private int counter;
            public override int Counter
            {
                get
                {
                    return counter;
                }
                set
                {
                    if (value < 0)
                    {
                        Console.WriteLine("Число меньше 0");
                    }
                    else
                    {
                        counter = value;
                    }
                }
            }
        }

    }
}