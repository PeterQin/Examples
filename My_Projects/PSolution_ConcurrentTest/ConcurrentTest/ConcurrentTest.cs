using System;
using System.Collections.Generic;
using System.Text;

namespace ConcurrentTest
{
    class ConcurrentTest
    {
        public delegate void AddConcurrentRule(object aActionToCheck, List<object> aActions);
        public static void AddRule(AddConcurrentRule addConcurrentRule)
        {
            Processing process;
            List<object> InvalidConcurrentProcessing;

            InvalidConcurrentProcessing = new List<object>();
            process = Processing.Start;
            InvalidConcurrentProcessing.Add(Processing.Start);
            InvalidConcurrentProcessing.Add(Processing.Resume);
            addConcurrentRule(process, InvalidConcurrentProcessing);

        }
    }
}
