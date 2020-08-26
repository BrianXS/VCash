using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IBusinessTypeRepository
    {
        BusinessTypeResponse FindBusinessTypeResponseById(int id);
        BusinessType FindBusinessTypeById(int id);
        List<BusinessTypeResponse> GetAllBusinessTypes();
        void CreateBusinessType(BusinessTypeCreateRequest businessType);
        BusinessTypeResponse UpdateBusinessType(int id, BusinessTypeUpdateRequest businessType);
        void DeleteBusinessType(BusinessType businessType);
    }
}