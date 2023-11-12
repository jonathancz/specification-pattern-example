using Microsoft.AspNetCore.Routing.Matching;
using SpecificationPatternExample.Specs;

namespace SpecificationPatternExample.Domain.Books.Specifications;

public class AuthorContainsName : Specification<Book>
{
    private readonly string _name;

    public AuthorContainsName(string name)
    {
        _name = name;
    }
    
    public override bool IsSatisfiedBy(Book item)
    {
        return item.Author.Contains(_name, StringComparison.OrdinalIgnoreCase);
    }
}