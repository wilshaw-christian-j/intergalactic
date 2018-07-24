using MerchantsGuideToTheGalaxy.DocumentReader;
using MerchantsGuideToTheGalaxy.GalacticCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy
{
    class Program
    {
        //Location to read input from."..\\..\\..\\MerchantsGuideToTheGalaxy\\Resources\\input.txt")
        static void Main(string[] args)
        {
           
            while (true)
            {
                IInputRetriever documentRetreiver = new FileReader();
                IInputParser documentParser = new InputParser();
                IInterGalacticMapper mapper = new InterGalacticMapper();
                InterGalacticCalculator calculator = new InterGalacticCalculator("", mapper, documentRetreiver, documentParser);
                Console.Write("Welcome to the InterGalactic calculator,please provide the file location with your input? ");
                var consoleText = Console.ReadLine();

                if (consoleText == "exit") break;

                var fileInput = calculator.GetInputFromFile(consoleText);

                if (String.IsNullOrEmpty(fileInput)) break;

                var parsedInput = calculator.ParseInputFromFile(fileInput);
                var galacticUnits = calculator.MapUnits(parsedInput);
                var metalToCreditsMap = calculator.MapMetalToCredits(parsedInput, galacticUnits);

                var creditsValue = calculator.CalculateCredits(parsedInput, metalToCreditsMap, galacticUnits);
                var unitsValue = calculator.CalculateValue(parsedInput, galacticUnits);

                var outputValue = calculator.GenerateOutput(unitsValue, creditsValue);

                Console.WriteLine(outputValue);
                Console.WriteLine("\r\n");

            }
            
        }

}
}


