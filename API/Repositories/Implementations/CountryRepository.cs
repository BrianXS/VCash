using System;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class CountryRepository : ICountryRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public CountryRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public List<CountryResponse> GetAllCountries()
        {
            var countries = _dbContext.Countries
                .Include(x => x.States).ToList();
            
            return _mapper.Map<List<CountryResponse>>(countries);
        }

        public CountryResponse FindCountryResourceById(int id)
        {
            var country = _dbContext.Countries
                .Where(x => x.Id.Equals(id))
                .Include(x => x.States)
                .FirstOrDefault();
            
            return _mapper
                .Map<CountryResponse>(country);
        }

        public Country FindCountryById(int id)
        {
            return _dbContext.Countries.FirstOrDefault(x => x.Id.Equals(id));
        }

        public void CreateCountry(CountryCreateRequest country)
        {
            _dbContext.Countries.Add(_mapper.Map<Country>(country));
            _dbContext.SaveChanges();
        }

        public void CreateMultipleCountries(List<CountryCreateRequest> countries)
        {
            _dbContext.Countries.AddRange(_mapper.Map<List<Country>>(countries));
            _dbContext.SaveChanges();
        }

        public CountryResponse UpdateCountry(int id, CountryUpdateRequest country)
        {
            var countryToUpdate = _dbContext.Countries.FirstOrDefault(x => x.Id.Equals(id));
            _mapper.Map(country, countryToUpdate);
            
            _dbContext.Countries.Update(countryToUpdate);
            _dbContext.SaveChanges();
            return _mapper.Map<CountryResponse>(countryToUpdate);
        }

        public void DeleteCountry(Country country)
        {
            _dbContext.Countries.Remove(country);
            _dbContext.SaveChanges();
        }

        public int CountCountries()
        {
            return _dbContext.Countries.Count();
        }
    }
}