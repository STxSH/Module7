namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.5.3

        class Helper
        {
            public static void Swap (ref int i, ref int j)
            {
                int temp = i;
                i = j;
                j = temp;
            }
        }
    }
}