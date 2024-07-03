namespace si730ebu202217239.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}