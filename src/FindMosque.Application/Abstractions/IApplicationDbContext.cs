using FindMosque.Domain.Entities.Mosque;
using Microsoft.EntityFrameworkCore;

namespace FindMosque.Application.Abstractions;

public interface IApplicationDbContext
{
    public DbSet<Mosque> Mosque { get; set; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

}

