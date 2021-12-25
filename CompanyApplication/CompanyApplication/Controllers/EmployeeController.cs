using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controllers
{
    public class EmployeeController
    {
        private EmployeeService _employeeService { get; }
        private CompanyService _companyService { get; }
        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }
        public void Create()
        {
            EnterOption: Helper.WriteToConsole(ConsoleColor.Cyan, "Add name for employee: ");
            string employeeName = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add surname for employee: ");
            string employeeSurname = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add age for employee: ");
            string Age = Console.ReadLine();

            int employeeAge;
            bool isTrueAge = int.TryParse(Age, out employeeAge);

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company's Id: ");
            string Id = Console.ReadLine();

            int companyId;
            bool isTrueId = int.TryParse(Id, out companyId);
            if (isTrueAge && isTrueId)
            {
                if (string.IsNullOrEmpty(employeeName) || string.IsNullOrEmpty(employeeSurname))
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                    goto EnterOption;
                }
                else
                {
                    Employee employee = new Employee
                    {
                        Name = employeeName,
                        Surname = employeeSurname,
                        Age = employeeAge,

                    };
                    var result = _employeeService.Create(employee, companyId);
                    if (result != null)
                    {
                        Helper.WriteToConsole(ConsoleColor.Green, $"ID: {employee.Id} - Name: {employee.Name} - Surname: {employee.Surname} employee in {employee.Company.Name} created");
                    }
                    else
                    {
                        Helper.WriteToConsole(ConsoleColor.Red, "Company not found");
                        goto EnterOption;
                    }
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterOption;
            }
        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add employee's Id: ");
            EnterId: string employeeId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var employee1 = _employeeService.GetById(id);

                if (employee1 == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee not found.");
                    
                }
                else
                {
                    Helper.WriteToConsole(ConsoleColor.Green, $"ID: {employee1.Id} - Name: {employee1.Name} - Surname: {employee1.Surname} works in {employee1.Company.Name}");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterId;
            }
        }
        public void Update()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add employee's ID:");
            EnterId: string companyId = Console.ReadLine();
            int id;
            bool isIdTrue = int.TryParse(companyId, out id);

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add new name for employee:");
            string newName = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add new surname for employee:");
            string newSurname = Console.ReadLine();

            Helper.WriteToConsole(ConsoleColor.Cyan, "Add new age for employee:");
            string newAge = Console.ReadLine();

            int age;
            bool isAgeTrue = int.TryParse(newAge, out age);

            if (isIdTrue)
            {
                Employee employee = new Employee
                {
                    Name = newName,
                    Surname = newSurname,
                    Age = age
                };

                Employee newEmployee = _employeeService.Update(id, employee);

                Helper.WriteToConsole(ConsoleColor.Green, $"ID: {newEmployee.Id} - New name: {newEmployee.Name} - New surname: {newEmployee.Surname} - New age: {newEmployee.Age}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Employee was not found. Try again:");
                goto EnterId;
            }
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add employee's ID:");
        EnterId: string employeeId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(employeeId, out id);

            if (isIdTrue)
            {
                var result = _employeeService.GetById(id);

                if (result == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Employee not found. Enter employee's ID again:");
                    goto EnterId;
                }
                else
                {
                    _employeeService.Delete(result);
                    Helper.WriteToConsole(ConsoleColor.Green, $"Employee was deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again:");
                goto EnterId;
            }
        }
    }
}
