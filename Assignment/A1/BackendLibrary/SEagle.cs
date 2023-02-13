namespace BackendLibrary
{
    public class SEagle : CBird
    {
        public const string SpecPre = "E";

        public readonly TBird Species = TBird.Eagle;

        public int SpecData = 0; // Feather length (cm)

        public SEagle()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Feather length: {SpecPre} cm";
        }
    }
}