using CRUDDotnetApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CRUDDotnetApi.Data
{
    public class EmployeeRepo(AppDbContext db)
    {
        private readonly AppDbContext db = db;

        public async Task AddEmpAsync( Employee emp)
        {
            await this.db.Set<Employee>().AddAsync( emp );
            await this.db.SaveChangesAsync();

        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            return await this.db.Set<Employee>().ToListAsync();
        }

        // This method will delete a paarticular employee from db
        public async Task DeleteEmployeeAsync(int id)
        {
            // getting the employee
            var emp = this.db.Set<Employee>().Find(id);
            // checking if the employee exixt or not
            if (emp == null)
            {
                throw new Exception("Employee not Found.");
            }
            // removing the employee from db
            this.db.Set<Employee>().Remove(emp);
            await this.db.SaveChangesAsync();
        }
        // this method will get only one employee via id
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var emp = await this.db.Set<Employee>().FindAsync(id);
            // cehcking for employee in db
            return emp ?? throw new Exception("Employee not Found");
        }

        // this method will update the employee via id and model
        public async Task UpdateEmployeeAsync(int id, Employee model)
        {
            // fetching the employee
            var emp = this.db.Set<Employee>().Find(id);
            // checking if the employee exist or not
            if (emp == null)
            {
                throw new Exception("Employee not Found");
            }
            // updating th emp
            emp.Name = model.Name;
            emp.phone = model.phone;
            emp.Age = model.Age;
            emp.Salary= model.Salary;

            // saving the canges
            await this.db.SaveChangesAsync();
        }
    }
}
