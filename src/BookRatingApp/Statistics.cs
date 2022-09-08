using System;

namespace BookRatingApp
{
  public class Statistics
  {

    public double High;
    public double Low;
    public double Sum;
    public int Count;

    public Statistics()
    {
      Count = 0;
      Sum = 0.0;
      High = double.MinValue;
      Low = double.MaxValue;
    }

    public double Average
    {
      get
      {
        return Sum / Count;
      }
    }
    public string Letter
    {
      get
      {
        switch (Average)
        {
          case var d when d >= 9: return "A";
          case var d when d >= 8: return "B";
          case var d when d >= 7: return "C";
          case var d when d >= 6: return "D";
          case var d when d >= 5: return "E";
          default: return "F";
        }
      }
    }
    public void Add(double number)
    {
      Sum += number;
      Count += 1;
      Low = Math.Min(number, Low);
      High = Math.Max(number, High);
    }
  }
}