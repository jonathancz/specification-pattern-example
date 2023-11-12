namespace SpecificationPatternExample.Specs;

public interface ISpecification<T>
{
    bool IsSatisfiedBy(T item);
}