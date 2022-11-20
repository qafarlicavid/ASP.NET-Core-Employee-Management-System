
using Emloyee_Management_System.Database.DataContexts;
using Emloyee_Management_System.Database.Models;
using Emloyee_Management_System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Emloyee_Management_System.Database.DataContexts.DataContext;

namespace Emloyee_Management_System.Controllers
{
    [Route("employee")]
    public class EmployeeController : Controller
    {
        #region List

        [HttpGet("list", Name = "employee-list")]
        public ActionResult List()
        {
            using DataContext dbContext = new DataContext();
            var employees = dbContext.Employee
                .Select(b => new ListViewModel(b.EmployeeCode, b.FirstName, b.LastName, b.FatherName,b.IsDeleted))
                .ToList();
            return View(employees);

        }
        #endregion


        #region Add

        [HttpGet("add", Name = "employee-add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost("add", Name = "employee-add")]
        public ActionResult Add(AddViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using DataContext dbContext = new DataContext();
            dbContext.Employee.Add(new Employee
            {

                EmployeeCode = TablePkAutoincrement.RandomEmpCode,
                FirstName = model.FirstName,
                LastName = model.LastName,
                FatherName = model.FatherName,
                Fin = model.Fin,
                Email = model.Email,
                IsDeleted = default
            });


            dbContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        #endregion


        #region Update
        [HttpGet("update/{empcode}", Name = "employee-update")]
        public ActionResult Update(string empCode)
        {
            using DataContext dbContext = new DataContext();

            var employee = dbContext.Employee.FirstOrDefault(b => b.EmployeeCode == empCode);
            if (employee is null && employee.IsDeleted == true)
            {
                return NotFound();
            }

            return View(new UpdateViewModel { FirstName = employee.FirstName, LastName = employee.LastName, FatherName = employee.FatherName, Email = employee.Email, Fin = employee.Fin, EmpCode = employee.EmployeeCode });
        }

        [HttpPost("update/{empcode}", Name = "employee-update")]
        public ActionResult Update(UpdateViewModel model)
        {
            using DataContext dbContext = new DataContext();
            var employee = dbContext.Employee.FirstOrDefault(b => b.EmployeeCode == model.EmpCode);
            if (employee == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            employee.FirstName = model.FirstName;
            employee.LastName = model.LastName;
            employee.FatherName = model.FatherName;
            employee.Email = model.Email;
            employee.Fin = model.Fin;


            dbContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        #endregion


        #region Delete


        [HttpGet("Delete/{empcode}", Name = "employee-delete")]
        public ActionResult Delete(string empcode)
        {
            using DataContext dbContext = new DataContext();
            var employee = dbContext.Employee.FirstOrDefault(e => e.EmployeeCode == empcode);

            if (employee == null)
            {
                return NotFound();
            }

            employee.IsDeleted = true;

            dbContext.SaveChanges();
            return RedirectToAction(nameof(List));
        }
        #endregion

    }
}
