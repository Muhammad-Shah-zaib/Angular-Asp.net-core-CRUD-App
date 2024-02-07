using CRUDDotnetApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CRUDDotnetApi.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        // creating the table in the DB
        DbSet<Employee> employee { get; set; }
    }
}
