using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Services.Database;

namespace API.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly VcashDbContext _dbContext;

        public CountryRepository(VcashDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public List<Country> GetAllCountries()
        {
            return _dbContext.Countries.ToList();
        }

        public Country FindCountryById(int id)
        {
            return _dbContext.Countries.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void CreateCountry(Country country)
        {
            throw new System.NotImplementedException();
        }

        public Country UpdateCountry()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCountry(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}