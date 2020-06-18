namespace Leetcode
{
    public class JumpGameII_45
    {
        // 这道题需要求出从第一个元素跳跃至最后一个元素的最小跳数
        // 首先我们从第一个元素出发，去看规律：例如第一个元素是4，那么从它可以跳跃到1-4四个元素上面，分别看1-4元素的值，应当选择能支持跳跃到最远的一个元素上去
        // 因为这里跳跃的数量只要不大于元素的值即可，所以不存在跳过一个元素导致后续跳跃能力减弱的情况，如第二个元素是9，第三个是1，不会强制跳跃到1上，而是可以选择到9或者到1
        // 那么这样的情况就可以用贪婪的方法解决，即忽略后续的组合，只选择跳跃到下一次可以跳跃到最远的那个元素
        // 那么当我们跳跃到这个元素后，面临的选择就是最为多样的，我们只需要继续选择能够跳跃到最远元素的那个元素即可
        public int Jump(int[] nums)
        {
            int jumpCount = 0;
            int currentIndex = 0;

            while (currentIndex + nums[currentIndex] < nums.Length - 1)// 当最远跳跃距离大于等于数组末尾的时候，循环就结束了
            {
                int furthestIndex = currentIndex;
                int furthestRange = currentIndex + nums[currentIndex];

                // 遍历所有可选项，从中选择一个可以支持最远跳跃的元素
                for (int i = 1; i <= nums[currentIndex]; i++)
                {
                    int tmpRange = nums[currentIndex + i] + currentIndex + i; // 计算该元素能支持的最远跳跃距离
                    if (tmpRange > furthestRange)
                    {
                        // 如果这个最远距离大于先前的计算值，就更新距离值和元素的index
                        furthestIndex = currentIndex + i;
                        furthestRange = tmpRange;
                    }
                }

                // 更新元素序号（完成一次跳跃）添加跳跃次数，进行下一轮计算
                currentIndex = furthestIndex;
                jumpCount++;
            }

            // 此时的元素分为两种情况，第一种是currentIndex不在末尾上，但是经过一次跳跃就可以到达；第二种是currentIndex正好在末尾上，不需要额外跳跃
            if (currentIndex < nums.Length - 1)
                jumpCount++;

            return jumpCount;
        }
    }
}
