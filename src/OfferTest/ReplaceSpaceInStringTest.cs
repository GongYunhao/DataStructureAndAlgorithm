using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class ReplaceSpaceInStringTest
    {
        [Fact]
        public void Test()
        {
            Assert.Equal("vhoinruoreinfgh93u79058nfvjiugoieu", ReplaceSpacesInString.Execute("vhoinruoreinfgh93u79058nfvjiugoieu"));
            Assert.Equal("vhoinru%20oreinfgh93u79058nfvjiugoieu", ReplaceSpacesInString.Execute("vhoinru oreinfgh93u79058nfvjiugoieu"));
            Assert.Equal("%20vhoinru%20oreinfgh93u79058nfvjiugoieu", ReplaceSpacesInString.Execute(" vhoinru oreinfgh93u79058nfvjiugoieu"));
            Assert.Equal("%20vhoinru%20oreinfgh93u79058nfvjiugoieu%20", ReplaceSpacesInString.Execute(" vhoinru oreinfgh93u79058nfvjiugoieu "));
            Assert.Equal("%20vhoinru%20%20oreinfgh93u79058nfvjiugoieu%20", ReplaceSpacesInString.Execute(" vhoinru  oreinfgh93u79058nfvjiugoieu "));

            Assert.Equal("%20", ReplaceSpacesInString.Execute(" "));
            Assert.Equal(String.Empty, ReplaceSpacesInString.Execute(String.Empty));

            Assert.Throws<ArgumentNullException>(() => ReplaceSpacesInString.Execute(null));
        }
    }
}
