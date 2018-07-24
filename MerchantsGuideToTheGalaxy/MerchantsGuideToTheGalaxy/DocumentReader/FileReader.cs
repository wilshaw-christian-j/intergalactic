using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    public class FileReader:IInputRetriever
    {
        public string GetData(string sourceFileName)
        {
            string output;
            using (var stream = File.OpenRead(sourceFileName))
            using (var reader = new StreamReader(stream))
            {
                output = reader.ReadToEnd();
            }
            return output;
        }
    }
}
