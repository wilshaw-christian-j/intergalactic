using MerchantsGuideToTheGalaxy.DocumentReader;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace MerchantsGuideToTheGalaxy.Tests
{
    [TestClass]
    public class InputParserTest
    {
        [TestMethod]
        public void EnsureInputCanbeParsed()
        {
          IInputParser parser = new InputParser();
          List<string> parsedInput = parser.ParseInput("glob is I \n prok is V");
          Assert.AreEqual(2, parsedInput.Count);
          Assert.AreEqual(true, parsedInput[0].Contains("glob"));
          Assert.AreEqual(true, parsedInput[1].Contains("prok"));
        }
    }
}
