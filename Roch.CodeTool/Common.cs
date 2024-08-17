using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roch.CodeTool
{
   public class Common
    {
        public static string FirstCharToLower(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            else if (input.Length == 1)
            {
                return input.ToLower();
            }
            else
            {
                return input.Substring(0, 1).ToLower() + input.Substring(1);
            }
        }

    }
}
