using System;

namespace Leetcode
{
    public class ContainerWithMostWater_12
    {
        public int MaxArea(int[] height)
        {
            if (height == null)
                throw new ArgumentNullException();
            if (height.Length < 2)
                throw new ArgumentException();

            int maxVolume = 0;
            int leftIndex = 0, rightIndex = height.Length - 1;

            while (leftIndex < rightIndex)
            {
                maxVolume = Math.Max(maxVolume,
                    Math.Min(height[leftIndex], height[rightIndex]) * (rightIndex - leftIndex));

                if (height[leftIndex] <= height[rightIndex])
                    leftIndex++;
                else
                    rightIndex--;
            }

            return maxVolume;
        }
    }
}
