namespace BackendLibrary
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TGender Gender { get; set; }

        public string Id { get; set; }

        public Animal(string name, int age, TGender gender)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Id = string.Empty;
        }

        public Animal()
        {
            Name = string.Empty;
            Age = -1;
            Gender = TGender.Unknown;
            Id = string.Empty;
        }
    }
}