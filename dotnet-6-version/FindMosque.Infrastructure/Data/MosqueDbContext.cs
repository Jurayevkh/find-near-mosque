using FindMosque.Application.Abstraction;
using FindMosque.Domain.Entities.Mosque;
using Microsoft.EntityFrameworkCore;

namespace FindMosque.Infrastructure.Data;

public class MosqueDbContext:DbContext, IApplicationDbContext
{
    public MosqueDbContext(DbContextOptions<MosqueDbContext> options) : base(options)
    { }

    public DbSet<Mosque> Mosque { get; set; }
}

