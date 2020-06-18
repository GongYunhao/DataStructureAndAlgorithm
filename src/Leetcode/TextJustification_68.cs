using System.Collections.Generic;
using System.Linq;

namespace Leetcode
{
    public class TextJustification_68
    {
        public IList<string> FullJustify(string[] words, int maxWidth)
        {
            // split string into lines
            List<Line> lineList = new List<Line>();
            Line currentLine = new Line(maxWidth);
            lineList.Add(currentLine);

            foreach (string word in words)
            {
                if (!currentLine.TryAdd(word))
                {
                    currentLine = new Line(maxWidth);
                    lineList.Add(currentLine);
                    currentLine.TryAdd(word);
                }
            }

            // convert lines to result string lists
            List<string> result = new List<string>();
            for (int i = 0; i < lineList.Count; i++)
            {
                result.Add(lineList[i].FormatedString(i == lineList.Count - 1));
            }

            return result;
        }

        // use a nested class to handle the string format
        private class Line
        {
            private IList<string> _list = new List<string>();

            /// <summary>
            /// an virtual value which determines if a new string can be added to the line
            /// assume that all words are split by single space char
            /// </summary>
            private int _currentLength;
            private int _maxLength;

            public Line(int maxLength)
            {
                _maxLength = maxLength;
            }

            public bool TryAdd(string str)
            {
                if (_currentLength + str.Length > _maxLength)
                    return false;
                _list.Add(str);
                _currentLength += 1 + str.Length;
                return true;
            }

            public string FormatedString(bool leftJustified)
            {
                FormatWithSpaces(leftJustified);
                return ConcatString();
            }

            private void FormatWithSpaces(bool leftJustified)
            {
                // if this line contains only one word, just fill the line with whitespace
                if (_list.Count == 1)
                {
                    _list.Insert(1, EmptySpaces(_maxLength - GetAllStringLength()));
                    return;
                }

                // if this line is last line, then all words should be split by a single whitespace, and fill the rest with space
                if (leftJustified)
                {
                    for (int i = _list.Count - 1; i >= 1; i--)
                    {
                        int actualCount = 1;
                        _list.Insert(i, EmptySpaces(actualCount));
                    }

                    _list.Add(EmptySpaces(_maxLength - GetAllStringLength()));
                }
                else
                {
                    // to the other type of lines, should calculate space counts and insert between words
                    int totalSpaceCount = _maxLength - GetAllStringLength();
                    int averageCount = totalSpaceCount / (_list.Count - 1);
                    int additionalCount = totalSpaceCount % (_list.Count - 1);

                    for (int i = _list.Count - 1; i >= 1; i--)
                    {
                        int actualCount = i <= additionalCount ? averageCount + 1 : averageCount;
                        _list.Insert(i, EmptySpaces(actualCount));
                    }
                }
            }

            private int GetAllStringLength()
            {
                return _list.Sum(o => o.Length);
            }

            private string ConcatString()
            {
                string s = string.Empty;
                for (int i = 0; i < _list.Count; i++)
                {
                    s += _list[i];
                }
                return s;
            }

            private string EmptySpaces(int count)
            {
                string result = string.Empty;
                for (int i = 0; i < count; i++)
                    result += " ";
                return result;
            }
        }
    }
}
