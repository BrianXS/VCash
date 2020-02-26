using System;
using System.Collections.Generic;
using API.Resources.Outgoing;
using API.Resources.Outgoing.OfficeMovementResources;

namespace API.Repositories.Interfaces
{
    public interface IOfficeCheckInRepository
    {
        OfficeCheckInResponse FindById(int id);
        List<OfficeCheckInResponse> FindByOptions(int SucursalId, DateTime from, DateTime until);
        void CreateCheckInWithFailure();
        void CreateCheckInWithCustody();
        void CreateLogisticsOnlyCheckIn();
        void CreateNormalCheckIn();
        OfficeCheckInResponse UpdateCheckIn();
        void DeleteCheckIn();
    }
}