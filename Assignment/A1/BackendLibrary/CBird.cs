namespace BackendLibrary
{
    public class CBird : Animal
    {
        public readonly string CatPre = "B";

        public int FlyingSpeed = 0;

        public override string ToString()
        {
            return $@"{base.ToString()}
Flying speed: {FlyingSpeed}";
        }
    }

    public enum TBird
    {
        Dove,
        Eagle
    }
}