namespace Bibliotekarz.Data.Model;

public class Book : BaseEntity
{
    public string Author { get; set; }

    public string? Title { get; set; }

    public int PageCount { get; set; }

    public bool IsBorowed { get; set; }

    public Customer? Borrower { get; set; }
}
