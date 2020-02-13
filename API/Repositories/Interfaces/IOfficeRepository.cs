using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IOfficeRepository
    {
        OfficeResponse FindOfficeResourceById(int id);
        Office FindOfficeById(int id);
        List<OfficeResponse> GetAllOffices();
        void CreateOffice(OfficeCreateRequest office);
        OfficeResponse UpdateOffice(int id, OfficeUpdateRequest office);
        void DeleteOffice(Office office);
    }
}