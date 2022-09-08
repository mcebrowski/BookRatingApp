using System;
using System.IO;
using System.Collections.Generic;

namespace BookRatingApp
{
  public class InFileBook : BookBase
  {
    private const string auditFile = "Audit.txt";

    public InFileBook(string title) : base(title)
    {
      RatingAdded += OnRatingAdded;
    }

    public override void SaveRating(double rating)
    {
      using (var writer = File.AppendText($"{Title}.txt"))
      {
        writer.WriteLine(rating);
      }
      using (var audit = File.AppendText($"{Title}_{auditFile}"))
      {
        var date = DateTime.UtcNow;
        audit.WriteLine($"{date} - {rating}");
      }
    }

    public override void ChangeFileName(string oldTitle, string newTitle)
    {

      string oldFileName = $"{oldTitle}.txt";
      string oldAuditFileName = $"{oldTitle}_{auditFile}";

      string newFileName = $"{newTitle}.txt";
      string newAuditFileName = $"{newTitle}_{auditFile}";

      if (File.Exists(newFileName))
      {
        Console.WriteLine($"The file for {newTitle} already exist. Please rename the book once again");
      }
      else if (File.Exists(oldFileName))
      {
        System.IO.File.Move(oldFileName, newFileName);
        System.IO.File.Move(oldAuditFileName, newAuditFileName);
        Console.WriteLine($"The file has been renemed from {oldTitle} to {newTitle}");
      }
      else
      {
        Console.WriteLine("File will be created when you enter at least one rating. Please do so.");
      }
    }

    public override Statistics ShowStatistics()
    {
      string validFile = $"{Title}.txt";

      var result = new Statistics();

      if (File.Exists(validFile))
      {
        using (var reader = File.OpenText($"{Title}.txt"))
        {
          var line = reader.ReadLine();
          while (line != null)
          {
            var rating = double.Parse(line);
            result.Add(rating);
            line = reader.ReadLine();
          }
        }
      }
      else
      {
        result = null;
      }
      return result;
    }

  }
}