using Domain.Models;
using Repository.Implementations;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class CompanyService : ICompanyService
    {
        private CompanyRepository _companyRepository;
        private int count { get; set; }
        public CompanyService()
        {
            _companyRepository = new CompanyRepository();
        }
        public Company Create(Company model)
        {
            model.Id = count;
            count++;
            _companyRepository.Create(model);

            return model;
        }

        public void Delete(Company model)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public Company GetById(int id)
        {
            return _companyRepository.Get(m => m.Id == id);
        }

        public Company Update(int id, Company model)
        {
            throw new NotImplementedException();
        }
    }
}
