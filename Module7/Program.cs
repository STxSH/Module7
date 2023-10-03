namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.6.9

        class Car<T> where T : Engine
        {
            public T Engine;
            public virtual void ChangePart<T2> (T2 newPart) where T2 : CarPart
            {

            }
        }
        class Engine { }

        class CarPart { }

        class ElectricEngine : Engine { }

        class GasEngine : Engine { }

        class Battery : CarPart { }

        class Differencial : CarPart { }

        class Wheel :CarPart { }
    } 
}