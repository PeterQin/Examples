using System;
using System.Collections.Generic;
using System.Text;

namespace Quest.Tuning.FileTransferCommon
{
    public class Util
    {
        public static T StringToEnum<T>(string aEnum) where T : struct
        {
            try
            {
                T Result = (T)Enum.Parse(typeof(T), aEnum);
                if (Enum.IsDefined(typeof(T), Result) == false)
                {
                    return default(T);
                }
                return Result;
            }
            catch (Exception)
            {
                return default(T);
            }

        }
    }
}
