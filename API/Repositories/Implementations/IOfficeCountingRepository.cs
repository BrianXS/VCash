using System;
using System.Collections.Generic;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Implementations
{
    public class OfficeCountingRepository : IOfficeCountingRepository
    {
        public CountingProcessResponse FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Movement FindMovementById(int id)
        {
            throw new NotImplementedException();
        }

        public List<CountingProcessResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CountingProcessResponse> FindByOptions(int branchId, DateTime @from, DateTime until)
        {
            throw new NotImplementedException();
        }

        public IActionResult CountIncomingService(CountingProcessRequest movement)
        {
            throw new NotImplementedException();
        }

        public ActionResult<CountingProcessResponse> UpdateIncomingService(int id, CountingProcessRequest movement)
        {
            throw new NotImplementedException();
        }

        public IActionResult CountOutgoingService(CountingProcessRequest movement)
        {
            throw new NotImplementedException();
        }

        public ActionResult<CountingProcessResponse> UpdateOutgoingService(int id, CountingProcessRequest movement)
        {
            throw new NotImplementedException();
        }

        public void Delete(Movement movement)
        {
            throw new NotImplementedException();
        }
    }
}