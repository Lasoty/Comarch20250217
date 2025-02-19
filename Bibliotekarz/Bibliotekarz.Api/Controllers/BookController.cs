using Bibliotekarz.Data.Context;
using Bibliotekarz.Data.Model;
using Bibliotekarz.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly AppDbContext dbContext;

    public BookController(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<BookDto> result =
            dbContext.Books.Include(book => book.Borrower)
                .OrderBy(book => book.Author).ThenBy(book => book.Title)
                .Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    IsBorrowed = book.IsBorowed,
                    Borrower = book.Borrower != null ?
                    new CustomerDto()
                    {
                        Id = book.Borrower.Id,
                        FirstName = book.Borrower.FirstName,
                        LastName = book.Borrower.LastName,
                    } : null
                }).ToList();


        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Add(BookDto book)
    {
        Book bookEntity = new Book()
        {
            Title = book.Title,
            Author = book.Author,
            IsBorowed = book.IsBorrowed,
            Borrower = book.Borrower != null ?
                new Customer()
                {
                    FirstName = book.Borrower.FirstName,
                    LastName = book.Borrower.LastName,
                } : null,
        };

        dbContext.Books.Add(bookEntity);
        await dbContext.SaveChangesAsync();

        book.Id = bookEntity.Id;
        if (bookEntity.Borrower != null)
            book.Borrower.Id = bookEntity.Borrower.Id;

        return Created($"Book/{bookEntity.Id}", book);
    }
}
