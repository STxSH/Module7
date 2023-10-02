namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.2.5

        class BaseClass
        {
            public virtual void Display()
            {
                Console.WriteLine("Метод класса BaseClass");
            }
        }

        class DerivedClass : BaseClass
        {
            public override void Display()
            {
                base.Display();
                Console.WriteLine("Метод класса DerivedClass");
            }
        }

    }
}