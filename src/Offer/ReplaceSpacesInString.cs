using System;
using System.Collections.Generic;
using System.Text;

namespace Offer
{
    public class ReplaceSpacesInString
    {
        public static string Execute(string text)
        {
            if(text == null)
                throw new ArgumentNullException(nameof(text),"The input text can't be null");

            int spaceCount = 0;
            foreach (char c in text)
            {
                if (c == ' ')
                    spaceCount++;
            }

            if (spaceCount == 0)
                return text;

            char[] charArray = new char[text.Length + spaceCount * 2];

            int currentCharIndex = 0;
            foreach (char c in text)
            {
                if (c != ' ')
                {
                    charArray[currentCharIndex] = c;
                    currentCharIndex++;
                }
                else
                {
                    charArray[currentCharIndex] = '%';
                    currentCharIndex++;
                    charArray[currentCharIndex] = '2';
                    currentCharIndex++;
                    charArray[currentCharIndex] = '0';
                    currentCharIndex++;
                }
            }

            return new String(charArray);// 使用String类的构造函数
        }
    }
}
