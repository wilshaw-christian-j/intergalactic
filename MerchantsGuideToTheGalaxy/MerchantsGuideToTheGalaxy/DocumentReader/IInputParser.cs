using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.DocumentReader
{
    public interface IInputParser
    {
        List<string> ParseInput(string input);
    }
}
