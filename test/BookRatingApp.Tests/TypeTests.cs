using System;
using BookRatingApp;
using Xunit;

namespace BookRatingApp.Tests
{
  public class TypeTests
  {

    public delegate string WriteMessage(string message);

    int counter = 0;

    [Fact]
    public void WriteMessageDelegateCanPointToMethod()
    {
      WriteMessage del = ReturnMessage;

      del += ReturnMessage;
      del += ReturnMessage2;

      var result = del("Hello!");

      Assert.Equal(3, counter);
    }

    string ReturnMessage(string message)
    {
      counter++;
      return message;
    }

    string ReturnMessage2(string message)
    {
      counter++;
      return message.ToUpper();
    }

    [Fact]
    public void GetBookReturnsDifferentsObject()
    {
      var book1 = GetBook("Harry Potter");
      var book2 = GetBook("Game of Thrones");

      Assert.Equal("Harry Potter", book1.Title);
      Assert.Equal("Game of Thrones", book2.Title);

      Assert.NotSame(book1, book2);
      Assert.False(Object.ReferenceEquals(book1, book2));
    }

    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
      var book1 = GetBook("Harry Potter");
      var book2 = book1;

      Assert.Same(book1, book2);
      Assert.True(Object.ReferenceEquals(book1, book2));
    }

    [Fact]
    private void CanSetTitleFromReference()
    {
      var book1 = new InFileBook("Game of Thrones");
      this.SetTitle(book1, "The Godfather");
      Assert.Equal("The Godfather", book1.Title);
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
      var book1 = GetBook("The Godfather");
      GetBookSetTitle(out book1, "Game of Thrones");
      Assert.Equal("Game of Thrones", book1.Title);
    }

    private void GetBookSetTitle(out InFileBook book, string title)
    {
      book = new InFileBook(title);
    }

    private InFileBook GetBook(string title)
    {
      return new InFileBook(title);
    }
    private void SetTitle(InFileBook book, string title)
    {
      book.Title = title;
    }
  }
}