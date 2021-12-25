using Domain.Models;
using Repository.Exceptions;
using Repository.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {
        private EmployeeRepository _employeeRepository { get; }
        private CompanyRepository _companyRepository { get; }
        private int Count { get; set; }
        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
            _companyRepository = new CompanyRepository();
        }

        public Employee Create(Employee model, int companyId)
        {
            try
            {
                Company company = _companyRepository.Get(m => m.Id == companyId);
                if (company == null) throw new CustomException("Company was not found");

                model.Id = Count;
                model.Company = company;
                _employeeRepository.Create(model);
                Count++;
                return model;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public void Delete(Employee model)
        {
            _employeeRepository.Delete(model);
        }

        public Employee GetById(int id)
        {
            return _employeeRepository.Get(m => m.Id == id);
        }

        public Employee GetEmployeeByAge(int age)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeByCompanyId(Company id)
        {
            throw new NotImplementedException();
        }

        public Employee Update(int id, Employee model)
        {
            var employee = GetById(id);
            model.Id = employee.Id;
            _employeeRepository.Update(model);
            return model;
        }
    }
}
