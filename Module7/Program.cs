namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.5.9
        //
    }

    static class IntExtensions
    {
        public static int GetNegative(this int number)
        {
            if (number > 0)
            {
                return -number;
            }
            else
            {
                return number;
            }
        }
        public static int GetPositive(this int number)
        {
            if (number < 0)
            {
                return -number;
            }
            else
            {
                return number;
            }
        }
    }
}