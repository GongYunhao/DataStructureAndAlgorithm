namespace Leetcode
{
    public class ValidSudoku_36
    {
        private const int SodokuLength = 9;

        private bool[] array = new bool[SodokuLength];

        private void ResetArray()
        {
            for (int i = 0; i < SodokuLength; i++)
            {
                array[i] = false;
            }
        }

        private bool IsCharDuplicatedInArray(char c)
        {
            if (c == '.')
                return false;

            bool result = array[c - '1'];
            array[c - '1'] = true;
            return result;
        }

        private bool CheckSquareValid(char[,] board, int rowIndex, int columnIndex)
        {
            ResetArray();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsCharDuplicatedInArray(board[rowIndex + i, columnIndex + j]))
                        return false;
                }
            }

            return true;
        }

        // 分别测试行，列和各正方形内部，查看数字是否有重复，一旦发现重复则直接返回false，能通过所有测试的，可以返回true
        // 算法本身是暴力破解的思路，好在总数据量不高，但是要注意时间常数（数据量很低的情况，时间常数会占据主要计算量，甚至连方法调用的开销都需要考虑）
        public bool IsValidSudoku(char[,] board)
        {
            for (int i = 0; i < SodokuLength; i++)
            {
                ResetArray();
                for (int j = 0; j < SodokuLength; j++)
                {
                    if (IsCharDuplicatedInArray(board[i, j]))
                        return false;
                }

                ResetArray();
                for (int j = 0; j < SodokuLength; j++)
                {
                    if (IsCharDuplicatedInArray(board[j, i]))
                        return false;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!CheckSquareValid(board, i * 3, j * 3))
                        return false;
                }
            }

            return true;
        }
    }
}
