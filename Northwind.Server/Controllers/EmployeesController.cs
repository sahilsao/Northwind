using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Server.Domain;
using Northwind.Server.Extensions;
using Northwind.Server.Persistence;
using Northwind.Shared.Constants;
using Northwind.Shared.Employees;

namespace Northwind.Server.Controllers;

[ApiController]
public class EmployeesController(NorthwindDataContext northwindDataContext) : Controller
{   
    [HttpGet(Routes.Api.Employees.GetAll)]
    public async Task<ActionResult<List<EmployeesDto>>> GetAll()
    {
        var employees = await northwindDataContext.Employees
        .ProjectToDtos()
        .ToListAsync();
        return Ok(employees);
    }
    
    [HttpGet(Routes.Api.Employees.GetById)]
    public async Task<ActionResult<Employees?>> GetById(int id)
    {
        var employee = await northwindDataContext.Employees
        .ProjectToDtos()
        .FirstOrDefaultAsync(x => x.EmployeeId == id);

        if (employee == null)
            return NotFound();
        
        return Ok(employee);
    }
    
    [HttpPost(Routes.Api.Employees.Add)]
    public async Task<ActionResult> Add(Employees employee)
    {
        northwindDataContext.Employees.Add(employee);
        await northwindDataContext.SaveChangesAsync();

        return Created();
    }
    
    [HttpPut(Routes.Api.Employees.Update)]
    public async Task<ActionResult> Update(Employees updatedEmployee)
    {
        var existingEmployee = await northwindDataContext.Employees.FindAsync(updatedEmployee.EmployeeId);

        if (existingEmployee == null)
            return NotFound();
        
        existingEmployee.FirstName = updatedEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName;
        existingEmployee.Title = updatedEmployee.Title;
        existingEmployee.BirthDate = updatedEmployee.BirthDate;
        
        await northwindDataContext.SaveChangesAsync();

        return Ok();
    }
    
    [HttpDelete(Routes.Api.Employees.Delete)]
    public async Task<ActionResult> Delete(int id)
    {
        var existingEmployee = await northwindDataContext.Employees.FindAsync(id);

        if (existingEmployee == null)
            return NotFound();
        
        northwindDataContext.Employees.Remove(existingEmployee);
        await northwindDataContext.SaveChangesAsync();

        return Ok();
    }
}