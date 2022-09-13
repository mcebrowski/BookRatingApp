using System;
using System.Collections.Generic;

namespace BookRatingApp
{
  public class InMemoryBook : BookBase
  {
    private List<double> ratings = new List<double>();

    public InMemoryBook(string title) : base(title)
    {
      RatingAdded += OnRatingAdded;
    }

    public override void SaveRating(double rating)
    {
      this.ratings.Add(rating);
    }
    public override Statistics ShowStatistics()
    {
      var result = new Statistics();
      for (var index = 0; index < ratings.Count; index++)
      {
        result.Add(ratings[index]);
      }
      return result;
    }

    public override void ChangeBookTitle(string title)
    {
      bool isDigit = false;
      foreach (var letter in title)
      {
        if (char.IsDigit(letter))
        {
          isDigit = true;
        }
      }
      if (title == "")
      {
        Console.WriteLine("Title can`t be empty. Title has not been changed. Please enter valid book title");
      }
      else if (!isDigit)
      {
        this.Title = title;
        Console.WriteLine($"The new title is {Title}");
      }
      else
      {
        Console.WriteLine("There is a number in given title. It is not allowed.");
      }
    }
  }
}