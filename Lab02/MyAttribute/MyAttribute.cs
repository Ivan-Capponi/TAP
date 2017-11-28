using System;

namespace MyAttribute
{
    public class MyAttribute : Attribute
    {
        public object[] Args { get; }

        public MyAttribute(params object[] args)
        {
            Args = args;
        }
    }
}
