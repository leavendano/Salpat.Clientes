using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.TransaccionAggregate;

namespace Salpat.Clientes.Infrastructure.Data.Config;

public class TransaccionConfiguration : IEntityTypeConfiguration<Transaccion>
{
  public void Configure(EntityTypeBuilder<Transaccion> builder)
  {
    
    // builder.Property(p => p.Nombre)
    //     .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
    //     .IsRequired();
      
    builder.HasOne<Cliente>()    
        .WithMany()
        .HasForeignKey(x => x.ClienteId );

    builder.HasIndex(c => c.HoseDeliveryId).IsUnique();
    

  }



}
