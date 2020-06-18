using System;
using System.Collections.Generic;
using System.Text;

namespace Leetcode
{
    class WordSearch
    {
        public bool Exist(char[][] board, string word)
        {
            if (board == null || board.Length == 0 || board[0].Length == 0
               || word == null || word.Length == 0)
                return false;

            // search for start char
            int rowCount = board.Length, columnCount = board[0].Length;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    bool found = false;
                    if (board[i][j] == word[0])
                    {
                        bool[][] ma = new bool[rowCount][];
                        for (int k = 0; k < rowCount; k++)
                        {
                            ma[k] = new bool[columnCount];
                        }
                        // if there are several start points, only one path is needed
                        found = ExistCore(board, ma, i, j, word, 0);
                    }

                    if (found)
                        return found;
                }
            }

            return false;
        }

        private bool ExistCore(char[][] board, bool[][] used, int i, int j, string word, int strIndex)
        {
            if (strIndex == word.Length - 1 && board[i][j] == word[strIndex])
                return true;

            if (board[i][j] != word[strIndex])
                return false;

            int rowCount = board.Length, columnCount = board[0].Length;
            used[i][j] = true;// set current char as used

            // current char is same, but not at end of the word
            // should traverse all neighboring chars
            // and find other possible paths
            // consider up char
            if (i >= 1 && used[i - 1][j] == false)
            {
                if (ExistCore(board, used, i - 1, j, word, strIndex + 1))
                {
                    used[i][j] = true;
                    return true;
                }
            }
            // consider right char
            if (j < columnCount - 1 && used[i][j + 1] == false)
            {
                if (ExistCore(board, used, i, j + 1, word, strIndex + 1))
                {
                    used[i][j] = true;
                    return true;
                }
            }
            // consider down char
            if (i < rowCount - 1 && used[i + 1][j] == false)
            {
                if (ExistCore(board, used, i + 1, j, word, strIndex + 1))
                {
                    used[i][j] = true;
                    return true;
                }
            }
            // consider left char
            if (j >= 1 && used[i][j - 1] == false)
            {
                if (ExistCore(board, used, i, j - 1, word, strIndex + 1))
                {
                    used[i][j] = true;
                    return true;
                }
            }

            return false;
        }
    }
}
