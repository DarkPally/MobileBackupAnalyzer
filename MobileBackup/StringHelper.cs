using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobileBackup
{
    public static class StringHelper
    {
        public static string PathFilter(this string input)
        {
            char[] r = input.ToCharArray();
            for (int pos = 0; pos < r.Length; ++pos)
            {
                char t = r[pos];
                switch (t)
                {
                    case '\"':
                    case '<':
                    case '>':
                    case '?':
                    case ':':
                    case '|':
                    case '*':
                        r[pos] = '_';
                        break;
                    default:
                        break;
                }

            }
            return new string(r);

        }
    }
}
