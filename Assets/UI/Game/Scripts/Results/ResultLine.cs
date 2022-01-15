namespace UI.Game.Results
{
    public class ResultLine
    {
        public ResultLine(string title, string value)
        {
            this.Title = title;
            this.Value = value;
            WithDerivation = false;
        }

        public ResultLine(string title, string value, int derivation, bool derivationFlavour)
        {
            this.Title = title;
            this.Value = value;
            this.Derivation = derivation;
            this.DerivationFlavour = derivationFlavour;
            WithDerivation = true;
        }

        public string Title { get; }

        public string Value { get; }

        // TODO: make two versions of ResultLine
        public bool WithDerivation { get; }

        public int Derivation { get; }

        public bool DerivationFlavour { get; }
    }
}