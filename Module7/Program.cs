namespace Module7
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        //task 7.1.6

        class Obj
        {
            private string name;
            private string owner;
            private int length;
            private int count;

            public Obj(string name, string ownerName, int objLength, int count)
            {
                this.name = name;
                owner = ownerName;
                length = objLength;
                this.count = count;
            }
        }
    }
}