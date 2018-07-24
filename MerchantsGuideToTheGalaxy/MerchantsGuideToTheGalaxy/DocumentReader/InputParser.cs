
using System.Collections.Generic;
using System.Linq;

namespace MerchantsGuideToTheGalaxy.DocumentReader
{
    public class InputParser : IInputParser
    {
        public List<string> ParseInput(string input)
        {
            List<string> output;
            output = input.Split('\n').ToList();
            return output;
        }
    }
}
