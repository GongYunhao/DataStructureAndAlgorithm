namespace Leetcode
{
    public class JumpGame_55
    {
        public bool CanJump(int[] nums)
        {
            int currentPoint = 0;

            while (nums[currentPoint] != 0 && currentPoint != nums.Length - 1)
                currentPoint = GetJumpDestination(nums, currentPoint);// jump until arrive at last index or 0

            return currentPoint == nums.Length - 1;
        }

        // If destination point could make next jump out of current range,then jump to the point
        // If couldn't, jump to farest point
        private int GetJumpDestination(int[] nums, int currentPoint)
        {
            if (currentPoint + nums[currentPoint] >= nums.Length - 1)
                return nums.Length - 1;// If last element in the jump range, return last index

            int farestPoint = currentPoint + nums[currentPoint];
            int jumpDestination = currentPoint;
            for (int i = 1; i <= nums[currentPoint]; i++)
            {
                int tmp = currentPoint + i + nums[currentPoint + i];

                if (tmp >= farestPoint)
                {
                    farestPoint = tmp;
                    jumpDestination = currentPoint + i;
                }
            }
            return jumpDestination;
        }
    }
}
