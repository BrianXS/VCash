using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

namespace API.Repositories.Interfaces
{
    public interface IDenominationTypeRepository
    {
        DenominationTypeResponse FindDenominationTypeResponseById(int id);
        DenominationType FindDenominationTypeById(int id);
        List<DenominationTypeResponse> GetAllDenominationTypes();
        void CreateDenominationType(DenominationTypeCreateRequest denominationType);
        DenominationTypeResponse UpdateDenominationType(int id, DenominationTypeUpdateRequest updatedDenominationType);
        void DeleteDenominationType(DenominationType denominationType);
    }
}