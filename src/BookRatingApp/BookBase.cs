using System;
using System.Collections.Generic;

namespace BookRatingApp
{
  public abstract class BookBase : BookObject, IBook
  {

    public BookBase(string title) : base(title) { }

    public event RatingAddedDelegate RatingAdded;

    public abstract void SaveRating(double rating);

    public virtual void ChangeFileName(string oldTitle, string newTitle) { }

    public abstract Statistics ShowStatistics();

    public void AddRating(string rating)
    {
      string[] AcceptedStrings = { "1+", "2-", "2+", "3-", "3+", "4-", "4+", "5-", "5+", "6-", "6+", "7-", "7+", "8-", "8+", "9-", "9+", "10-" };
      bool check = Array.Exists(AcceptedStrings, el => el == rating);

      double number;
      double.TryParse(rating, out number);

      if (number != 0)
      {
        CheckRating(number);
        Console.WriteLine($"Entered {number}");
      }

      else if (check)
      {
        switch (rating)
        {
          case "9+": CheckRating(9.5); break;
          case "8+": CheckRating(8.5); break;
          case "7+": CheckRating(7.5); break;
          case "6+": CheckRating(6.5); break;
          case "5+": CheckRating(5.5); break;
          case "4+": CheckRating(4.5); break;
          case "3+": CheckRating(3.5); break;
          case "2+": CheckRating(2.5); break;
          case "1+": CheckRating(1.5); break;
          case "1": CheckRating(1); break;
          case "10-": CheckRating(9.75); break;
          case "9-": CheckRating(8.75); break;
          case "8-": CheckRating(7.75); break;
          case "7-": CheckRating(6.75); break;
          case "6-": CheckRating(5.75); break;
          case "5-": CheckRating(4.75); break;
          case "4-": CheckRating(3.75); break;
          case "3-": CheckRating(2.75); break;
          case "2-": CheckRating(1.75); break;
          default:
            throw new ArgumentException("Invalid value. Please entere value between 1 and 10 with + or -(ex. 6+)");
        }
      }
    }

    private void CheckRating(double rating)
    {
      if (rating >= 1 && rating <= 10)
      {
        this.SaveRating(rating);
        if (RatingAdded != null)
        {
          RatingAdded(this, new EventArgs(), rating);
        }
      }
      else
      {
        Console.WriteLine("Entered rating is not in correct range (1-10)");
      }
    }

    public void OnRatingAdded(object sender, EventArgs args, double rating)
    {
      if (rating < 3)
      {
        Console.WriteLine($"Rating {rating}... Oh no! Low rating was added");
      }
      else
      {
        Console.WriteLine($"Rating {rating}... New rating is added");
      }
    }

    public void ChangeBookTitle(string title)
    {
      bool digit = false;
      foreach (var letter in title)
      {
        if (char.IsDigit(letter))
        {
          digit = true;
        }
      }
      if (title == "")
      {
        Console.WriteLine("Title cannot be empty. Title has not been changed. Please enter valid book title");
      }
      else if (!digit)
      {
        string oldTitle = this.Title;
        string newTitle = title;
        this.Title = title;
        Console.WriteLine($"The new title is {Title}");
        ChangeFileName(oldTitle, newTitle);
      }
      else
      {
        Console.WriteLine("There is a number in given title. It is not allowed.");
      }
    }
  }
}