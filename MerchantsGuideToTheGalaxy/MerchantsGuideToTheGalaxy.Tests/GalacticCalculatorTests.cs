using System;
using System.Collections.Generic;
using System.Linq;
using MerchantsGuideToTheGalaxy.DocumentReader;
using MerchantsGuideToTheGalaxy.GalacticCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerchantsGuideToTheGalaxy.Tests
{
    [TestClass]
    public class GalacticCalculatorTests
    {
        [TestMethod]
        public void EnsureCalculatorCanBeInstatiated()
        {
            
            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            Assert.IsInstanceOfType(calculator, typeof(InterGalacticCalculator));
        }
        [TestMethod]
        public void EnsureCalculatorCanGetText()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            Assert.IsNotNull(text);
            Assert.AreEqual(true,text.Contains("glob"));
        }

        [TestMethod]
        public void EnsureCalculatorCanParseInput()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            var parsedInput = calculator.ParseInputFromFile(text);
            Assert.IsNotNull(parsedInput);
            Assert.AreEqual(true, parsedInput.Count()>0);
        }
        [TestMethod]
        public void EnsureCalculatorCanMapUnits()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            var parsedInput = calculator.ParseInputFromFile(text);
           var galacticUnits= calculator.MapUnits(parsedInput);
            Assert.IsNotNull(galacticUnits);
            Assert.AreEqual(true, galacticUnits.Count() > 0);
            Assert.AreEqual(true, galacticUnits.Count() == 7);
        }
        [TestMethod]
        public void EnsureCalculatorMapMetalToCredits()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            var parsedInput = calculator.ParseInputFromFile(text);
            var galacticUnits = calculator.MapUnits(parsedInput);
            var metalToCreditsMap= calculator.MapMetalToCredits(parsedInput, galacticUnits);

            Assert.IsNotNull(metalToCreditsMap);
            Assert.AreEqual(true, metalToCreditsMap.Count() > 0);
            Assert.AreEqual(true, metalToCreditsMap.Count() == 3);
        }

        [TestMethod]
        public void EnsureCalculateValueFromInput()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            var parsedInput = calculator.ParseInputFromFile(text);
            var galacticUnits = calculator.MapUnits(parsedInput);
            var metalToCreditsMap = calculator.MapMetalToCredits(parsedInput, galacticUnits);         
            var value = calculator.CalculateValue(parsedInput, galacticUnits);
   
            Assert.AreEqual(true, value.Count>0);
        }

        [TestMethod]
        public void EnsureCalculateCreditsFromInput()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            var parsedInput = calculator.ParseInputFromFile(text);
            var galacticUnits = calculator.MapUnits(parsedInput);
            var metalToCreditsMap = calculator.MapMetalToCredits(parsedInput, galacticUnits);
            var value = calculator.CalculateCredits(parsedInput, metalToCreditsMap, galacticUnits);
            Assert.AreEqual(true, value.Count>0);
            Assert.AreEqual(true, value.First().Value == 68);
        }

        [TestMethod]
        public void EnsureOutputCanBeGenerated()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            //var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            //var parsedInput = calculator.ParseInputFromFile(text);
            //var galacticUnits = calculator.MapUnits(parsedInput);
            //var metalToCreditsMap = calculator.MapMetalToCredits(parsedInput, galacticUnits);
            //var value = calculator.CalculateCredits(parsedInput, metalToCreditsMap, galacticUnits);
            //var unitValue = calculator.CalculateValue(parsedInput, galacticUnits);

            var unitValue = new Dictionary<string, int>();
            unitValue.Add( "glob",1 );
            unitValue.Add("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?", 0);
            var value = new Dictionary<string, double>(); 
            var outputValue = calculator.GenerateOutput(unitValue, value);
           
            Assert.AreEqual(true, outputValue!="");
            Assert.AreEqual(true, outputValue.Contains("I have no idea what you are talking about"));
        }
        [TestMethod]
        public void EnsureOutputCanBeGeneratedWithMineralMap()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            //var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt");
            //var parsedInput = calculator.ParseInputFromFile(text);
            //var galacticUnits = calculator.MapUnits(parsedInput);
            //var metalToCreditsMap = calculator.MapMetalToCredits(parsedInput, galacticUnits);
            //var value = calculator.CalculateCredits(parsedInput, metalToCreditsMap, galacticUnits);
            //var unitValue = calculator.CalculateValue(parsedInput, galacticUnits);

            var unitValue = new Dictionary<string, int>();
            unitValue.Add("glob", 1);
            unitValue.Add("how many Silver is glob Gold ?", 0);
            var creditsvalue = new Dictionary<string, double>();
            creditsvalue.Add("how   manyy Silver is glob Gold ?", 0);
            var outputValue = calculator.GenerateOutput(unitValue, creditsvalue);

            //Assert.AreEqual(true, outputValue != "");
            Assert.AreEqual(true, outputValue.Contains("I have no idea what you are talking about"));
        }

        [TestMethod]
        public void EnsureCalculatorCanMapAdditionalUnits()
        {

            IInputParser documentParser = new InputParser();
            IInterGalacticMapper mapper = new InterGalacticMapper();
            IInputRetriever documentRetreiver = new FileReader();
            InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
            var text = calculator.GetInputFromFile("..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\singleinput.txt");
            var parsedInput = calculator.ParseInputFromFile(text);
            var galacticUnits = calculator.MapUnits(parsedInput);
            Assert.IsNotNull(galacticUnits);
            Assert.AreEqual(true, galacticUnits.Count() > 0);
            Assert.AreEqual(true, galacticUnits.Count() == 7);
        }
    }
}
