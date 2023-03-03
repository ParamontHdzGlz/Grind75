using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind75.Week2
{
    class AddBinaryClass
    {
        public string AddBinary(string a, string b)
        {
            var result = new List<int>();

            int aIndex = a.Length - 1;
            int bIndex = b.Length - 1;
            int carry = 0;

            while (aIndex >= 0 || bIndex >= 0)
            {
                var sum = carry;

                if (aIndex >= 0)
                    sum += a[aIndex] - '0';

                if (bIndex >= 0)
                    sum += b[bIndex] - '0';

                carry = sum / 2;
                sum = sum % 2;

                aIndex--;
                bIndex--;
                result.Add(sum);
            }
            if (carry > 0) result.Add(carry);

            result.Reverse();
            return string.Join("", result);
        }
    }
}
