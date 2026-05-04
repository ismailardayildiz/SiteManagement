using Microsoft.AspNetCore.Mvc;
using SiteManagement.Entity.DTOs.Employees;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Threading.Tasks;

namespace SiteManagement.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        // DataTables için JSON verisi döner
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Json(new { data = employees });
        }

        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("Add", new EmployeeAddDto());
        }

        [HttpPost]
        public async Task<IActionResult> Add(EmployeeAddDto employeeAddDto)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.CreateEmployeeAsync(employeeAddDto);
                return Json(new { isValid = true });
            }
            return PartialView("Add", employeeAddDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return PartialView("Update", employee);
        }

        [HttpPost]
        public async Task<IActionResult> Update(EmployeeUpdateDto employeeUpdateDto)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employeeUpdateDto);
                return Json(new { isValid = true });
            }
            return PartialView("Update", employeeUpdateDto);
        }

        [HttpPost]
        public async Task<IActionResult> SafeDelete(Guid id)
        {
            await _employeeService.SafeDeleteEmployeeAsync(id);
            return Json(new { success = true });
        }
    }
}