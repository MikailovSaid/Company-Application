using Domain.Models;
using Service.Helpers;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApplication.Controllers
{
    public class CompanyController
    {
        private CompanyService _companyService { get; }
        public CompanyController()
        {
            _companyService = new CompanyService();
        }
        public void Create()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company name:");
            EnterName: string companyName = Console.ReadLine();
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company adress:");
            string companyAdress = Console.ReadLine();

            Company company = new Company()
            {
                Name = companyName,
                Adress = companyAdress
            };
            var result = _companyService.Create(company);

            if (result != null)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"Id: {company.Id} - Name: {company.Name} - Adress: {company.Adress}");
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Something is wrong");
                goto EnterName;
            }
        }
        public void GetById()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company ID:");
            EnterId: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var companys = _companyService.GetById(id);

                if (companys == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found.");
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
        }
        public void Delete()
        {
            Helper.WriteToConsole(ConsoleColor.Cyan, "Add company ID:");
        EnterId: string companyId = Console.ReadLine();
            int id;

            bool isIdTrue = int.TryParse(companyId, out id);

            if (isIdTrue)
            {
                var companys = _companyService.GetById(id);

                if (companys == null)
                {
                    Helper.WriteToConsole(ConsoleColor.Red, "Company not found. Enter company ID again:");
                    goto EnterId;
                }
                else
                {
                    _companyService.Delete(companys);
                    Helper.WriteToConsole(ConsoleColor.Green, $"Company is deleted");
                }
            }
            else
            {
                Helper.WriteToConsole(ConsoleColor.Red, "Try again id:");
                goto EnterId;
            }
        }
        public void GetAll()
        {
            var companies = _companyService.GetAll();

            foreach (var item in companies)
            {
                Helper.WriteToConsole(ConsoleColor.Green, $"Id: {item.Id} - Name: {item.Name} - Adress: {item.Adress}");
            }
        }
    }
}
