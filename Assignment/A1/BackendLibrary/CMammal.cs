namespace BackendLibrary
{
    public class CMammal : Animal
    {
        public const string CatPre = "M";

        public int NumberOfTeeth = 0;

        public override string ToString()
        {
            return $@"{base.ToString()}
Number of teeth: {NumberOfTeeth}";
        }
    }

    public enum TMammal
    {
        Cat,
        Dog,
    }
}