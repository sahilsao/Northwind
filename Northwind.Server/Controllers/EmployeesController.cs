using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Northwind.Server.Domain;
using Northwind.Server.Persistence;

namespace Northwind.Server.Controllers;

[ApiController, Route("api/employees")]
public class EmployeesController(NorthwindDataContext northwindDataContext) : Controller
{   
    [HttpGet("")]
    public async Task<ActionResult<List<Employees>>> GetAll()
    {
        var employees = await northwindDataContext.Employees.ToListAsync();
        return Ok(employees);
    }
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Employees?>> GetById(int id)
    {
        var employee = await northwindDataContext.Employees.FindAsync(id);

        if (employee == null)
            return NotFound();
        
        return Ok(employee);
    }
    
    [HttpPost("")]
    public async Task<ActionResult> Add(Employees employee)
    {
        northwindDataContext.Employees.Add(employee);
        await northwindDataContext.SaveChangesAsync();

        return Created();
    }
    
    [HttpPut("")]
    public async Task<ActionResult> Update(Employees updatedEmployee)
    {
        var existingEmployee = await northwindDataContext.Employees.FindAsync(updatedEmployee.EmployeeId);

        if (existingEmployee == null)
            return NotFound();
        
        existingEmployee.Title = updatedEmployee.Title;
        existingEmployee.FirstName = updatedEmployee.FirstName;
        existingEmployee.LastName = updatedEmployee.LastName;

        await northwindDataContext.SaveChangesAsync();

        return Ok();
    }
    
    [HttpDelete("{id:int}")]
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