namespace SpecificationPatternExample.Specs;

/// <summary>
/// This is the Specification base class
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class Specification<T> : ISpecification<T>
{
    public abstract bool IsSatisfiedBy(T item);

    public Specification<T> And(Specification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }

    public Specification<T> Or(Specification<T> specification)
    {
        return new OrSpecification<T>(this, specification);
    }
}

/// <summary>
/// This is the Composite class for Specification
/// </summary>
/// <typeparam name="T"></typeparam>
public class AndSpecification<T> : Specification<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public AndSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left ?? throw new ArgumentNullException(nameof(left));
        _right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override bool IsSatisfiedBy(T item)
    {
        return _left.IsSatisfiedBy(item) && _right.IsSatisfiedBy(item);
    }
}

public class OrSpecification<T> : Specification<T>
{
    private readonly ISpecification<T> _left;
    private readonly ISpecification<T> _right;

    public OrSpecification(ISpecification<T> left, ISpecification<T> right)
    {
        _left = left ?? throw new ArgumentNullException(nameof(left));
        _right = right ?? throw new ArgumentNullException(nameof(right));
    }

    public override bool IsSatisfiedBy(T item)
    {
        return _left.IsSatisfiedBy(item) || _right.IsSatisfiedBy(item);
    }
}