using Lending_Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending_Library.Classes
{
    public class Backpack<T> : IBag<T>
    {
        private List<T> Items;

        public Backpack()
        {
            Items = new List<T>();
        }
        public void Pack(T item)
        {
            if (item != null)
            {
                Items.Add(item);
            }
            else
            {
                return;
            }
        }

        public T Unpack(int index)
        {
            if (index < Items.Count && index >= 0)
            {
                var result = Items[index];
                Items.Remove(Items[index]);
                return result;
            }
            else
            {
               throw new IndexOutOfRangeException("The index out of range ");
            }
            
        }


        public void PrintBag()
        {
            int index = 1;
            Console.WriteLine("Backpack Contents:");
            foreach (T item in Items)
            {
                Console.WriteLine(index + "- " + item);
                index++;
            }
            Console.WriteLine();
        }
        public void ViewBag()
        {
            Console.WriteLine("Backpack Contents:");
            foreach (T item in Items)
            {
                Console.WriteLine( item);
            }
            Console.WriteLine();
        }


        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
