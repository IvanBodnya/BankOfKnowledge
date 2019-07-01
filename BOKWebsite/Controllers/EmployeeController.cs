using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BOKWebsite.Models;

namespace BOKWebsite.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<EmployeeModel> employeeModels = _context.Employee.ToList();

            return View(employeeModels);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            EmployeeModel employeeModel = await _context.Employee.FindAsync(id);
            return View(employeeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName")] EmployeeModel employeeModel)
        {
            _context.Update(employeeModel);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}