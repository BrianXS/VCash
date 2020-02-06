using System.Collections.Generic;
using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
        Country FindCountryById(int id);
        void CreateCountry(Country country);
        Country UpdateCountry();
        void DeleteCountry(int id);
    }
}