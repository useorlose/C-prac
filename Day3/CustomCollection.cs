using SampleConApp.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace SampleConApp.Day3
{
    class BookCollection : IEnumerable<Book>
    {
        List<Book> books = new List<Book>();

        public void AddBook(Book bk) => books.Add(bk);

        public List<Book> FindBook(string title) => books.FindAll((b) => b.Title.Contains(title));

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (Book bk in books)
                yield return bk;
        }//yeild keyword used to get the IEnumerator Interface object associated with the Current Collection. 

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
    class CustomCollection
    {
        static void Main(string[] args)
        {
            BookCollection demo = new BookCollection();
            demo.AddBook(new Book { Title = "Title1" });
            demo.AddBook(new Book { Title = "Title2" });
            demo.AddBook(new Book { Title = "Title3" });
            demo.AddBook(new Book { Title = "Title4" });
            demo.AddBook(new Book { Title = "Title5" });
            //foreach(var bk in demo)
            //    Console.WriteLine(bk.Title);

            var iterator = demo.GetEnumerator();
            while(iterator.MoveNext())
                Console.WriteLine(iterator.Current.Title);
        }
    }
}
