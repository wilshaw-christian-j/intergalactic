using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.GalacticCalculator
{
    public interface IInterGalacticMapper
    {
        Dictionary<string, double> GenerateCommonMetalToCreditMap(string input, Dictionary<string, int> unitsMap);
        Dictionary<string, int> GenerateInterGalacticUnitMap(string input);
    }
}
