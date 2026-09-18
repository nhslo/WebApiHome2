using Microsoft.AspNetCore.Mvc;
using WebApiHome2.Models;

namespace WebApiHome2.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private static readonly List<Book> Books = new()
    {
        new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin", Year = 2008 },
        new Book { Id = 2, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = 1937 }
    };

    [HttpGet]
    public ActionResult<List<Book>> GetBooks() => Ok(Books);

    [HttpPost]
    public ActionResult<Book> AddBook(Book book)
    {
        book.Id = Books.Count == 0 ? 1 : Books.Max(item => item.Id) + 1;
        Books.Add(book);
        return Ok(book);
    }
}
