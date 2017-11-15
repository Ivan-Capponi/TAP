using System;
using System.Reflection;
using MyAttribute;

namespace Executer
{
    public class Executer
    {
        public static void Main()
        {
            //Carico l'assembly.
            Assembly assembly = Assembly.LoadFrom("../../../MyLibrary/bin/Debug/MyLibrary.dll");

            //Per ogni classe dell'assembly controllo se esiste un costruttore
            //di default, se sì chiamo il metodo DefaultConstructor, altrimenti
            //chiamo il metodo NonDefaultConstructor.
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

            //Provo ad assegnare un oggetto al reference "classInstance"
            //per il tipo classe passato come argomento. In caso di fallimento
            //non viene propagata alcuna eccezione.
            try { classInstance = Activator.CreateInstance(type, null); }
            catch (MissingMethodException) { return; }

            //Chiamo il metodo InvokeMethods per chiamare tutti i metodi della classe
            //contrassegnati da un apposito attributo
            InvokeMethods(type, classInstance);
        }

        private static void NonDefaultConstructor(Type type)
        {
            //Ottengo l'array contenente tutti i costruttori della classe
            ConstructorInfo[] constructors = type.GetConstructors();

            //Per ogni costruttore ottento un array contenete la lista dei suoi attributi e,
            //per ogni attributo di tipo "NonDefaultConstructorAttribute", provo a creare un
            //oggetto passando come parametri quelli contrassegnati dall'attributo stesso.
            //Invoco, infine, il metodo InvokeMethods per chiamare tutti i metodi dell'oggetto
            //creato contrassegnati da un apposito attributo
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
            //Per ogni metodo della classe in analisi ottengo un array contenente
            //i suoi parametri. Se il metodo non ha parametri lo chiamo immediatamente,
            //altrimenti ottengo un array di tutti gli attributi di tipo "ExecuteMeAttribute"
            //ad esso associato e chiamo il metodo passandogli i relativi parametri.
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

            //Controllo, per ogni costruttore della classe in analisi,
            //se vi sia un costruttore di default. In caso positivo setto
            //la variabile booleana defaultFlag a true.
            foreach (ConstructorInfo singleConstructor in constructors)
            {
                if (singleConstructor.GetParameters().Length == 0)
                    defaultFlag = true;
            }

            //Il metodo resistuisce true se e solo se la classe in analisi ha
            //un costruttore di default.
            return defaultFlag;
        }
    }
}