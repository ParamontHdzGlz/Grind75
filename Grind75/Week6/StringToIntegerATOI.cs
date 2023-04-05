using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week6
{
    public class StringToIntegerATOI
    {
        public int MyAtoi(string s)
        {
            // ignore leading letters and spaces
            int i = 0;
            while (i < s.Length &&
                 s[i] == ' ')
            {
                i++;
            }

            if (i == s.Length) return 0;

            // check the sign of the number
            bool isNeg = false;
            if (s[i] == '-')
            {
                isNeg = true;
                i++;
            }
            else if (s[i] == '+')
            {
                i++;
            }

            // transform string to int
            int res = 0;
            try
            {
                while (i < s.Length && char.IsDigit(s[i]))
                {
                    if (isNeg)
                        res = checked(res * 10 - (s[i] - '0'));
                    else
                        res = checked(res * 10 + (s[i] - '0'));

                    i++;
                }


                return (int)res;
            }
            catch (OverflowException ex)
            {
                if (res < 0)
                    return int.MinValue;
                else
                    return int.MaxValue;
            }

        }
    }
}
