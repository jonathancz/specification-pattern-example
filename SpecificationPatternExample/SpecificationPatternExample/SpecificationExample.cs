using SpecificationPatternExample.Domain.Books;
using SpecificationPatternExample.Domain.Books.Specifications;
using Xunit;

namespace SpecificationPatternExample;

public class SpecificationExample
{
    private readonly List<Book> _listOfBooks;
    
    public SpecificationExample()
    {
        // Generate 100 books
        _listOfBooks = new BookFaker().Generate(500);
    }

    [Fact]
    public void CanQueryListOfBooksWithSpecification()
    {
        var spec = new HasManyPages().And(new TitleContainsWord("Soap")); // Potential match
        var result =  _listOfBooks.Where(book => spec.IsSatisfiedBy(book)).ToList();
        
        Assert.NotEmpty(result);
    }
}