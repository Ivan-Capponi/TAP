using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private readonly Dictionary<Type, Type> _typeAssociation = new Dictionary<Type, Type>();

        public InterfaceResolver(String filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException("Il file specificato non esiste");
            string[] fileLines = File.ReadAllLines(filePath);
            foreach (string line in fileLines)
            {
                if (line[0] == '#' || line == String.Empty)
                    continue;
                string[] splitted = line.Split('*');
                if (splitted.Length != 4) continue;
                if (splitted[0].EndsWith(".dll") && File.Exists(splitted[0]) && File.Exists(splitted[2]) && (splitted[2].EndsWith(".dll") || splitted[2].EndsWith(".exe")))
                {
                    Assembly interfaceDll = Assembly.LoadFrom(splitted[0]);
                    Assembly classDll = Assembly.LoadFrom(splitted[2]);
                    foreach (Type t in interfaceDll.GetTypes())
                        if (t.IsInterface && t.FullName == splitted[1])
                            foreach (Type impl in classDll.GetTypes())
                                if (impl.IsClass && t.IsAssignableFrom(impl))
                                    _typeAssociation.Add(t, impl);
                }
            }
        }

        public T Instantiate<T>() where T : class
        {
            Type t = _typeAssociation[typeof(T)];
            return (T) Activator.CreateInstance(t);
        }
    }
}
