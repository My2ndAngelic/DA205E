namespace BackendLibrary
{
    public class SCat : CMammal
    {
        public const string SpecPre = "C";
        public int NumberOfColor { get; set; }

        public SCat(string name, int age, TGender gender, int numberOfTeeth, int numberOfColor)
        {
            Name = name;
            Age = age;
            Gender = gender;
            NumberOfTeeth = numberOfTeeth;
            NumberOfColor = numberOfColor;
            Id = $"{CatPre}{SpecPre}";
        }

        public SCat()
        {
            Id = $"{CatPre}{SpecPre}";
        }

        public override string ToString()
        {
            return $@"{base.ToString()}
Number of color: {NumberOfColor}";
        }
    }
}