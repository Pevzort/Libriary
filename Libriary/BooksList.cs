using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Libriary
{
    class BooksList
    {
        static public BooksList Load(string filename)
        {
            BooksList list = new BooksList();
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(filename))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] data = line.Split('|');

                        Book book = new Book(data[0], data[1], data[2]);
                        list.Add(book);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            return list;
        }
        public void Add(Book book)
        {
            _bookList.Add(book);
        }
        public BooksList FindByAuthor(string author)
        {
            BooksList books = new BooksList();
            foreach (Book book in _bookList)
            {
                if (book.Author == author)
                {
                    books.Add(book);
                }
            }
            return books;
        }
        public BooksList FindByWord(string word)
        {
            BooksList books = new BooksList();
            foreach (Book book in _bookList)
            {
                string pattern = @"[,.!?']\s*";
                Regex regex = new Regex(pattern);
                string bookName = regex.Replace(book.Name, " ");
                string[] wordsBook = bookName.ToLower().Split(' ');
                if (wordsBook.Contains(word.ToLower()))
                {
                    books.Add(book);
                }
            }
            return books;
        }
        public BooksList FindByYears(int startYear, int endYear)
        {
            BooksList books = new BooksList();
            foreach (Book book in _bookList)
            {
                if (book.Year <= endYear && book.Year >= startYear)
                {
                    books.Add(book);
                }
            }
            return books;
        }

        public void Print(string command)
        {
            Console.WriteLine("Результаты поиска: ");
            if (_bookList.Count > 0)
            {

                switch (command)
                {
                    case "1":
                        PrintByAuthor();
                        break;
                    case "2":
                        PrintByName();
                        break;
                    case "3":
                        PrintByYears();
                        break;
                }
            } else
            {
                Console.WriteLine("По вашему запросу ничего не найдено");
            }
        }

        //public BooksList ExitProgram(string msg)
        //{

        //    return Console.WriteLine(msg);
        //}

        private void PrintByAuthor()
        {
            _bookList.ForEach((Book book) => Console.WriteLine($"Название книги: {book.Name}, Год - {book.Year}"));
        }
        private void PrintByName()
        {
            _bookList.ForEach((Book book) => Console.WriteLine($"Название книги: {book.Name}, Автор - {book.Author}"));
        }
        private void PrintByYears()
        {
            _bookList.ForEach((Book book) => Console.WriteLine($"Автор - {book.Author}, Название книги: {book.Name}, Год - {book.Year}"));
        }

        private List<Book> _bookList = new List<Book>();
    }
}
