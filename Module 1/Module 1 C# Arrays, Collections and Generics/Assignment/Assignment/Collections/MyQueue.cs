using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment.Collections
{
    public class MyQueue<T> 
    {
        private readonly int maxSize;
        private int index;
        private T[] items;

        public MyQueue(int maxSize = 10)
        {
            this.maxSize = maxSize;
            items = new T[maxSize];
            index = 0;
        }

        public void Push(T item)
        {
            if (index >= maxSize)
            {
                throw new InvalidOperationException("Queue is full!");
            }

            items[index++] = item;
        }

        public void Pop()
        {
            if (index - 1 >= 0)
            {
                for (int i = 0; i < index - 1; ++i)
                {
                    items[i] = items[i + 1];
                }

                index--;
                return;
            }

            index = 0;
            throw new InvalidOperationException("Queue is empty!");
        }

        public T Top()
        {
            return items[index];
        }

        public override string ToString()
        {
            string res = "";
            if (index == 0)
            {
                return "Queue is empty!";
            }
           for (int i = 0; i < index; ++i)
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
