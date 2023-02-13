namespace BackendLibrary
{
    public class SDove : CBird
    {
        public const string SpecPre = "D";

        public readonly TBird Species = TBird.Dove;

        public int SpecData = 0; // Weight kg

        public SDove()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Weight: {SpecData} kg";
        }
    }
}