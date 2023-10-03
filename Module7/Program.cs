namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.6.10

        class Car<TEngine> where TEngine : Engine
        {
            public TEngine Engine;
            public virtual void ChangePart<TPart> (TPart newPart) where TPart : CarPart
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