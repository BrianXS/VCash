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
    public class CityRepository : ICityRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public CityRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public CityResponse FindCityResponseById(int id)
        {
            var city = _dbContext.Cities.Where(x => x.Id.Equals(id))
                .Include(x => x.State).ThenInclude(x => x.Country)
                .Include(x => x.Branch)
                .FirstOrDefault();
            
            return _mapper.Map<CityResponse>(city);
        }

        public City FindCityById(int id)
        {
            return _dbContext.Cities.Where(x => x.Id.Equals(id))
                .Include(x => x.State).ThenInclude(x => x.Country)
                .Include(x => x.Branch)
                .FirstOrDefault();
        }

        public List<CityResponse> GetAllCities()
        {
            var cities = _dbContext.Cities
                .Include(x => x.State).ThenInclude(x => x.Country)
                .Include(x => x.Branch)
                .ToList();

            return _mapper.Map<List<CityResponse>>(cities);
        }

        public void CreateCity(CityCreateRequest city)
        {
            _dbContext.Cities.Add(_mapper.Map<City>(city));
            _dbContext.SaveChanges();
        }

        public void CreateCitiesRange(List<CityCreateRequest> cities)
        {
            _dbContext.Cities.AddRange(_mapper.Map<List<City>>(cities));
            _dbContext.SaveChanges();
        }

        public CityResponse UpdateCity(int id, CityUpdateRequest updatedCity)
        {
            var cityToBeUpdated = _dbContext.Cities.Where(x => x.Id.Equals(id))
                .Include(x => x.State).ThenInclude(x => x.Country)
                .Include(x => x.Branch)
                .FirstOrDefault();
            
            _mapper.Map(updatedCity, cityToBeUpdated);

            _dbContext.Cities.Update(cityToBeUpdated);
            _dbContext.SaveChanges();
            return _mapper.Map<CityResponse>(cityToBeUpdated);
        }

        public void DeleteCity(City city)
        {
            _dbContext.Cities.Remove(city);
            _dbContext.SaveChanges();
        }
    }
}