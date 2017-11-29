using System;
using System.Collections.Generic;
using System.Linq;


namespace Lab05
{
    public class Lab05
    {
        public static IEnumerable <T> MacroExpansion <T> (IEnumerable <T> sequence, T value, IEnumerable <T> newSequence)
        {
            if (sequence == null || newSequence == null)
                throw new ArgumentNullException();

            List <T> nextSequence = new List<T>();
            List<T> swapSequence = newSequence.ToList();
            foreach (T val in sequence)
                if (val.Equals(value))
                    nextSequence.AddRange(swapSequence);
                else
                    nextSequence.Add(val);

            return nextSequence;
        }
    }
}
