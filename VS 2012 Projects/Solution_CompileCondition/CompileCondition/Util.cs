using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CompileCondition
{
    public static class Util
    {
        public static bool HasElement(this ICollection source)
        {
            if (source != null && source.Count > 0)
            {
                return true;
            }

            return false;
        }
    }
}
