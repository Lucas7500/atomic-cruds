namespace Atomic_Crud.Domain.Entities.Contracts
{
    public interface IEntity<TKey> where TKey : struct
    {
        TKey Id { get; init; }
    }
}
