using MerchantsGuideToTheGalaxy.DocumentReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.GalacticCalculator
{
    public class InterGalacticCalculator
    {
        private string _calculatorInput;
        private IInterGalacticMapper _interGalacticMapper;
        private IInputRetriever _documentRetreiver;
        private IInputParser _documentParser;
        public InterGalacticCalculator(string calculatorInput, IInterGalacticMapper interGalacticMapper, IInputRetriever documentRetreiver, IInputParser documentParser)
        {
            _calculatorInput = calculatorInput;
            _interGalacticMapper = interGalacticMapper;
            _documentRetreiver = documentRetreiver;
            _documentParser = documentParser;
        }

        public string GetInputFromFile(string fileLocation)
        {
            var text = _documentRetreiver.GetData(fileLocation);
            return text;
        }
        public List<string> ParseInputFromFile(string text)
        {
            var inputData = _documentParser.ParseInput(text);
            return inputData;
        }
        public Dictionary<string, int> MapUnits(List<string> parsedInput)
        {
            Dictionary<string, int> units = new Dictionary<string, int>();
            foreach (var value in parsedInput)
            {
                if (value.Contains(Symbols.assignment) && !value.ToLower().Contains(Symbols.question) && !value.ToLower().Contains(Symbols.credits) && value.IndexOfAny(new char[] { Symbols.I, Symbols.V, Symbols.C, Symbols.D, Symbols.X, Symbols.M, Symbols.L }) >= 0)
                {
                    units = _interGalacticMapper.GenerateInterGalacticUnitMap(value);
                }
            }
            return units;

        }
        public Dictionary<string, double> MapMetalToCredits(List<string> parsedInput, Dictionary<string, int> units)
        {
            Dictionary<string, double> metalToCreditMap = new Dictionary<string, double>();
            foreach (var value in parsedInput)
            {
                if (value.Contains(Symbols.assignment) && !value.ToLower().Contains(Symbols.question) && value.ToLower().Contains(Symbols.credits))
                {
                    metalToCreditMap = _interGalacticMapper.GenerateCommonMetalToCreditMap(value, units);
                }
            }
            return metalToCreditMap;

        }
        public Dictionary<string, int> CalculateValue(List<string> parsedInput, Dictionary<string, int> units)
        {
            string[] valueQuestioninputs;
            
            int lastDecimal = 0;
            Dictionary<string, int> results = new Dictionary<string, int>();
            foreach (var value in parsedInput)
            {
                int result = 0;
                if (value.Contains(Symbols.assignment) && value.ToLower().Contains(Symbols.question) && value.ToLower().Contains(Symbols.howMuch))
                {
                    var val = value.Substring(value.IndexOf(Symbols.assignment) + 3);
                    valueQuestioninputs = val.Split(' ');
                    int outVal = 0;
                    foreach (var match in valueQuestioninputs)
                    {
                        bool canGetValue = units.TryGetValue(match, out outVal);
                        lastDecimal = outVal;
                        result = CalculatorHelper.ValuePrecedence(result, outVal, lastDecimal);
                    }
                    
                }
                results.Add(value, result);

            }
            return results;
        }
        public Dictionary<string, double> CalculateCredits(List<string> parsedInput, Dictionary<string, double> metalToCreditMap, Dictionary<string, int> units)
        {
            int creditResult = 0;
            int lastDecimal = 0;
            string[] creditQuestionInput;
            Dictionary<string, double> results = new Dictionary<string, double>();
            foreach (var value in parsedInput)
            {
                if (value.Contains(Symbols.assignment) && value.ToLower().Contains(Symbols.question) && value.ToLower().Contains(Symbols.credits) && value.ToLower().Contains(Symbols.howMany))
                {
                    var creditsString = value.Substring(value.IndexOf(Symbols.assignment) + 3);
                    creditQuestionInput = creditsString.Split(' ');

                    double outDbl = 0;
                    int outVal = 0;
                    double res = 0;
                    creditResult = 0;
                    foreach (var match in creditQuestionInput)
                    {
                        bool test = metalToCreditMap.TryGetValue(match.ToLower(), out outDbl);

                        bool unitTest = units.TryGetValue(match.ToLower(), out outVal);

                        lastDecimal = outVal;

                        creditResult = CalculatorHelper.ValuePrecedence(creditResult, outVal, lastDecimal);
                        if (test)
                        {
                            res = creditResult * outDbl;
                        }
                    }
                    results.Add(value, res);
                }

            }
            return results;
        }

        public string GenerateOutput(Dictionary<string, int> unitsValue, Dictionary<string, double> creditsValue)
        {
            StringBuilder outValue = new StringBuilder();
            foreach (var unit in unitsValue)
            {
                if (unit.Key.Contains(Symbols.howMuch) && unit.Value != 0)
                {
                    outValue = GetOutputBuilder(unit.Key, unit.Value.ToString(), outValue);
                }
                if (unit.Key.Contains(Symbols.howMuch) && unit.Value == 0)
                {
                    outValue.AppendLine("I have no idea what you are talking about");
                }
                               
            }
            foreach (var credit in creditsValue)
            {
                if (credit.Key.Contains(Symbols.howMany))
                {
                    outValue = GetOutputBuilder(credit.Key, credit.Value.ToString(), outValue);
                }
                if (credit.Key.Contains(Symbols.howMany) && credit.Value == 0)
                {
                    outValue.AppendLine("I have no idea what you are talking about");
                }
            }
            return outValue.ToString();
        }

        private StringBuilder GetOutputBuilder(string inputString, string valueString, StringBuilder builder)
        {
           
            var creditString = inputString.Substring(inputString.IndexOf(Symbols.assignment) + 3);
            builder.Append(creditString.Replace(Symbols.question, Symbols.assignment).Replace("\r"," ")).Append(valueString).AppendLine();
            return builder;
        }

    }
}
