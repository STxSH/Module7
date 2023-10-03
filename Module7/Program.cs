namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.6.7

        class Car<T>
        {
            public T Engine;
            public virtual void ChangePart<T2> (T2 newPart)
            {

            }
        }

        class ElectricEngine { }

        class GasEngine { }

        class Battery { }

        class Differencial { }

        class Wheel { }
    } 
}