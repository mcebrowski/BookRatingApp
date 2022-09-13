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
        var letter = Average switch
        {
          >= 9 => "A",
          < 9 and >= 8 => "B",
          < 8 and >= 7 => "C",
          < 7 and >= 6 => "D",
          < 6 and >= 5 => "E",
          _ => "F"
        };
        return letter;
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