using Northwind.Server.Domain;
using Northwind.Shared.Employees;
using Riok.Mapperly.Abstractions;

namespace Northwind.Server.Extensions;

[Mapper]
public static partial class MapperExtensions
{
    public static partial IQueryable<EmployeesDto> ProjectToDtos(this IQueryable<Employees> queryable);   

}
