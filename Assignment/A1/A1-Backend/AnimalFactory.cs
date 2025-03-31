using System.Collections;

namespace A1_Backend;

public class AnimalFactory : IList<Animal>
{
    public IList<Animal> Animals { get; }


    public AnimalFactory()
    {
        Animals = (List<Animal>) [];
    }
    
    /// <summary>
    /// Constructor with data
    /// </summary>
    /// <param name="animals"></param>
    public AnimalFactory(IList<Animal> animals)
    {
        this.Animals = animals;
    }

    public IEnumerator<Animal> GetEnumerator() => Animals.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => Animals.GetEnumerator();

    public void Add(Animal item) => Animals.Add(item);

    public void Clear() => Animals.Clear();

    public bool Contains(Animal item) => Animals.Contains(item);

    public void CopyTo(Animal[] array, int arrayIndex) => Animals.CopyTo(array, arrayIndex);

    public bool Remove(Animal item) => Animals.Remove(item);

    public int Count => Animals.Count;
    public bool IsReadOnly => Animals.IsReadOnly;

    public int IndexOf(Animal item) => Animals.IndexOf(item);

    public void Insert(int index, Animal item) => Animals.Insert(index, item);

    public void RemoveAt(int index) => Animals.RemoveAt(index);

    public Animal this[int index]
    {
        get => Animals[index];
        set => Animals[index] = value;
    }
}