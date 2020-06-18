using System;
using System.Text;

namespace Leetcode
{
    public class Integer2Roman_12
    {
        public string IntToRoman(int num)
        {
            if (num < 1 || num > 3999)
                throw new ArgumentException();

            string result = string.Empty;
            int offset = 0;

            while (num > 0)
            {
                result = dictionary[offset, num % 10] + result;
                num /= 10;
                offset++;
            }

            return result;
        }

        private string[,] dictionary =
        {
            {"","I","II","III","IV","V","VI","VII","VIII","IX"},
            {"","X","XX","XXX","XL","L","LX","LXX","LXXX","XC"},
            {"","C","CC","CCC","CD","D","DC","DCC","DCCC","CM"},
            {"","M","MM","MMM","","","","","",""}
        };
    }
}
