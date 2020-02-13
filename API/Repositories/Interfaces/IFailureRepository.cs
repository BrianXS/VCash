using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming;
using API.Resources.Outgoing;

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