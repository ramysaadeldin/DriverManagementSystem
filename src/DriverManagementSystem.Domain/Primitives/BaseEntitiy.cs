namespace DriverManagementSystem.Domain.Primitives
{
    public abstract class BaseEntitiy<TId>
    {
        public TId Id { get; init; }
    }
}
