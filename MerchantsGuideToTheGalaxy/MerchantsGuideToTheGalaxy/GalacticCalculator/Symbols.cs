using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantsGuideToTheGalaxy.GalacticCalculator
{
    public static class Symbols
    {
        private enum RomanNumerals : int { I= 1, V= 5, X=10,L= 50, C=100, D= 500, M=1000 };
        
        public static string howMuch = "how much";
        public static string howMany = "how many";
        public static string question = "?";
        public static string assignment = "is ";
        public static string credits = "credits";
        public const string iron = "iron";
        public const string silver = "silver";
        public const string gold = "gold";
        public const string dirt = "dirt";
        public const char I = 'I';
        public const char V = 'V';
        public const char X = 'X';
        public const char L = 'L';
        public const char C ='C';
        public const char D = 'D';
        public const char M = 'M';
        public static int RomanNumeralToValue(string strNumeral)
        {
            RomanNumerals numeral;
            if (Enum.TryParse(strNumeral, out numeral))
                switch (numeral)
                {
                    case RomanNumerals.I:
                        return (int)RomanNumerals.I;
                    case RomanNumerals.V:
                        return (int)RomanNumerals.V;
                    case RomanNumerals.X:
                        return (int)RomanNumerals.X;
                    case RomanNumerals.L:
                        return (int)RomanNumerals.L;
                    case RomanNumerals.C:
                        return (int)RomanNumerals.C;
                    case RomanNumerals.D:
                        return (int)RomanNumerals.D;
                    case RomanNumerals.M:
                        return (int)RomanNumerals.M;
                    default:
                        break;
                }
            return 0;
        }
    }
}
