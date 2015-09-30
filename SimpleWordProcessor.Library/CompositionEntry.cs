namespace SimpleWordProcessor.Library
{
    public class CompositionEntry
    {
        public string FirstPart { get; set; }
        public string SecondPart { get; set; }
        public string Composition { get { return FirstPart + SecondPart; } }
    }
}
