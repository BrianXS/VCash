using System;
using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.OfficeMovementResources;

namespace API.Repositories.Interfaces
{
    public interface IOfficeCheckInRepository
    {
        OfficeCheckInResponse FindById(int id);

        Movement FindMovementById(int id);
        List<OfficeCheckInResponse> FindByOptions(int branchId, DateTime from, DateTime until);
        string CreateCheckInWithFailure(OfficeCheckInCreateRequest movement);
        OfficeCheckInResponse UpdateCheckInWithFailure();
        string CreateCheckInWithCustody(OfficeCheckInCreateRequest movement);
        OfficeCheckInResponse UpdateCheckInWithCustody();
        string CreateLogisticsOnlyCheckIn(OfficeCheckInCreateRequest movement);
        OfficeCheckInResponse UpdateLogisticsOnlyCheckIn();
        string CreateNormalCheckIn(OfficeCheckInCreateRequest movement);
        OfficeCheckInResponse UpdateNormalCheckIn();
        void DeleteCheckIn(Movement movement);
    }
}