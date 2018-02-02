using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Owin.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNotNullOrEmpty(this string stringValue)
        {
            if (string.IsNullOrEmpty(stringValue))
                return false;

            return true;
        }
    }
}
