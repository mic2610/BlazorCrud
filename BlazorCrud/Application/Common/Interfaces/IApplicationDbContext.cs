using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<SuperHero> SuperHeroes { get; set; }

        DbSet<Comic> Comics { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        int SaveChanges();

        int SaveChanges(bool acceptAllChangesOnSuccess);
    }
}
