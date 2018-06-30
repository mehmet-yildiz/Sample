namespace Sample.Core.Entity
{
    public interface IEntity<T>
    {
        T Id { get; }
    }
}