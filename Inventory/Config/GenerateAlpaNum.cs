namespace Inventory.Config
{
    public class GenerateAlpaNum
    {
        public int Numeric { get; protected set; }
        public int NumericStart { get; protected set; }
        public int NumericLength { get; protected set; }
        public string Prefix { get; set; }

        public GenerateAlpaNum(string prefix, int numericLength, int numberStart)
        {
            Prefix = prefix;
            NumericStart = numberStart;
            NumericLength = numericLength;
            Numeric = numberStart; // Start from the provided number
        }

        public void Increment()
        {
            Numeric++;
        }

        public override string ToString()
        {
            return $"{Prefix}{Numeric.ToString().PadLeft(NumericLength, '0')}";
        }
    }
}
