using System.Runtime.InteropServices.JavaScript;

namespace BackendLibrary
{
    public class SCat : CMammal
    {
        public const string SpecPre = "C";
        public int NumberOfColor { get; set; }

        public SCat(string name, int age, TGender gender, int numberOfColor)
        {
            Name = name;
            Age = age;
            Gender = gender;
            NumberOfColor = numberOfColor;
            Id = $"{CatPre}{SpecPre}";
        }

        public SCat()
        {
            Id = $"{CatPre}{SpecPre}";
        }
    }
}