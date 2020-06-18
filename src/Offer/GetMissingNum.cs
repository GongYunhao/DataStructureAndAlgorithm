namespace Offer
{
    public class GetMissingNum
    {
        public static int GetResult(int[] array)
        {
            // 
            if (array.Length == 0 || array[0] != 0)
                return 0;

            int left = 0;
            int right = array.Length - 1;

            while (left != right - 1)
            {
                int middle = (left + right) / 2;

                if (array[middle] == middle)
                    left = middle;
                else
                    right = middle;
            }

            return right;
        }
    }
}
