using System;
using System.Collections.Generic;
using System.Text;

namespace TryCatchFinally
{
    class A
    {
        public A()
        {
            Console.WriteLine("Make Obj A");
        }
    }

    class TryCatchFinallyTest
    {
        public static void Run()
        {
            try
            {
                A a = new A();
                if (a != null)
                    return;
                Console.WriteLine("try end !");
            }
            catch(Exception ex)
            {

            }
            finally
            {
                Console.WriteLine("do finally !");
            }

            Console.WriteLine("fun end !");
        }

        public static void Run1()
        {
            for(int i = 0; i < 10; ++i)
            {
                try
                {
                    A a = new A();
                    if (i == 0)
                        break;
                    Console.WriteLine("try end !");
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    Console.WriteLine("do finally !");
                }
                Console.WriteLine("for end !");
            }
            Console.WriteLine("fun end !");
        }
    }
}
