using Microsoft.EntityFrameworkCore;
using Northwind.Server.Domain;

namespace Northwind.Server.Persistence;

public class EmployeesDataContext(DbContextOptions<EmployeesDataContext> options) : DbContext(options)
{
    public DbSet<Employees> Employees { get; set; }
}

    
