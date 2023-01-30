using BackendLibrary;

Animal a = null;
IAnimalList animalList = new IAnimalList();
a = new SCat();
animalList.Add(a);
Console.WriteLine("Hello");
Console.WriteLine(animalList.ReturnID(0));