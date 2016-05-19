using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace TempConsoleApplication1
{
    class Hashtable
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine((char)21);
            Hashtable hashtable = new Hashtable();
            hashtable.Add("one", "1");
            hashtable.Add("two", "2");
            hashtable.Add("three", "3");
            hashtable.Add("four", "4");

            foreach (string s in hashtable.Keys)
                Console.WriteLine(s);
            Console.WriteLine(" -KEY- -VALUE-");
            foreach (DictionaryEntry de in hashtable)
                Console.WriteLine(" {0}: {1}", de.Key, de.Value);

            Console.WriteLine("=================================");
            ArrayList ArrayKeys = new ArrayList(hashtable.Keys);

            for (int i = 0; i < ArrayKeys.Count; i++)
            {
                hashtable[ArrayKeys[i]] = "0";
            }

            foreach (DictionaryEntry de in hashtable)
                Console.WriteLine(" {0}: {1}", de.Key, de.Value);
            ArrayKeys.Clear();
            Console.WriteLine("=================================");
            for (int i = 0; i < ArrayKeys.Count; i++)
            {
                hashtable[ArrayKeys[i]] = "0";
            }

            System.Console.ReadLine();

        }
    }
}
