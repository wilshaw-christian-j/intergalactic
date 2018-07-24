using MerchantsGuideToTheGalaxy.GalacticCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace MerchantsGuideToTheGalaxy.Tests
{
    [TestClass]
    public class InterGalacticMapperTests
    {
        [TestMethod]
        public void GenerateCommonMetalToCreditMap()
        {
            IInterGalacticMapper mapper = new InterGalacticMapper();
            Assert.IsInstanceOfType(mapper.GenerateCommonMetalToCreditMap("glob glob Silver is 34 Credits", mapper.GenerateInterGalacticUnitMap("glob is I")), typeof(Dictionary<string, double>));

        }
        [TestMethod]
        public void GenerateInterGalacticUnitMap()
        {
            IInterGalacticMapper mapper = new InterGalacticMapper();
            Assert.IsInstanceOfType(mapper.GenerateInterGalacticUnitMap("glob is I"), typeof(Dictionary<string, int>));
        }
        [TestMethod]
        public void InterGalacticUnitsHaveValues()
        {
            IInterGalacticMapper mapper = new InterGalacticMapper();

            var galacticUnits = mapper.GenerateInterGalacticUnitMap("glob is I");
            var result = mapper.GenerateInterGalacticUnitMap("tegj is L");
            
            Assert.AreEqual(true,galacticUnits.ContainsKey("glob"));
            Assert.AreEqual(true, galacticUnits.ContainsValue(1));
            Assert.AreEqual(true, galacticUnits.ContainsKey("tegj"));
            Assert.AreEqual(true, galacticUnits.ContainsValue(50));
        }
        [TestMethod]
        public void TestValueOfMetal()
        {
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IDictionary<string, double> testDict = mapper.GenerateCommonMetalToCreditMap("glob glob Silver is 34 Credits", mapper.GenerateInterGalacticUnitMap("glob is I"));
            Assert.AreEqual("silver", testDict.Keys.First());
            Assert.AreEqual(17, testDict.Values.First());
        }
//        [TestMethod]
//        public void TestValueOfMappedMetal()
//        {
//            IInterGalacticMapper mapper = new InterGalacticMapper();
//            IDictionary<string, double> testDict = mapper.GenerateCommonMetalToCreditMap("how many Silver is glob Gold", mapper.GenerateInterGalacticUnitMap("glob is I"));

//            Assert.AreEqual("silver", testDict.Keys.First());
//            Assert.AreEqual(17, testDict.Values.First());
//        }
}
}
