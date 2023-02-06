namespace BackendLibrary
{
    public class SCat : CMammal
    {
        public const string SpecPre = "C";
        public int SpecData { get; set; } // Number of color

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

        public override string ToString()
        {
            return $@"{base.ToString()}
Number of color: {SpecData}";
        }
    }
}