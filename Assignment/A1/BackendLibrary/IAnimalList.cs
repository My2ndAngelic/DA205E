using System.Collections;

namespace BackendLibrary
{
    public class IAnimalList : IList<Animal>
    {
        private List<Animal?> listAnimals = new List<Animal?>();
        
        public IEnumerator<Animal?> GetEnumerator()
        {
            return listAnimals.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return listAnimals.GetEnumerator();
        }

        public void Add(Animal? item)
        {
            listAnimals.Add(item);
        }

        public void Clear()
        {
            listAnimals.Clear();
        }

        public bool Contains(Animal? item)
        {
            return listAnimals.Contains(item);
        }

        public void CopyTo(Animal[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Animal? item)
        {
            return listAnimals.Remove(item);
        }

        public int Count
        {
            get { return listAnimals.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public int IndexOf(Animal? item)
        {
            return listAnimals.IndexOf(item);
        }

        public void Insert(int index, Animal? item)
        {
            listAnimals.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            listAnimals.RemoveAt(index);
        }

        public Animal? this[int index]
        {
            get { return listAnimals[index]; }
            set { listAnimals[index] = value;  }
        }

        public string ReturnID(Animal? item)
        {
            return $@"{item.Id}{listAnimals.IndexOf(item):0000}";
        }
        
        public string ReturnID(int item)
        {
            return $@"{listAnimals[item].Id}{item:0000}";
        }
    }
}