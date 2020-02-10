using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface ICityRepository
    {
        CityResponse FindCityResponseById(int id);
        City FindCityById(int id);

        List<CityResponse> GetAllCities();
        void CreateCity(CityCreateRequest city);
        CityResponse UpdateCity(int id, CityUpdateRequest updatedCity);
        void DeleteCity(City city);
    }
}