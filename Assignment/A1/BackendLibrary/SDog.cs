namespace BackendLibrary
{
    public class SDog : CMammal
    {
        public int TailLength { get; set; }
        
        public const string SpecPre = "D";

        public SDog()
        {
            Id = $"{CatPre}{SpecPre}";
        }
    }
}