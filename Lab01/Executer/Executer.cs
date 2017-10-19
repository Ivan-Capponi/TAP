using System;
using System.Reflection;
using MyAttribute;

namespace Executer
{
    public class Executer
    {
        public static void Main()
        {
            Assembly assembly = Assembly.LoadFrom("../../../MyLibrary/bin/Debug/MyLibrary.dll");
            foreach (Type type in assembly.GetTypes())
                if (type.IsClass)
                {
                    if (HasDefaultConstructor(type.GetConstructors()))
                        DefaultConstructor(type);
                    else
                        NonDefaultConstructor(type);
                }

            Console.ReadLine();
        }

        private static void DefaultConstructor(Type type)
        {
            object classInstance;
            try { classInstance = Activator.CreateInstance(type, null); }
            catch (MissingMethodException) { return; }
            InvokeMethods(type, classInstance);
        }

        private static void NonDefaultConstructor(Type type)
        {
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo singleConstructor in constructors)
            {
                NonDefaultConstructorAttribute[] attributes = (NonDefaultConstructorAttribute[])singleConstructor.GetCustomAttributes(typeof(NonDefaultConstructorAttribute), true);
                foreach (NonDefaultConstructorAttribute singleAttribute in attributes)
                {
                    object classInstance;
                    try { classInstance = Activator.CreateInstance(type, singleAttribute.ArgsObjects); }
                    catch (MissingMethodException) { return; }
                    InvokeMethods(type, classInstance);
                }
            }
        }

        private static void InvokeMethods(Type type, object classInstance)
        {
            foreach (MethodInfo singleMethod in type.GetMethods())
            {
                ParameterInfo[] parameters = singleMethod.GetParameters();
                if (parameters.Length == 0)
                    try { singleMethod.Invoke(classInstance, null); }
                    catch (ArgumentException) { Console.WriteLine("Failed: {0}", singleMethod.Name); }
                else
                {
                    ExecuteMeAttribute[] attr = (ExecuteMeAttribute[]) singleMethod.GetCustomAttributes(typeof(ExecuteMeAttribute), true);
                    foreach (ExecuteMeAttribute single in attr)
                        try { singleMethod.Invoke(classInstance, single.ArgsObjects); }
                        catch (ArgumentException) { Console.WriteLine("Failed: {0}", singleMethod.Name); }
                }
            }
        }

        private static bool HasDefaultConstructor(ConstructorInfo[] constructors)
        {
            Boolean defaultFlag = false;
            foreach (ConstructorInfo singleConstructor in constructors)
            {
                if (singleConstructor.GetParameters().Length == 0)
                    defaultFlag = true;
            }
            return defaultFlag;
        }
    }
}