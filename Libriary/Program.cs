using System;

namespace Libriary
{
    class Program
    {
        static void Main(string[] args)
        {
            BooksList booksList = BooksList.Load("../../../data/books-input.txt");
            string command = ReadCommandFromKbd();
            while (!isHaveCommand(command))
            {
                command = ReadCommandFromKbd();
            }
            BooksList resultList = ProcessingCommand(command, booksList);
            resultList.Print(command);
        }
        static BooksList ProcessingCommand(string command, BooksList list)
        {
            BooksList resultList = new BooksList();
            switch (command)
            {
                case "1":
                    resultList = RunCommandFindByAuthor(list);
                    break;
                case "2":
                    resultList = RunCommandFindByName(list);
                    break;
                case "3":
                    resultList  = RunCommandFindByYears(list);
                    break;
                case "4":
                     RunCommandExit();
                    break;
            }
            return resultList;
        }

        static BooksList RunCommandFindByAuthor(BooksList list)
        {
            Console.WriteLine("Введите Автора по которому будет осуществляться поиск книг");
            string author = Console.ReadLine();
            return list.FindByAuthor(author);
        }
        static BooksList RunCommandFindByName(BooksList list)
        {
            Console.WriteLine("Введите слово по которому будет осуществляться поиск книг");
            string word = Console.ReadLine();
            return list.FindByWord(word);
        }

        static BooksList RunCommandFindByYears(BooksList list)
        {
            Console.WriteLine("Введите диапазон лет через '|'.");
            string[] years = Console.ReadLine().Split('|');
            return list.FindByYears(Convert.ToInt32(years[0]), Convert.ToInt32(years[1]));
        }

        static void RunCommandExit()
        {
            string msg = "Вы вышли из программы";
            Console.WriteLine(msg);
        }

        static bool isHaveCommand(string command)
        {
            bool candidate = false;
            switch (command)
            {
                case "1":
                    candidate = true;
                    break;
                case "2":
                    candidate = true;
                    break;
                case "3":
                    candidate = true;
                    break;
                case "4":
                    candidate = true;
                    break;
            }
            return candidate;
        }
        static string ReadCommandFromKbd()
        {
            Console.WriteLine("Введите одну из цифр.\n " +
                "1 - Вывести все книги: заданного автора.\n " +
                "2 - Вывести все книги: по заданному названию.\n " +
                "3 - Вывести все книги: по диапазону лет.\n "+
                "4 - Выход из программы");

            return Console.ReadLine();
        }
    }
}
