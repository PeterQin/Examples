using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Quest.Tuning.HashtableTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creates and initializes a new Hashtable.
            Hashtable myHT = new Hashtable();
            myHT.Add("one", "The");
            myHT.Add("two", "quick");
            myHT.Add("three", "brown");
            myHT.Add("four", "fox");
            // Displays the Hashtable.
            Console.WriteLine("The Hashtable contains the following:");
            PrintKeysAndValues(myHT);
            Console.WriteLine("===============================");
            
            foreach (DictionaryEntry de in myHT)
                Console.WriteLine(" {0}: {1}", de.Key, de.Value);
            ClearHashtable(myHT);
            Console.WriteLine("clear...");
            PrintKeysAndValues(myHT);
            Console.ReadLine();



        }
        public static void PrintKeysAndValues(Hashtable myHT)
        {
            foreach (string s in myHT.Keys)
                Console.WriteLine(s);
            Console.WriteLine(" -KEY- -VALUE-");
            foreach (DictionaryEntry de in myHT)
                Console.WriteLine(" {0}: {1}", de.Key, de.Value);
            Console.WriteLine();
        }
        public static void ClearHashtable(Hashtable myHT)
        {
            myHT.Clear();
        }

    }
}
