using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface ICountryRepository
    {
        List<CountryResponse> GetAllCountries();
        CountryResponse FindCountryResourceById(int id);
        Country FindCountryById(int id);
        void CreateCountry(CountryCreateRequest country);
        void CreateMultipleCountries(List<CountryCreateRequest> countries);
        CountryResponse UpdateCountry(int Id, CountryUpdateRequest country);
        void DeleteCountry(Country country);
        int CountCountries();
    }
}