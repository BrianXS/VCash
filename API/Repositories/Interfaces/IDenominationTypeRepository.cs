using System.Collections.Generic;
using API.Entities;
using API.Entities.Administrative;
using API.Enums;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IDenominationTypeRepository
    {
        DenominationTypeResponse FindDenominationTypeResponseById(int id);
        List<DenominationTypeResponse> FindDenominationsByCurrency(Currency currency);
        DenominationType FindDenominationTypeById(int id);
        List<DenominationTypeResponse> GetAllDenominationTypes();
        void CreateDenominationType(DenominationTypeCreateRequest denominationType);
        void CreateDenominationTypeRange(List<DenominationTypeCreateRequest> denominations);
        DenominationTypeResponse UpdateDenominationType(int id, DenominationTypeUpdateRequest updatedDenominationType);
        void DeleteDenominationType(DenominationType denominationType);
        int CountDenominationTypes();
    }
}