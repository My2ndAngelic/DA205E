namespace BackendLibrary
{
    public class SCat : CMammal
    {
        public const string SpecPre = "C";

        public readonly TMammal Species = TMammal.Cat;

        public SCat(string name, int age, TGender gender, int catData, int specData)
        {
            Name = name;
            Age = age;
            Gender = gender;
            CatData = catData;
            SpecData = specData;
            Id = $"{CatPre}{SpecPre}";
        }

        public SCat()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public int SpecData { get; set; } // Number of color

        public override string ToString()
        {
            return $@"{base.ToString()}
Number of color: {SpecData}";
        }
    }
}