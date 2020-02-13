using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

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