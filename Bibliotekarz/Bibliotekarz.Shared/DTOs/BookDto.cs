namespace Bibliotekarz.Shared.DTOs;

public class BookDto
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Author { get; set; }

    public int PageCount { get; set; }

    public bool IsBorrowed { get; set; }

    public CustomerDto? Borrower { get; set; }
}
