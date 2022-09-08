using System;
using System.Collections.Generic;

namespace BookRatingApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("\nPlease select option:");
      string mainOption = "";
      bool result = false;

      while (result == false)
      {
        Console.WriteLine("1. Work on txt file\n2. Work inside computer memory\nq. Exit from program");
        mainOption = Console.ReadLine();

        switch (mainOption)
        {
          case "1":
            result = true;
            break;
          case "2":
            result = true;
            break;
          case "q":
            {
              Console.WriteLine("Goodbye, see you later");
              Environment.Exit(0);
              break;
            }
          default:
            Console.WriteLine($"Invalid input. You have entered: [{mainOption}]. Please select valid option.");
            break;
        }
      }

      Console.WriteLine($"\nPlease enter the book title:");

      IBook book = null;

      if (mainOption == "1")
      {
        book = new InFileBook(Console.ReadLine());
      }

      if (mainOption == "2")
      {
        book = new InMemoryBook(Console.ReadLine());
      }
      if (book.Title == null)
      {
        Console.WriteLine("Title can`t be empty");
        Main(args);
      }

      while (true)
      {
        if (book.Title == "")
        {
          Console.WriteLine("Title can`t be empty. Please start again and enter valid title");
          Main(args);
        }
        Console.WriteLine($"\n--- Options for {book.Title} ---\n1. Add new rating\n2. Rename current book \n3. Show Statistics\n4. Start again with new book\nq Exit from program");
        string secondaryOption = Console.ReadLine();
        switch (secondaryOption)
        {
          case "1":
            {
              Console.WriteLine($"\nPlease enter a new rating between 1 and 10 for {book.Title}");
              string rating = Console.ReadLine();
              book.AddRating(rating);
              break;
            }
          case "2":
            {
              Console.WriteLine($"\nPlease enter a new title for {book.Title}");
              string newName = Console.ReadLine();
              book.ChangeBookTitle(newName);
              break;
            }
          case "3":
            var statistics = book.ShowStatistics();

            if (statistics.Count > 0)
            {
              Console.WriteLine($"\n--- Statistics for {book.Title} ---");
              Console.WriteLine($"The highest rating is: {statistics.High}");
              Console.WriteLine($"The lowest rating is: {statistics.Low}");
              Console.WriteLine($"The average rating is: {statistics.Average:N2}");
              Console.WriteLine($"The average rating in letter is: {statistics.Letter}");
            }
            else
            {
              Console.WriteLine($"Statistics for {book.Title} are not available. Please add some rating first.");
            }
            break;
          case "4":
            Main(args);
            break;
          case "q":
            {
              Console.WriteLine("Goodbye, see you later");
              Environment.Exit(0);
              break;
            }
          default:
            Console.WriteLine($"Invalid input. You have entered: [{secondaryOption}]. Please select valid option.");
            break;
        }
      }
    }
  }
}


