using BackendLibrary;

Animal a = null;
IAnimalList animalList = new IAnimalList();
a = new SCat("John", 69, TGender.Male, 32,420);

Console.WriteLine(a.ToString());
animalList.Add(a);
Console.WriteLine("Hello");
Console.WriteLine(animalList.ReturnID(0));