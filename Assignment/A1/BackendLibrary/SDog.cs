namespace BackendLibrary
{
    public class SDog : CMammal
    {
        public int SpecData { get; set; }
        
        public const string SpecPre = "D";

        public SDog()
        {
            Id = $"{CatPre}{SpecPre}";
        }
        
        public SDog(string name, int age, TGender gender, int catData, int specData)
        {
            Name = name;
            Age = age;
            Gender = gender;
            CatData = catData;
            SpecData = specData;
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Tail length: {SpecData} cm";
        }
    }
}