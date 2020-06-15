using System;

namespace _01ArrayList
{
    class Program
    {
        static void Main(string[] args)
        {
            LoopArrayList l = new LoopArrayList();
            for (int i = 1; i < 11; i++)
            {
                l.Add(i);
            }
            Console.WriteLine(l.ToString());
            Console.WriteLine(l.CurrentValue);
            l.RemoveCurrNode();
            Console.WriteLine(l.CurrentValue);
            Console.WriteLine(l.ToString());
            l.Move(4);
            Console.WriteLine(l.CurrentValue);
            Console.WriteLine(l.ToString());
        }
    }

}
