using Microsoft.AspNetCore.Routing.Matching;
using SpecificationPatternExample.Specs;

namespace SpecificationPatternExample.Domain.Books.Specifications;

public class HasManyPages : Specification<Book>
{
    private readonly int _pageThreshold;

    public HasManyPages()
    {
        _pageThreshold = 10;
    }

    public HasManyPages(int pageThreshold)
    {
        _pageThreshold = pageThreshold;
    }

    public override bool IsSatisfiedBy(Book book)
    {
        return book.Pages > _pageThreshold;
    }
}