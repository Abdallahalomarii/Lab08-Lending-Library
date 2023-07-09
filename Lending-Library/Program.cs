using Lending_Library.Classes;
using Lending_Library.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace Lending_Library
{
    public class Program
    {
        
        public static void Main(string[] args)
        {
            try
            {
                UserInterface();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public static void UserInterface()
        {

            Library philLibrary = new Library();
            Backpack<Book> myBag = new Backpack<Book>();
            LoadBooks(philLibrary);
            Console.WriteLine("___________________Welcome To Phil's Library___________________");
            while (true)
            {
                
                Console.WriteLine("Enter A Number to choose an option: ");
                Console.WriteLine("1. View All Books ");
                Console.WriteLine("2. Add A Book To Your Library");
                Console.WriteLine("3. Borrow A Book From The Library ");
                Console.WriteLine("4. Return A Book To The Library");
                Console.WriteLine("5. View Books In The Bag ");
                Console.WriteLine("6. Search For A Book By Title ");
                Console.WriteLine("7. Exit");

                int input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                switch (input)
                {
                    case 1:
                        ViewBooks(philLibrary);
                        break;

                    case 2:
                        AddBokks(philLibrary);
                        break;

                    case 3:
                        BorrowABook(philLibrary, myBag);
                        break;

                    case 4:
                        ReturnABook(philLibrary, myBag);
                        break;

                    case 5:
                        myBag.PrintBag();
                        break;

                    case 6:
                        SearchForABook(philLibrary);
                        break;

                    case 7:
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                }
                Console.WriteLine();
            }
        }

        public static void LoadBooks(Library newLibrary)
        {
            newLibrary.Add("The Enigma of Time", "Emily", "Wilson", 320);
            newLibrary.Add("Beyond the Veil", "Benjamin", "Reed", 432);
            newLibrary.Add("The Art of Serenity", "Sophia", "Chen", 265);
            newLibrary.Add("The Forgotten Legacy", "Olivia", "Campbell", 512);
            newLibrary.Add("Whispers in the Dark", "Alexander", "Hughes", 384);
            newLibrary.Add("Attack on Titan", "Hajime", "Isayama", 6800);
        }

        public static void ViewBooks(Library newLibrary)
        {
            Console.WriteLine("Here Is Your Library");
            newLibrary.PrintLibrary();
        }

        public static void AddBokks(Library newLibrary)
        {
            Console.WriteLine("Enter A Title For Book");
            string title = Console.ReadLine();
            Console.WriteLine("Enter A First Name For Author Of The  Book");
            string firsName = Console.ReadLine();
            Console.WriteLine("Enter A Last Name For Author Of The Book");
            string LastName = Console.ReadLine();
            Console.WriteLine("Enter Number Of Pages Of The Book");
            int numberOfPages = Convert.ToInt32(Console.ReadLine());

            newLibrary.Add(title, firsName, LastName, numberOfPages);

        }

        public static void BorrowABook(Library newLibrary, Backpack<Book> myBag)
        {
            
            if (newLibrary.Count == 0)
            {
                Console.WriteLine("The Library is Empty Add some Books");
                AddBokks(newLibrary);
            }
            else
            {
                Console.WriteLine("Enter A Title Of The Book You Want To Borrow");
                string title = Console.ReadLine();
                var addPack = newLibrary.Borrow(title);
                myBag.Pack(addPack);
                Console.WriteLine($"The Book {addPack} Borrowd");
            }
        }

        public static void ViewBackPack(Backpack<Book> myBag)
        {
            Console.WriteLine("Here all books in Bag");
            myBag.PrintBag();
        }

        public static void ReturnABook(Library newLibrary , Backpack<Book> myBag)
        {
            myBag.PrintBag();
            if (myBag.Count<Book>() == 0)
            {
                Console.WriteLine("Please Borrow some Books");
                BorrowABook(newLibrary, myBag);
            }
            else
            {
                Console.WriteLine("Enter A number of The Book You Want To Return To Library");
                int index = Convert.ToInt32(Console.ReadLine()) - 1;
                var returnToLibrary = myBag.Unpack(index);
                newLibrary.Return(returnToLibrary);
            }
        }

        public static void SearchForABook(Library newLibrary) 
        {

            Console.WriteLine("Enter A Title To Search");
            string search = Console.ReadLine();
            if (newLibrary.SearchByTitle(search) != null)
            {
                Console.WriteLine(newLibrary.SearchByTitle(search));
            }
            else
            {
                Console.WriteLine("Connot find book with this title ");
            }
                

                    
        }
    }
}
