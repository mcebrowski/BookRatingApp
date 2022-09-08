using System;
using BookRatingApp;
using Xunit;

namespace BookRatingApp.Tests
{
  public class TestStatistics
  {
    [Fact]
    public void DoesStatisticsWorks()
    {

      var statistics = new Statistics();
      statistics.Add(9.7);
      statistics.Add(8.8);
      statistics.Add(9.3);
      statistics.Add(8.7);

      Assert.Equal(9.125, statistics.Average);
      Assert.Equal(9.7, statistics.High);
      Assert.Equal(8.7, statistics.Low);
      Assert.Equal("A", statistics.Letter);
    }
  }
}
