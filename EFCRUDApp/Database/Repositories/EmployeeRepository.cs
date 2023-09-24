using EFCRUDApp.Database.Entities;

using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace EFCRUDApp.Database.Repositories;

public class EmployeeRepository
{
    private readonly AppDbContext _dbContext;

    public EmployeeRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateEmployeeAsync(Employee employee)
    {
        await _dbContext.Employee.AddAsync(employee);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Employee> GetEmployeeAsync(int id)
    {
        return await _dbContext.Employee.FindAsync(id);
    }

    public IQueryable<Employee> GetAllEmployees()
    {
        return _dbContext.Employee.AsQueryable();
    }

    public async Task UpdateEmployeeAsync(Employee updatedEmployee)
    {
        _dbContext.Entry(updatedEmployee).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
    }

    public async Task DeleteEmployeeAsync(int id)
    {
        var employeeToDelete = await _dbContext.Employee.FindAsync(id);

        if (employeeToDelete != null)
        {
            _dbContext.Employee.Remove(employeeToDelete);
            await _dbContext.SaveChangesAsync();
        }
    }
}
