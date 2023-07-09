using Lending_Library.Classes;
using Lending_Library.Interfaces;

namespace LendingLibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddBookToLibrary()
        {
            Library newLibrary = new Library();

            newLibrary.Add("book1", "abdallah", "Alomari", 5);
            
            Assert.Equal(1, newLibrary.Count);
        }
        [Fact]

        public void BorrowingAnExistingTitle()
        {
            Library newLibrary = new Library();
            Backpack<Book> myBag = new Backpack<Book>();
            newLibrary.Add("book2", "abdallah", "Alomari", 5);

            Book borrowBook = newLibrary.Borrow("book2");
            myBag.Pack(borrowBook);
            Assert.NotNull(borrowBook);
            Assert.DoesNotContain(borrowBook, newLibrary);
            Assert.Equal(0, newLibrary.Count);
            Assert.Contains(borrowBook, myBag);

        }
        [Fact]
        public void BorrowingAnMissingTitle()
        {
            Library newLibrary = new Library();



            newLibrary.Add("book2", "abdallah", "Alomari", 5);

            Book borrowBook = newLibrary.Borrow("book");

            Assert.Null(borrowBook);
            Assert.Equal(1, newLibrary.Count);

        }

        [Fact]
        public void ReturnBookToTheLibrary()
        {
            Library newLibrary = new Library();

            Book returnBook = new Book("return book ", "The ", "World", 1500);

            newLibrary.Return(returnBook);
            Assert.Contains(returnBook, newLibrary);
            Assert.Equal(1, newLibrary.Count);
        }
        [Fact]
        public void PackAndUnPack()
        {
            Backpack<string> newBag = new Backpack<string>();

            newBag.Pack("First Test");
            newBag.Pack("Second Test");
            newBag.Pack("Third Test");

            var result = newBag.Unpack(2);

            Assert.Contains("Second Test", newBag);
            Assert.DoesNotContain(result, newBag);


        }
    }
}