using System;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Repositories.Implementations
{
    public class OfficeCheckInRepository : IOfficeCheckInRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public OfficeCheckInRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public OfficeCheckInResponse FindById(int id)
        {
            var movement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<OfficeCheckInResponse>(movement);
        }

        public Movement FindMovementById(int id)
        {
            return _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<OfficeCheckInResponse> GetAll()
        {
            var results = _dbContext.Movements.ToList();
            return _mapper.Map<List<OfficeCheckInResponse>>(results);
        }

        public List<OfficeCheckInResponse> FindByOptions(int branchId, DateTime from, DateTime until)
        {
            var movements = _dbContext.Movements
                .Where(x => x.Destination.City.BranchId.Equals(branchId))
                .Where(x => x.ServiceDate.CompareTo(from) >= 0)
                .Where(x => x.ServiceDate.CompareTo(until) <= 0)
                .ToList();
            
            return _mapper.Map<List<OfficeCheckInResponse>>(movements);
        }

        public IActionResult CreateCheckInWithFailure(OfficeCheckInRequest movement)
        {
            var failure = _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(movement.FailureId));
            
            if (!movement.Failed || failure == null)
                return new BadRequestObjectResult("Invalid Request");
            
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No Funds Were Found");

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateCheckInWithFailure(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
            var failure = _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(movement.FailureId));

            if (!movement.Failed || failure == null || existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");
            
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No Funds Were Found");

            _mapper.Map(_mapper.Map<Movement>(movement), existingMovement);
            _dbContext.Movements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateCheckInWithCustody(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateCheckInWithCustody(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");

            _mapper.Map(_mapper.Map<Movement>(movement), existingMovement);
            _dbContext.Movements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateLogisticsOnlyCheckIn(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateLogisticsOnlyCheckIn(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));
            
            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");

            _mapper.Map(_mapper.Map<Movement>(movement), existingMovement);
            _dbContext.Movements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateIncomingCheckIn(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || !destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");
            

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(destinationOffice.CustomerId))
                .FirstOrDefault(x => x.OfficeId.Equals(destinationOffice.Id));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No funds were found");

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateIncomingCheckIn(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));
            
            
            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || !destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");
            

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No Funds Were Found");

            _mapper.Map(_mapper.Map<Movement>(movement), existingMovement);
            _dbContext.Movements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateOutgoingCheckIn(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));
            
            if (originOffice == null || !originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(originOffice.CustomerId))
                .FirstOrDefault(x => x.OfficeId.Equals(originOffice.Id));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No funds were found");
            
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateOutgoingCheckIn(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));
            
            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));
            
            if (originOffice == null || !originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(originOffice.CustomerId))
                .FirstOrDefault(x => x.OfficeId.Equals(originOffice.Id));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No funds were found");
            
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");

            _mapper.Map(_mapper.Map<Movement>(movement), existingMovement);
            _dbContext.Movements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public void DeleteCheckIn(Movement movement)
        {
            _dbContext.Movements.Remove(movement);
            _dbContext.SaveChanges();
        }
    }
}