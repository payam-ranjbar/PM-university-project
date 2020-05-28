using System;

namespace ScriptingUtils.ExtensionMethods
{
    public static class IntegerExtensions
    {
        public static string StandardDualTimeRepresentation(this int number)
        {
            if (number < 10)
            {
                return "0" + number;
            } else if (number < 100)
            {
                return number.ToString();
            }
            throw new Exception("Number must have at most two digits");
        }
    }
}