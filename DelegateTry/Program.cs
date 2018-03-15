using System;
using System.Threading;

namespace DelegateTry
{
    class Program
    {
        static void Main(string[] args)
        {
            Work w = new Work();
            //w.Working();

            Thread t1 = new Thread(w.Working);
            Thread t2 = new Thread(w.Working2);

            t1.Start();
            t2.Start();
        }
    }

    public class Work
    {
        Calulator cal = new Calulator();
        Sumer sum = new Sumer();
        Miner min = new Miner();
        public void Working()
        {
            cal.CalEvent += sum.Add;
            //cal.CalEvent += min.Minus;
            cal.CalCulate(1, 2);


            //CalCulate2.CalCulate cal2 = sum.Add;
            //cal2 += min.Minus;
            //cal2.Invoke(3, 4);
            Console.Read();
        }

        public void Working2()
        {
            Thread.Sleep(3000);
            cal.CalEvent -= sum.Add;
            //cal.CalEvent -= min.Minus;
        }
    }

    public class Calulator
    {
        public delegate void CalHandler(int a, int b);

        public event CalHandler CalEvent;

        public delegate void MinorHandler();
        public void CalCulate(int a, int b)
        {
            var handle = CalEvent;
            if (handle != null)
            {
                Thread.Sleep(5000);
                handle(a, b);
            }
        }
    }
    public class Sumer
    {
        public virtual void Add(int a, int b)
        {
            Console.WriteLine("sum =" + (a + b));
        }
    }

    public class Miner
    {
        public virtual void Minus(int a, int b)
        {
            Console.WriteLine("minus =" + (a - b));
        }
    }

    public class CalCulate2
    {
        public delegate void CalCulate(int a, int b);
    }
}
