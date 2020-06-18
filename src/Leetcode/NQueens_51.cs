using System;
using System.Collections.Generic;

namespace Leetcode
{
    public class NQueens_51
    {
        public IList<IList<string>> SolveNQueens(int n)
        {
            // Initiate puzzle
            int[] puzzle = new int[n];
            for (int i = 0; i < n; i++)
                puzzle[i] = i;

            var result = new List<IList<string>>();
            GeneratePuzzleRecursively(puzzle, 0, result);
            return result;
        }

        private void GeneratePuzzleRecursively(int[] puzzle, int startIndex, IList<IList<string>> result)
        {
            // One puzzle finished, add to result if puzzle is valid
            if (startIndex == puzzle.Length)
            {
                if (ValidateQueens(puzzle))
                {
                    result.Add(GetStrings(puzzle));
                }
            }

            for (int i = startIndex; i < puzzle.Length; i++)
            {
                Swap(ref puzzle[startIndex], ref puzzle[i]);
                GeneratePuzzleRecursively(puzzle, startIndex + 1, result);
                Swap(ref puzzle[startIndex], ref puzzle[i]);
            }
        }

        private List<string> GetStrings(int[] puzzle)
        {
            List<string> tmpResult = new List<string>(puzzle.Length);
            char[] strArray = new char[puzzle.Length];

            for (int i = 0; i < puzzle.Length; i++)
            {
                ResetStrArray(strArray);
                strArray[puzzle[i]] = 'Q';
                tmpResult.Add(new string(strArray));
            }
            return tmpResult;
        }

        private void ResetStrArray(char[] strArray)
        {
            for (int i = 0; i < strArray.Length; i++)
                strArray[i] = '.';
        }

        private bool ValidateQueens(int[] puzzle)
        {
            for (int i = 0; i < puzzle.Length; i++)
            {
                for (int j = i + 1; j < puzzle.Length; j++)
                {
                    if (puzzle[i] == puzzle[j] || Math.Abs(puzzle[i] - puzzle[j]) == j - i)
                        return false;
                }
            }
            return true;
        }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }
    }
}
