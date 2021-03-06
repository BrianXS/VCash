using System;
using System.Collections.Generic;
using API.Entities;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Interfaces
{
    public interface IOfficeCountingRepository
    {
        ActionResult<CountingProcessResponse> FindById(int id);
        ActionResult<OfficeMovement> FindMovementById(int id);
        List<CountingProcessResponse> GetAll();
        List<CountingProcessResponse> FindByOptions(int branchId, DateTime from, DateTime until);
        IActionResult CountIncomingService(int id, CountingProcessRequest movement);
        ActionResult<CountingProcessResponse> UpdateIncomingService(int id, CountingProcessRequest movement);
        IActionResult CountOutgoingService(int id, CountingProcessRequest movement);
        ActionResult<CountingProcessResponse> UpdateOutgoingService(int id, CountingProcessRequest movement);
        void Delete(OfficeMovement officeMovement);
    }
}