using System;
using System.Collections.Generic;

namespace BookRatingApp
{
  public abstract class BookBase : BookObject, IBook
  {

    public BookBase(string title) : base(title) { }

    public event RatingAddedDelegate RatingAdded;

    public abstract void SaveRating(double rating);

    public abstract void ChangeBookTitle(string title);

    public abstract Statistics ShowStatistics();

    public void AddRating(string rating)
    {
      string[] acceptedStrings = { "1+", "2-", "2+", "3-", "3+", "4-", "4+", "5-", "5+", "6-", "6+", "7-", "7+", "8-", "8+", "9-", "9+", "10-" };
      bool isStringAccepted = Array.Exists(acceptedStrings, el => el == rating);

      double number;
      double.TryParse(rating, out number);

      if (number != 0)
      {
        CheckRating(number);
        Console.WriteLine($"Entered {number}");
      }

      else if (isStringAccepted)
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
          case "10-": CheckRating(9.75); break;
          case "9-": CheckRating(8.75); break;
          case "8-": CheckRating(7.75); break;
          case "7-": CheckRating(6.75); break;
          case "6-": CheckRating(5.75); break;
          case "5-": CheckRating(4.75); break;
          case "4-": CheckRating(3.75); break;
          case "3-": CheckRating(2.75); break;
          case "2-": CheckRating(1.75); break;
        }
      }
      else
      {
        Console.WriteLine("Invalid value. Please entere value between 1 and 10 with + or -(ex. 6+)");
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
  }
}