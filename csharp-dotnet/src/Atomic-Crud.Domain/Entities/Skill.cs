using Atomic_Crud.Domain.Entities.Contracts;

namespace Atomic_Crud.Domain.Entities
{
    public class Skill : IEntity<Guid>
    {
        public Guid Id { get; init; } = Guid.NewGuid();
    }
}
