namespace BackendLibrary
{
    public class SDog : CMammal
    {
        public const string SpecPre = "D";

        public readonly TMammal Species = TMammal.Dog;


        public SDog()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public int SpecData { get; set; } // Tail length

        public override string ToString()
        {
            return $@"{base.ToString()}
Tail length: {SpecData} cm";
        }
    }
}