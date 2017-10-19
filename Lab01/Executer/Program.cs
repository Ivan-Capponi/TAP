using System;
using System.Reflection;
using MyAttribute;

namespace Executer
{
    public class Program
    {
        public static void Main()
        {
            Assembly assembly = Assembly.LoadFrom("../../../MyLibrary/bin/Debug/MyLibrary.dll");
            foreach (Type type in assembly.GetTypes())
                if (type.IsClass)
                {
                    MethodInfo[] methods = type.GetMethods();
                    foreach (MethodInfo singleMethod in methods)
                    {
                        object classInstance = Activator.CreateInstance(type, null);
                        ParameterInfo[] parameters = singleMethod.GetParameters();

                        if (parameters.Length == 0)
                            singleMethod.Invoke(classInstance, null);
                        else
                        {
                            ExecuteMeAttribute[] attr = (ExecuteMeAttribute[]) singleMethod.GetCustomAttributes(typeof(ExecuteMeAttribute), true);
                            foreach (ExecuteMeAttribute single in attr)
                                singleMethod.Invoke(classInstance, single.ArgsObjects);    
                        }   
                    }
                }

            Console.ReadLine();
        }
    }
}
