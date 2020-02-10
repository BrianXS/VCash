using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        List<CountryResponse> GetAllCountries();
        CountryResponse FindCountryResourceById(int id);
        Country FindCountryById(int id);
        void CreateCountry(CountryCreateRequest country);
        CountryResponse UpdateCountry(int Id, CountryUpdateRequest country);
        void DeleteCountry(Country country);
    }
}