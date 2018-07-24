
namespace MerchantsGuideToTheGalaxy.GalacticCalculator
{
    public static class CalculatorHelper
    {
        public static int ValuePrecedence(int TotalDecimal, int LastRomanLetter, int LastDecimal)
        {

            if (LastRomanLetter > TotalDecimal)
            {
                return LastDecimal - TotalDecimal;
            }
            else
            {
                return LastDecimal + TotalDecimal;
            }
        }
    }
}
