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
        
        public SDog(string name, int age, TGender gender, int numberOfTeeth, int tailLength)
        {
            Name = name;
            Age = age;
            Gender = gender;
            NumberOfTeeth = numberOfTeeth;
            TailLength = tailLength;
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Tail length: {TailLength}";
        }
    }
}