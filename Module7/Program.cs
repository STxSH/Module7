namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.5.5
        class Obj
        {
            public string Name;
            public string Description;

            public static string Parent;
            public static int DaysInWeek;
            public static int MaxValue;

            static Obj ()
            {
                Parent = "System.Object";
                DaysInWeek = 7;
                MaxValue = 2000;
            }        
        }
    }
}