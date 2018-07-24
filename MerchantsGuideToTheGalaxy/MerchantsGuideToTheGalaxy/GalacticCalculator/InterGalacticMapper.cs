using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.GalacticCalculator
{
    public class InterGalacticMapper : IInterGalacticMapper
    {
        private Dictionary<string, double> MetalCreditMap = new Dictionary<string, double>();
        private Dictionary<string, int> InterGalacticUnitMap = new Dictionary<string, int>();
        public Dictionary<string, double> GenerateCommonMetalToCreditMap(string input, Dictionary<string, int> unitsMap)
        {
            
            Dictionary<string, double> MetalMap = CommonMetalHelper.MetalToValueMap(input, CommonMetalHelper.GetValueOfUnitsInString(input, unitsMap));
            MetalCreditMap.Add(MetalMap.Keys.First(),MetalMap.Values.First());
            return MetalCreditMap;
        }
        public Dictionary<string, int> GenerateInterGalacticUnitMap(string input)
        {
            string[] units = input.Split(' ');
            InterGalacticUnitMap.Add(units[0], Symbols.RomanNumeralToValue(units[2]));
            return InterGalacticUnitMap;
        }
    }
}
