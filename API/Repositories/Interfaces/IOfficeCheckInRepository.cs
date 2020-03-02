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
        List<OfficeCheckInResponse> GetAll();
        List<OfficeCheckInResponse> FindByOptions(int branchId, DateTime from, DateTime until);
        IActionResult CreateCheckInWithFailure(OfficeCheckInRequest movement);
        ActionResult<OfficeCheckInResponse> UpdateCheckInWithFailure(int id, OfficeCheckInRequest movement);
        IActionResult CreateCheckInWithCustody(OfficeCheckInRequest movement);
        ActionResult<OfficeCheckInResponse> UpdateCheckInWithCustody(int id, OfficeCheckInRequest movement);
        IActionResult CreateLogisticsOnlyCheckIn(OfficeCheckInRequest movement);
        ActionResult<OfficeCheckInResponse> UpdateLogisticsOnlyCheckIn(int id, OfficeCheckInRequest movement);
        IActionResult CreateIncomingCheckIn(OfficeCheckInRequest movement);
        ActionResult<OfficeCheckInResponse> UpdateIncomingCheckIn(int id, OfficeCheckInRequest movement);
        IActionResult CreateOutgoingCheckIn(OfficeCheckInRequest movement);
        ActionResult<OfficeCheckInResponse> UpdateOutgoingCheckIn(int id, OfficeCheckInRequest movement);
        void DeleteCheckIn(Movement movement);
    }
}