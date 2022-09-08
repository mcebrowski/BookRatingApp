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
  }
}