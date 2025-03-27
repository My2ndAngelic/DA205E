namespace BackendLibrary
{
    public class Animal
    {
        public Animal()
        {
            Name = string.Empty;
            Age = -1;
            Gender = TGender.Unknown;
            Id = string.Empty;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public TGender Gender { get; set; }

        public string Id { get; set; }

        public override string ToString()
        {
            return $@"Name: {Name}
Age: {Age}
Gender: {Gender}";
        }
    }
}