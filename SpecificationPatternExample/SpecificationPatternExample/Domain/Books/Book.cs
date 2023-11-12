using Bogus;

namespace SpecificationPatternExample.Domain.Books;

public class Book
{
    public string Title { get; set; }
    public string Author { get; private set; }
    public int Pages { get; set; }

    public Book()
    {
        
    }

    public Book(string title, string author, int pages)
    {
        Title = title;
        Author = author;
        Pages = pages;
    }
}

public class BookFaker : Faker<Book>
{
    public BookFaker()
    {
        Random random = new Random();
        int randomInteger = random.Next(0, 100);
        
        RuleFor(t => t.Title, f => f.Commerce.ProductName());
        RuleFor(a => a.Author, f => f.Name.FullName());
        RuleFor(p => p.Pages, randomInteger);
    }
}