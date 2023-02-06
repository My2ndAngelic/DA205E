namespace BackendLibrary
{
    public class CBird : Animal
    {
        public readonly string CatPre = "B";

        public int CatData = 0; // Flying speed

        public override string ToString()
        {
            return $@"{base.ToString()}
Flying speed: {CatData}";
        }
    }

    public enum TBird
    {
        Dove,
        Eagle
    }
}