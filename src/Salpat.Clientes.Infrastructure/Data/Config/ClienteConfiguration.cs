﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Salpat.Clientes.Core.ClienteAggregate;
using Salpat.Clientes.Core.EmpresaAggregate;
using Salpat.Clientes.Core.TransaccionAggregate;

namespace Salpat.Clientes.Infrastructure.Data.Config;

public class ClinteConfiguration : IEntityTypeConfiguration<Cliente>
{
  public void Configure(EntityTypeBuilder<Cliente> builder)
  {
    

    builder.Property(p => p.Nombre)
        .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
        .IsRequired();
      
    builder.Property(p => p.Telefono)
        .HasMaxLength(DataSchemaConstants.DEFAULT_PHONE_LENGTH)
        .IsRequired();
        
    builder.Property(p => p.Email)
        .HasMaxLength(DataSchemaConstants.DEFAULT_EMAIL_LENGTH)
        .IsRequired();

    builder.HasMany<Transaccion>()
        .WithOne();

     builder.HasOne<Empresa>()    
        .WithMany()
        .HasForeignKey(x => x.EmpresaId);

    builder.HasIndex(c => c.Telefono).IsUnique();
    builder.HasIndex(c => c.Email).IsUnique();

  }



}
