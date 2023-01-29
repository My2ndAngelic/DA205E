namespace BackendLibrary
{
    public class Animal
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public TGender Gender { get; set; }
        public string Id { get; set; }

        public Animal()
        {
            Name = "";
            Age = -1;
            Gender = TGender.Male;
            Id = "";
        }

        public Animal(string name, int age, TGender gender, string id)
        {
            Name = name;
            Age = age;
            Gender = gender;
            Id = id;
        }
    }
}