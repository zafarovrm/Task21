using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Task21
{
    class Program
    {
        static int a,b;
        static int[,] site;        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите значени a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите значени b");
            b = Convert.ToInt32(Console.ReadLine());

            site = new int[a, b];

            Thread gardener1 = new Thread(Gardener1);
            Thread gardener2 = new Thread(Gardener2);

            gardener1.Start();
            gardener2.Start();
            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(site[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
        static void Gardener1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (site[i, j] == 0)
                        site[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }
        static void Gardener2()
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (site[j, i] == 0)
                        site[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}

