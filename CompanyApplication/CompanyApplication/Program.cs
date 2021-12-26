using CompanyApplication.Controllers;
using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;

namespace CompanyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyController companyController = new CompanyController();
            EmployeeController employeeController = new EmployeeController();
            
            Helper.WriteToConsole(ConsoleColor.Yellow, "Select options");

            while (true)
            {
                GetMenus();

                EnterOption: string selectOption = Console.ReadLine();

                int option;
                bool isTrueOption = int.TryParse(selectOption, out option);

                if (isTrueOption)
                {
                    switch (option)
                    {
                        case (int)MyEnums.Menus.CreateCompany:
                            companyController.Create();
                            break;
                        case (int)MyEnums.Menus.UpdateCompany:
                            companyController.Update();
                            break;
                        case (int)MyEnums.Menus.DeleteCompany:
                            companyController.Delete();
                            break;
                        case (int)MyEnums.Menus.GetCompanyById:
                            companyController.GetById();
                            break;
                        case (int)MyEnums.Menus.GetAllCompanyByName:
                            companyController.GetAllByName();
                            break;
                        case (int)MyEnums.Menus.GetAllCompany:
                            companyController.GetAll();
                            break;
                        case (int)MyEnums.Menus.CreateEmployee:
                            employeeController.Create();
                            break;
                        case (int)MyEnums.Menus.UpdateEmployee:
                            employeeController.Update();
                            break;
                        case (int)MyEnums.Menus.GetEmployeeById:
                            employeeController.GetById();
                            break;
                        case (int)MyEnums.Menus.DeleteEmployee:
                            employeeController.Delete();
                            break;
                        case (int)MyEnums.Menus.GetEmployeeByAge:
                            employeeController.GetByAge();
                            break;
                        case (int)MyEnums.Menus.GetAllEmployeeByCompanyId:
                            employeeController.GetAllByCompanyId();
                            break;

                    }
                }
                else
                {
                    goto EnterOption;
                }
            }
        }
        static void GetMenus()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Create Company, 2 - Update Company, 3 - Delete Company, 4 - Get Company by id, " +
                    "5 - Get all Company by name, 6 - Get all Company, 7 - Create Employee, 8 - Update Employee, 9 - Get Employee by id, " +
                    "10 - Delete Employee, 11 - Get Employee by age, 12 - Get all Employee by Company id");
        }
    }
}
