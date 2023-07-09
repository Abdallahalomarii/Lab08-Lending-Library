using Lending_Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Lending_Library.Classes
{
    public class Library : ILibrary
    {
        private Dictionary<string, Book> dictionary;

        public Library()
        {
            dictionary = new Dictionary<string, Book>();
        }

        public int Count => dictionary.Count;

        public void Add(string title, string firstName, string lastName, int numberOfPages)
        {
            

            Book existingBook = SearchByTitle(title);
            if (existingBook != null)
            {
                Console.WriteLine("A book with the same title already exists in the library.");
                return;
            }
            Book newBook = new Book(title, firstName, lastName, numberOfPages);

            dictionary.Add(title.ToLower(), newBook);
        }

        public Book Borrow(string title)
        {
            foreach (var borrow in dictionary)
            {
                Book borrowBook = borrow.Value;
                if (borrow.Key.ToLower() == title.ToLower())
                {
                    dictionary.Remove(borrow.Key);
                    return borrowBook;
                }

            }
            return null;
        }
        /// <summary>
        /// print the book inside the Library
        /// </summary>
        public void PrintLibrary()
        {
            string print = "";
            foreach (var book in dictionary)
            {
                print += $" {book.Value}\n";
            }
            Console.WriteLine(print);
        }

        public void Return(Book book)
        {
            dictionary.Add(book.Title.ToLower(), book);
        }

       

        public Book SearchByTitle(string title)
        {
            Book foundBook;
            foreach (var book in dictionary)
            {
                if (book.Key.ToLower() == title.ToLower())
                {
                    foundBook = book.Value;
                    return foundBook;
                }
            }
            return null;
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return dictionary.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
