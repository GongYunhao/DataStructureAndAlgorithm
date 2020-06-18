using System;
using System.Collections.Generic;
using System.Text;
using Offer;
using Xunit;

namespace OfferTest
{
    public class RegExPatternTest
    {
        [Fact]
        public void NoSymbol()
        {
            Assert.True(RegExPattern.IsMatch("aadegea", "aadegea"));

            Assert.False(RegExPattern.IsMatch("iengillbi", "vnieeinegyenkdieygnslo"));
            Assert.False(RegExPattern.IsMatch("iengillbi", "vni"));
        }

        [Fact]
        public void SingleDot()
        {
            Assert.True(RegExPattern.IsMatch("abcdeffffgthyu", ".bcdeffffgthyu"));
            Assert.True(RegExPattern.IsMatch("abcdeffffgthyu", "abcdef.ffgthyu"));
            Assert.True(RegExPattern.IsMatch("abcdeffffgthyu", "abcdeffffgthy."));

            Assert.False(RegExPattern.IsMatch("abcdeffffgthyu", "ab.fffgthy"));
        }

        [Fact]
        public void MultipleDots()
        {
            Assert.True(RegExPattern.IsMatch("multipledots", "mult....dots"));
            Assert.True(RegExPattern.IsMatch("multipledots", "..ltipledots"));
            Assert.True(RegExPattern.IsMatch("multipledots", "multipledo.."));
            Assert.True(RegExPattern.IsMatch("multipledots", ".ultipledot."));
            Assert.True(RegExPattern.IsMatch("multipledots", "..ltipledo.."));
            Assert.True(RegExPattern.IsMatch("multipledots", ".ulti.ledot."));
            Assert.True(RegExPattern.IsMatch("multipledots", ".ulti..edot."));
            Assert.True(RegExPattern.IsMatch("multipledots", "............"));

            Assert.False(RegExPattern.IsMatch("multipledots", "m.lt.edo"));
            Assert.False(RegExPattern.IsMatch("multipledots", ".........."));
        }

        [Fact]
        public void SingleStar()
        {
            Assert.True(RegExPattern.IsMatch("aaaaa", "a*"));
            Assert.True(RegExPattern.IsMatch("singlestar", "singa*lestar"));
            Assert.True(RegExPattern.IsMatch("ssssssinglestar", "s*inglestar"));
            Assert.True(RegExPattern.IsMatch("singlestar", "singlestar*"));
            Assert.True(RegExPattern.IsMatch("singlestar", "sib*nglestar"));
            Assert.True(RegExPattern.IsMatch("singlestar", "c*singlestarm*"));

            Assert.False(RegExPattern.IsMatch("singlestar", "sinl*lestar"));
            Assert.False(RegExPattern.IsMatch("singlestar", "e*inglestar"));
            Assert.False(RegExPattern.IsMatch("singlestar", "singlesta*"));
        }

        [Fact]
        public void MultipleStars()
        {
            Assert.True(RegExPattern.IsMatch("multttttipleeeeestars", "mult*iple*stars"));
            Assert.True(RegExPattern.IsMatch("multiplestars", "m*ult*iple*stars*"));

            Assert.False(RegExPattern.IsMatch("multiplestars", "m*ut*iple*stars*"));
            Assert.False(RegExPattern.IsMatch("multiplestars", "m*ult*"));
        }

        [Fact]
        public void MixedSymbols()
        {
            Assert.True(RegExPattern.IsMatch("mixedsymmmmmbolswithdotsandstars", "mixedsym*bolswithdotsands.ars"));
            Assert.True(RegExPattern.IsMatch("mixedsymbolswithdotsandstarssssss", "mixedsym*bolswithdotsands.ars*"));
            Assert.True(RegExPattern.IsMatch("eingieyien", ".*"));
            Assert.True(RegExPattern.IsMatch("eingieyien", "ei.*en"));

            Assert.False(RegExPattern.IsMatch("midsymbolswithdotsandstarssssss", "mixedsym*bolswithdotsands.ars*"));
            Assert.False(RegExPattern.IsMatch("mixedsymbolswithdotsandsarssssss", "mixedsym*bolswithdotsands.ars*"));
        }

        [Fact]
        public void InvalidInput()
        {
            Assert.Throws<ArgumentNullException>(() => RegExPattern.IsMatch(null, "9987"));
            Assert.Throws<ArgumentNullException>(() => RegExPattern.IsMatch("658", null));
        }

        [Fact]
        public void TestUsingEmptyStrings()
        {
            Assert.True(RegExPattern.IsMatch(string.Empty, string.Empty));
            Assert.True(RegExPattern.IsMatch(string.Empty, "a*"));
            Assert.True(RegExPattern.IsMatch(string.Empty, ".*"));

            Assert.False(RegExPattern.IsMatch("aa", string.Empty));
            Assert.False(RegExPattern.IsMatch(string.Empty, "."));
        }
    }
}
