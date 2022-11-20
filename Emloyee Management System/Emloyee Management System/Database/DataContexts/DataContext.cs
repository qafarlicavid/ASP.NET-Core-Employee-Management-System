using Microsoft.EntityFrameworkCore;
using Emloyee_Management_System.Database.Models;

namespace Emloyee_Management_System.Database.DataContexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-K3NUSRU;Database=EmployeeMS;Trusted_Connection=True;TrustServerCertificate=True;");
        }
        public DbSet<Employee> Employee { get; set; }

        public class TablePkAutoincrement
        {
            static Random randomCode = new Random();

            public static string RandomEmpCode
            {
                get
                {
                    DataContext dbContext = new DataContext();

                    var employees = dbContext.Employee.ToList();

                    string _empCode = "E" + randomCode.Next(10000, 100000);

                    foreach (var employee in employees)
                    {
                        if (employee.EmployeeCode == _empCode)
                        {
                            do
                            {
                                _empCode = "E" + randomCode.Next(10000, 100000);

                            } while (employee.EmployeeCode != _empCode);
                        }
                    }
                    return _empCode;
                }
            }
        }
    }
}
