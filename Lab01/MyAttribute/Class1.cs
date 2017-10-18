using System;

namespace MyAttribute
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ExecuteMeAttribute : Attribute
    {
        public object[] ArgsObjects { get; }

        public ExecuteMeAttribute(params Object[] argsObjects)
        {
            ArgsObjects = argsObjects;
        }
    }
}