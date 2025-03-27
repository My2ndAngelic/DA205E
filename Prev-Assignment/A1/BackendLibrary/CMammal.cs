namespace BackendLibrary
{
    public class CMammal : Animal
    {
        public const string CatPre = "M";

        public readonly TCategory Category = TCategory.Mammal;

        public int CatData = 0; // Number of teeth

        public override string ToString()
        {
            return $@"{base.ToString()}
Number of teeth: {CatData}";
        }
    }

    public enum TMammal
    {
        Cat,
        Dog
    }
}