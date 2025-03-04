using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Server.Domain;

namespace Northwind.Server.Persistence.Configurations;

public class NorthwindConfiguration: IEntityTypeConfiguration<Employees>
{
    public void Configure(EntityTypeBuilder<Employees> builder)
    {
        builder.HasKey(x => x.EmployeeId);
        
        builder.Property(x => x.FirstName)
            .IsRequired().HasMaxLength(20);
        
        builder.Property(x => x.LastName)
            .IsRequired().HasMaxLength(20);
        
        builder.ToTable("Employees");
    }
}