namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.2.12

        class Obj
        {
            public int Value;

            public static Obj operator + (Obj a, Obj b)
            {
                return new Obj
                {
                    Value = a.Value + b.Value
                };
            }
            public static Obj operator - (Obj a,  Obj b)
            {
                return new Obj
                {
                    Value = a.Value - b.Value
                };
            }
        }

    }
}