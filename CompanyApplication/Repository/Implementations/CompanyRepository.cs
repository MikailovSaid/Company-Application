using Domain.Models;
using Repository.Data;
using Repository.Exceptions;
using Repository.Inerfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Implementations
{
    public class CompanyRepository : IRepository<Company>
    {
        public bool Create(Company entity)
        {
            try
            {
                if (entity == null)
                    throw new CustomException("Entity is null");
                AppDbContext<Company>.datas.Add(entity);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Delete(Company entity)
        {
            throw new NotImplementedException();
            //gjhgjh
        }

        public Company Get(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public List<Company> GetAll(Predicate<Company> filter)
        {
            throw new NotImplementedException();
        }

        public bool Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}
