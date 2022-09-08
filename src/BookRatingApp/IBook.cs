using System;
using System.Collections.Generic;

namespace BookRatingApp
{
  public delegate void RatingAddedDelegate(object sender, EventArgs args, double rating);

  public interface IBook
  {
    void AddRating(string rating);

    string Title { get; set; }

    void ChangeBookTitle(string title);

    Statistics ShowStatistics();

    event RatingAddedDelegate RatingAdded;
  }
}