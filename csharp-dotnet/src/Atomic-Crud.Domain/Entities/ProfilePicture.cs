using Atomic_Crud.Domain.Entities.Contracts;

namespace Atomic_Crud.Domain.Entities
{
    public class ProfilePicture : IEntity<Guid>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
