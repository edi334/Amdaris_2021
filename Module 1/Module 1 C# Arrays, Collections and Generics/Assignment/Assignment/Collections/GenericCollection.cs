using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Collections
{
    class GenericCollection<T>
    {
        private readonly int maxSize;
        private int index;
        private T[] items;
        public GenericCollection(int maxSize = 10)
        {
            this.maxSize = maxSize;
            index = 0;
            items = new T[maxSize];
        }
        public void Add (T item)
        {
            if (index >= maxSize)
            {
                throw new InvalidOperationException("Collection is full!");
            }
            items[index++] = item;
        }
        public void Delete (int pos)
        {
            if (pos < 0 || pos > index)
            {
                throw new InvalidOperationException("Invalid position in collection!");
            }
            for (int i = pos; i < maxSize - 1; ++i)
            {
                items[i] = items[i + 1];
            }
        }
        public T GetItem (int index)
        {
            return items[index];
        }
        public void SetItem (int pos, T value)
        {
            items[pos] = value;
        }
        public void Swap (int index1, int index2)
        {
            T aux;
            aux = items[index1];
            items[index1] = items[index2];
            items[index2] = aux;
        }
        public void Swap (T i1, T i2)
        {
            T aux;
            int index1 = -1, index2= - 1;
            for (int i = 0; i < maxSize; ++i)
            {
                if (items[i] != null)
                {
                    if (items[i].Equals(i1))
                    {
                        index1 = i;
                    }
                    if (items[i].Equals(i2))
                    {
                        index2 = i;
                    }
                }
            }

            if (index1 == -1 || index2 == -1)
            {
                throw new InvalidOperationException("One of the items provided could not be found!");
            }

            aux = items[index1];
            items[index1] = items[index2];
            items[index2] = aux;
        }
        public override string ToString()
        {
            string res = "";
            if (index == 0)
            {
                return "Queue is empty!";
            }
            for (int i = 0; i < maxSize; ++i)
            {
                if (items[i] != null)
                {
                    res = res + items[i].ToString() + "\n";
                }
            }

            return res;
        }
    }
}
