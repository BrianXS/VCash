using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;

namespace API.Repositories.Interfaces
{
    public interface IFailureRepository
    {
        FailureResponse FindFailureResponseById(int id);
        Failure FindFailureById(int id);
        List<FailureResponse> GetAllFailures();
        void CreateFailure(FailureCreateRequest failure);
        FailureResponse UpdateFailure(int id, FailureUpdateRequest failure);
        void DeleteFailure(Failure failure);
    }
}