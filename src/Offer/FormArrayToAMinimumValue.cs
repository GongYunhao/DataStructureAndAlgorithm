using System;
using System.Text;

namespace Offer
{
    public class FormArrayToAMinimumValue
    {
        public static string Form(string[] array)
        {
            // 具体思考过程看剑指Offer书P227上的笔记
            Array.Sort(array, (string a, string b) => string.Compare(a + b, b + a));

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < array.Length; i++)
            {
                sb.Append(array[i]);
            }

            return sb.ToString();
        }
    }
}
