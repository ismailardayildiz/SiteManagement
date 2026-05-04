using SiteManagement.Entity.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<List<EmployeeListDto>> GetAllEmployeesAsync();
        Task<EmployeeUpdateDto> GetEmployeeByIdAsync(Guid employeeId);
        Task CreateEmployeeAsync(EmployeeAddDto employeeAddDto);
        Task UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto);
        Task SafeDeleteEmployeeAsync(Guid employeeId);
    }
}
