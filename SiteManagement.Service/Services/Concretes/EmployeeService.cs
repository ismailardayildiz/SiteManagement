using AutoMapper;
using SiteManagement.Data.UnitOfWorks;
using SiteManagement.Entity.DTOs.Employees;
using SiteManagement.Entity.Entities;
using SiteManagement.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiteManagement.Service.Services.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<EmployeeListDto>> GetAllEmployeesAsync()
        {
            var employees = await _unitOfWork.GetRepository<Employee>().GetAllAsync(x => x.IsActive, x => x.Site);
            return _mapper.Map<List<EmployeeListDto>>(employees);
        }

        public async Task<EmployeeUpdateDto> GetEmployeeByIdAsync(Guid employeeId)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetAsync(x => x.Id == employeeId);
            return _mapper.Map<EmployeeUpdateDto>(employee);
        }

        public async Task CreateEmployeeAsync(EmployeeAddDto employeeAddDto)
        {
            var employee = _mapper.Map<Employee>(employeeAddDto);
            await _unitOfWork.GetRepository<Employee>().AddAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeUpdateDto employeeUpdateDto)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetAsync(x => x.Id == employeeUpdateDto.Id);
            _mapper.Map(employeeUpdateDto, employee);

            await _unitOfWork.GetRepository<Employee>().UpdateAsync(employee);
            await _unitOfWork.SaveAsync();
        }

        public async Task SafeDeleteEmployeeAsync(Guid employeeId)
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetAsync(x => x.Id == employeeId);
            employee.IsActive = false; // Soft Delete
            employee.TerminationDate = DateTime.Now; // Çıkış tarihi

            await _unitOfWork.GetRepository<Employee>().UpdateAsync(employee);
            await _unitOfWork.SaveAsync();
        }
    }
}