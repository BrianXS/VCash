using System;
using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.OfficeMovementResources;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IOfficeCheckInRepository
    {
        OfficeCheckInResponse FindById(int id);

        Movement FindMovementById(int id);
        List<OfficeCheckInResponse> FindByOptions(int branchId, DateTime from, DateTime until);
        IActionResult CreateCheckInWithFailure(OfficeCheckInCreateRequest movement);
        IActionResult UpdateCheckInWithFailure(int id, OfficeCheckInUpdateRequest movement);
        IActionResult CreateCheckInWithCustody(OfficeCheckInCreateRequest movement);
        IActionResult UpdateCheckInWithCustody(int id, OfficeCheckInUpdateRequest movement);
        IActionResult CreateLogisticsOnlyCheckIn(OfficeCheckInCreateRequest movement);
        IActionResult UpdateLogisticsOnlyCheckIn(int id, OfficeCheckInUpdateRequest movement);
        IActionResult CreateNormalCheckIn(OfficeCheckInCreateRequest movement);
        IActionResult UpdateNormalCheckIn(int id, OfficeCheckInUpdateRequest movement);
        void DeleteCheckIn(Movement movement);
    }
}