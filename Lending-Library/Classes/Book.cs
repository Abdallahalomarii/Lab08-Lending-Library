using Lending_Library.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending_Library.Classes
{
    public class Book 
    {

        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int NumberOfPages { get; set; }

        public Book(string title, string firstName, string lastName, int numberOfPages)
        {
            Title = title;
            FirstName = firstName;
            LastName = lastName;
            NumberOfPages = numberOfPages;
        }
        public override string ToString()
        {
            return $"Title: {Title}, FullName: {FirstName} {LastName}, Pages: {NumberOfPages}";
        }
    }
}
