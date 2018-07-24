using MerchantsGuideToTheGalaxy.GalacticCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MerchantsGuideToTheGalaxy.Tests
{
    [TestClass]
    public class SymbolTests
    {
        [TestMethod]
        public void GetsAValueFromRomaNumeral()
        {
            Assert.AreEqual(1, Symbols.RomanNumeralToValue("I"));
            Assert.AreEqual(5, Symbols.RomanNumeralToValue("V"));
            Assert.AreEqual(10, Symbols.RomanNumeralToValue("X"));
            Assert.AreEqual(50, Symbols.RomanNumeralToValue("L"));
            Assert.AreEqual(100, Symbols.RomanNumeralToValue("C"));
            Assert.AreEqual(500, Symbols.RomanNumeralToValue("D"));
            Assert.AreEqual(1000, Symbols.RomanNumeralToValue("M"));
        }
    }
}
