using SpecificationPatternExample.Specs;

namespace SpecificationPatternExample.Domain.Books.Specifications;

public class TitleContainsWord : Specification<Book>
{
    private readonly string _word;

    public TitleContainsWord(string word)
    {
        _word = word ?? throw new ArgumentNullException(nameof(word));
    }

    public override bool IsSatisfiedBy(Book book)
    {
        return book.Title.Contains(_word, StringComparison.OrdinalIgnoreCase);
    }
}