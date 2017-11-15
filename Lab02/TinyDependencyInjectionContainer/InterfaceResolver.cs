using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace TinyDependencyInjectionContainer
{
    public class InterfaceResolver
    {
        private readonly Dictionary<Type, Type> _typeAssociation = new Dictionary<Type, Type>();

        //Unico costruttore della classe.
        public InterfaceResolver(String filePath)
        {
            //Se il file passato come argomento non esiste notifico il chiamante sollevando un'eccezione.
            if (!File.Exists(filePath))
                throw new ArgumentException("Il file specificato non esiste");

            //Prendo tutte le righe del file letto e le metto in un array di stringhe.
            string[] fileLines = File.ReadAllLines(filePath);

            //Per ogni linea del file:
            //  - Se il primo carattere della riga è # oppure se la linea è vuota salto a quella successiva.
            //  - Spezzo la stringa in analisi ogni volta che incontro un '*', metto quindi il risultato in un array.
            //  - Se l'array non ha 4 elementi salto alla riga successiva.
            //  - Controllo che la prima cella contenga il percorso di un file *.dll e che effettivamente esista;
            //  - Eseguo il medesimo controllo per la terza cella, ma vale anche per i file *.exe;
            //  - Se tutti i passi precedenti sono andati a buon fine eseguo l'associazione chiamando Associate.
            foreach (string line in fileLines)
            {
                if (line[0] == '#' || line == String.Empty)
                    continue;
                string[] splitted = line.Split('*');
                if (splitted.Length != 4) continue;
                if (splitted[0].EndsWith(".dll") && File.Exists(splitted[0]) && File.Exists(splitted[2]) && 
                   (splitted[2].EndsWith(".dll") || splitted[2].EndsWith(".exe")))
                    Associate(splitted); 
            }
        }

        private void Associate(string[] splitted)
        {
            //Carico i due assembly. Il primo è riferito all'interfaccia, il secondo alla classe che la implementa.
            Assembly interfaceDll = Assembly.LoadFrom(splitted[0]),
            classDll = Assembly.LoadFrom(splitted[2]);

            //Scorro tutti i tipi nell'assembly relativo all'interfaccia finché non trovo l'interfaccia o la classe
            //il cui FullName corrisponde a quello contenuto in splitted[1]. Passo quindi al ciclo più interno.
            foreach (Type t in interfaceDll.GetTypes())
                if (t.IsInterface && t.FullName == splitted[1])
                    //Cerco una classe nel secondo assembly che implementi l'interfaccia desiderata
                    //quindi aggiungo l'associazione nel dictionary.
                    foreach (Type impl in classDll.GetTypes())
                        if (impl.IsClass && t.IsAssignableFrom(impl))
                            _typeAssociation.Add(t, impl);
                else if (t.IsClass && t.FullName == splitted[1])
                            _typeAssociation.Add(t, t);
        }

        public T Instantiate<T>() where T : class
        {
            if (HasDefaultConstructor(_typeAssociation[typeof(T)]))
                return (T) Activator.CreateInstance(_typeAssociation[typeof(T)]);

            //Da finire.
            //Activator.CreateInstance((_typeAssociation[typeof(T)]), new object[] { });
            return null;
        }

        private bool HasDefaultConstructor(Type type)
        {
            //Dato un type classe, restituisco true se e solo se ha costruttore di default.
            foreach (ConstructorInfo constructor in type.GetConstructors())
                if (constructor.GetParameters().Length == 0)
                    return true;
            return false;
        }
    }
}
