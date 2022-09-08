
using System;
using System.Collections.Generic;

namespace BookRatingApp
{
  public class BookObject
  {
    public BookObject(string title)
    {
      this.Title = title;
    }
    public string Title { get; set; }
  }
}