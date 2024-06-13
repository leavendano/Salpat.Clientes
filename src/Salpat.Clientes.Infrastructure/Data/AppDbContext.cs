using System.Reflection;
using Ardalis.SharedKernel;
using Salpat.Clientes.Core.ContributorAggregate;
using Microsoft.EntityFrameworkCore;
using Salpat.Clientes.Core.Base;
using Salpat.Clientes.Core.ClienteAggregate;

namespace Salpat.Clientes.Infrastructure.Data;
public class AppDbContext : DbContext
{
  private readonly IDomainEventDispatcher? _dispatcher;

  public AppDbContext(DbContextOptions<AppDbContext> options,
    IDomainEventDispatcher? dispatcher)
      : base(options)
  {
    _dispatcher = dispatcher;
  }

  public DbSet<Contributor> Contributors => Set<Contributor>();
  public DbSet<Cliente> Clientes => Set<Cliente>();

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
          => optionsBuilder.UseSnakeCaseNamingConvention();

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);
    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
  }

  public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
  {

    var entries = ChangeTracker.Entries<RegisterBase>().
                 Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entityEntry in entries)
            {
                entityEntry.Entity.UpdatedAt = DateTime.UtcNow;

                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Entity.CreatedAt = DateTime.UtcNow;
                }
            }


    int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

    // ignore events if no dispatcher provided
    if (_dispatcher == null) return result;

    // dispatch events only if save was successful
    var entitiesWithEvents = ChangeTracker.Entries<EntityBase>()
        .Select(e => e.Entity)
        .Where(e => e.DomainEvents.Any())
        .ToArray();

    await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

    return result;
  }

  public override int SaveChanges() =>
        SaveChangesAsync().GetAwaiter().GetResult();
}
