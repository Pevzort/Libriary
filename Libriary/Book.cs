using System;
using System.Collections.Generic;
using System.Text;

namespace Libriary
{
    class Book
    {
        public Book(string author, string name, string year) {
            _author = author;
            _name = name;
            _year = Convert.ToInt32(year);
        }

        public string Author { get { return _author; } }
        public string Name { get { return _name; } }
        public int Year { get { return _year; } }

        private string _name;
        private string _author;
        private int _year;
    }
}
