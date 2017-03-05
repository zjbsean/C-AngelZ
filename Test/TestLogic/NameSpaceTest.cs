using System;
using System.Collections.Generic;
using System.Text;

namespace NameSpace
{
    class A
    {
        public A()
        {
            Console.WriteLine("Test.A");
        }

        public void MakeA()
        {
            var a = new A();
        }

        //不可用
        //public void MakeB()
        //{
        //    var b = new B();
        //}

        public void MakeSubB()
        {
            var b = new Test_Sub.B();
        }
    }

    class C
    {
        public C()
        {
            Console.WriteLine("Test.C");
        }
    }

    namespace Test_Sub
    {
        class A
        {
            public A()
            {
                Console.WriteLine("Test.Test_Sub.A");
            }
        }

        class B
        {
            public B()
            {
                Console.WriteLine("Test.Test_Sub.B");
            }

            public void MakeSubA()
            {
                var a = new A();
            }

            public void MakeA()
            {
                var a = new NameSpace.A();
            }

            public void MakeC()
            {
                var c = new C();
            }
        }
    }
 
    class NameSpaceTest
    {
        public static void Run()
        {
            var b = new Test_Sub.B();
            b.MakeA();
            b.MakeSubA();
            b.MakeC();
        }
    }
}
