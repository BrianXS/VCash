using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface ICityRepository
    {
        CityResponse FindCityResponseById(int id);
        City FindCityById(int id);
        List<CityResponse> GetAllCities();
        void CreateCity(CityCreateRequest city);
        void CreateCitiesRange(List<CityCreateRequest> cities);
        CityResponse UpdateCity(int id, CityUpdateRequest updatedCity);
        void DeleteCity(City city);
    }
}