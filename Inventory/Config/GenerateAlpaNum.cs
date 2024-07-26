using System;
using static System.Math;

namespace Inventory.Config
{
    public class GenerateAlpaNum
    {
        public int Alpha { get; protected set; }
        public int Numeric { get; protected set; }
        public int FinalNumberic { get; protected set; }
        public int NumericStart { get; protected set; }
        public int NumericLenght { get; protected set; }
        public string FrontKeys { get; set; }
        public string EndngKeys { get; set; }
        public string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public GenerateAlpaNum(int numericLength, int alphaStart, int numberStart, string endngkeys)
        {
            FrontKeys = GetSettings.YearEnding("S");
            EndngKeys = endngkeys;
            NumericStart = numberStart;
            NumericLenght = numericLength;
            Alpha = alphaStart;
            Numeric = 0;
            FinalNumberic = 0;
        }

        public void Increment()
        {
            Numeric++;
            if (Numeric == Pow(10, NumericLenght))
            {
                Alpha++;
                Numeric = 1;
                if (Alpha == Chars.Length)
                    throw new Exception("Overflow");
            }
        }
        public override string ToString()
        {
            FinalNumberic = Numeric + this.NumericStart;
            return
                $"{this.FrontKeys}-{Chars[Alpha]}{FinalNumberic.ToString().PadLeft(NumericLenght, '0')}-{this.EndngKeys}";
        }
    }
}
