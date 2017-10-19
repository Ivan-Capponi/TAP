using System;
using MyAttribute;

namespace MyLibrary
{
    public class Foo
    {
        [ExecuteMe]
        public void M1()
        {
            Console.WriteLine("M1");
        }

        [ExecuteMe(45)]
        [ExecuteMe(0)]
        [ExecuteMe(3)]
        public void M2(int a)
        {
            Console.WriteLine("M2 a={0}", a);
        }

        [ExecuteMe("hello", "reflection")]
        public void M3(string s1, string s2)
        {
            Console.WriteLine("M3 s1={0} s2={1}", s1, s2);
        }

        [ExecuteMe()]
        public void M4()
        {
            Console.WriteLine("M4");
        }
    }

    public class Foo2
    {
        public Boolean Flag { get; }

        [NonDefaultConstructor(true)]
        public Foo2(Boolean flag)
        {
            Flag = flag;
        }

        [ExecuteMe()]
        public void M5()
        {
            Console.WriteLine("M5");
        }
    }

    public class Foo3
    {
        [ExecuteMe()]
        public void M6()
        {
            Console.WriteLine("M6");
        }
    }

    public class Foo4
    {
        [ExecuteMe("tre")]
        public void M7(int a)
        {
            Console.WriteLine("M7 a={0}", a);
        }

        [ExecuteMe()]
        public void M1024()
        {
            Console.WriteLine("M1024");
        }
    }
}