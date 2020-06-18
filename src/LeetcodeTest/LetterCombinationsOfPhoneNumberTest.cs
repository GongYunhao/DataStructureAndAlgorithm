using System.Collections.Generic;
using CommonModels;
using Leetcode;
using Xunit;

namespace LeetcodeTest
{
    public class LetterCombinationsOfPhoneNumberTest
    {
        [Fact]
        public void InputTwoLettersReturnList()
        {
            var list = new LetterCombinationsOfPhoneNumber_17().LetterCombinations("23");
            Assert.Equal(9, list.Count);
            Assert.True(list.ContainsSameElement(new List<string>
            {
                "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf"
            }));
        }

        [Fact]
        public void InputEmptyStringReturnEmptyList()
        {
            var list = new LetterCombinationsOfPhoneNumber_17().LetterCombinations(string.Empty);
            Assert.Equal(0, list.Count);
        }
    }
}
