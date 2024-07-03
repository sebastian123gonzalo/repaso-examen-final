using si730ebu202217239.Shared.Domain.Repositories;
using si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace si730ebu202217239.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context) => _context = context;

    public async Task CompleteAsync() => await _context.SaveChangesAsync();
}