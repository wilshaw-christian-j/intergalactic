using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.GalacticCalculator
{
    public static class CommonMetalHelper
    {
        public static Dictionary<string, double> MetalToValueMap(string input, int valueOfUnitsInString)
        {
            var metalsAssignment = input.ToLower().Substring(0, input.ToLower().IndexOf(Symbols.credits)).TrimEnd(' ');
            var creditValue = Double.Parse(metalsAssignment.Substring(metalsAssignment.LastIndexOf(Symbols.assignment) + Symbols.assignment.Length, metalsAssignment.Length - metalsAssignment.IndexOf(Symbols.assignment) - Symbols.assignment.Length));
            var key = GetMetalKey(input);
            var metalVal = InferMetalValue(valueOfUnitsInString, creditValue);
            return new Dictionary<string, double> { { key, metalVal } };
        }
        private static string GetMetalKey(string metalsAssignment)
        {
            if (metalsAssignment.ToLower().Contains(Symbols.gold)) return Symbols.gold;
            if (metalsAssignment.ToLower().Contains(Symbols.silver)) return Symbols.silver;
            if (metalsAssignment.ToLower().Contains(Symbols.iron)) return Symbols.iron;
            if (metalsAssignment.ToLower().Contains(Symbols.dirt)) return Symbols.dirt;
            return "";
        }

        public static int GetValueOfUnitsInString(string metalsAssignment, Dictionary<string, int> units)
        {
            IEnumerable<string> matchQuery;
            int result = 0;
            int lastDecimal = 0;

            foreach (var unit in units.Keys)
            {
                if (metalsAssignment.Contains(unit))
                {
                    string[] source = metalsAssignment.Split(' ');

                    matchQuery = from word in source
                                 where word == unit
                                 select word;

                    if (matchQuery.Count() > 0)
                    {
                        foreach (var match in matchQuery)
                        {
                            int val = 0;
                             
                            bool canGetValue = units.TryGetValue(match, out val);
                            lastDecimal = val;
                            result = CalculatorHelper.ValuePrecedence(result, val, lastDecimal);
                          
                        }
                    }
                }
            }
            return result;
        }
        private static double InferMetalValue(int valueOfUnitsInInput, double creditValue)
        {
            return (creditValue / valueOfUnitsInInput);
        }
        
    }
}
