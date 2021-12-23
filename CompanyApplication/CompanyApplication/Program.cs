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
            
                CompanyService companyService = new CompanyService();
                Helper.WriteToConsole(ConsoleColor.Blue, "Select options");

                while (true)
                {
                    Helper.WriteToConsole(ConsoleColor.Cyan, "1 - Create Company, 2 - Update Company, 3 - Delete Company, 4 - Get Company by id, " +
                    "5 - Get all Company by name, 6 - Get all Company, 7 - Create Employee, 8 - Update Employee, 9 - Get Employee by id, " +
                    "10 - Delete Employee, 11 - Get Employee by age, 12 - Get all Employee by Company id");

                EnterOption: string selectOption = Console.ReadLine();

                    int option;
                    bool isTrueOption = int.TryParse(selectOption, out option);

                    if (isTrueOption)
                    {
                        switch (option)
                        {
                            case 1:
                                Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name:");
                            EnterName: string companyName = Console.ReadLine();
                                Helper.WriteToConsole(ConsoleColor.Cyan, "Add company adress:");
                                string companyAdress = Console.ReadLine();

                                Company company = new Company()
                                {
                                    Name = companyName,
                                    Adress = companyAdress
                                };
                                var result = companyService.Create(company);

                                if (result != null)
                                {
                                    Helper.WriteToConsole(ConsoleColor.Green, $"Id: {company.Id} - Name: {company.Name} - Adress: {company.Adress}");
                                }
                                else
                                {
                                    Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");
                                    goto EnterName;
                                }
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                Helper.WriteToConsole(ConsoleColor.Cyan, "Add company ID:");
                                EnterId: string companyId = Console.ReadLine();
                                int id;

                                bool isIdTrue = int.TryParse(companyId, out id);

                                if (isIdTrue)
                                {
                                    var companys = companyService.GetById(id);

                                    if(companys == null)
                                    {
                                        Helper.WriteToConsole(ConsoleColor.Red, "Company not found. Enter company ID again:");
                                        goto EnterId;
                                    }
                                    else
                                    {
                                        Helper.WriteToConsole(ConsoleColor.Green, $"Name: {companys.Name} - Adress: {companys.Name}");
                                    }
                                }
                                else
                                {
                                    Helper.WriteToConsole(ConsoleColor.Red, "Try again id:");
                                    goto EnterId;
                                }
                                break;
                        }
                    }
                    else
                    {
                        goto EnterOption;
                    }
                }
            
        }
    }
}
