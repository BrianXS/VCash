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
using Microsoft.EntityFrameworkCore;

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
            var movement = _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
            return _mapper.Map<OfficeCheckInResponse>(movement);
        }

        public OfficeMovement FindMovementById(int id)
        {
            return _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
        }

        public List<OfficeCheckInResponse> GetAll()
        {
            var results = _dbContext.OfficeMovements.ToList();
            return _mapper.Map<List<OfficeCheckInResponse>>(results);
        }

        public bool VerifyUniquenessOfIncomingMovement(string payrollNumber)
        {
            return _dbContext
                .OfficeMovements
                .Any(x => x.PayrollNumber.Equals(payrollNumber));
        }

        public List<OfficeCheckInResponse> FindByOptions(int branchId, DateTime from, DateTime until)
        {
            var movements = _dbContext.OfficeMovements
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
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No Funds Were Found");

            _dbContext.OfficeMovements.Add(_mapper.Map<OfficeMovement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateCheckInWithFailure(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
            var failure = _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(movement.FailureId));

            if (!movement.Failed || failure == null || existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");
            
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No Funds Were Found");

            _mapper.Map(_mapper.Map<OfficeMovement>(movement), existingMovement);
            _dbContext.OfficeMovements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateCheckInWithCustody(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");
            
            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _dbContext.OfficeMovements.Add(_mapper.Map<OfficeMovement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateCheckInWithCustody(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
            
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");
            
            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _mapper.Map(_mapper.Map<OfficeMovement>(movement), existingMovement);
            _dbContext.OfficeMovements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateLogisticsOnlyCheckIn(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");
            
            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _dbContext.OfficeMovements.Add(_mapper.Map<OfficeMovement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateLogisticsOnlyCheckIn(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
            
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();
            
            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid Destination");
            
            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _mapper.Map(_mapper.Map<OfficeMovement>(movement), existingMovement);
            _dbContext.OfficeMovements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateIncomingCheckIn(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || !destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");
            

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(destinationOffice.CustomerId))
                .FirstOrDefault(x => x.OfficeId.Equals(destinationOffice.Id));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No funds were found");

            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _dbContext.OfficeMovements.Add(_mapper.Map<OfficeMovement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateIncomingCheckIn(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
            
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || !destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");
            

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No Funds Were Found");
            
            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _mapper.Map(_mapper.Map<OfficeMovement>(movement), existingMovement);
            _dbContext.OfficeMovements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult(existingMovement);
        }

        public IActionResult CreateOutgoingCheckIn(OfficeCheckInRequest movement)
        {
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();
            
            if (originOffice == null || !originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(originOffice.CustomerId))
                .FirstOrDefault(x => x.OfficeId.Equals(originOffice.Id));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No funds were found");
            
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");
            
            
            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");

            
            _dbContext.OfficeMovements.Add(_mapper.Map<OfficeMovement>(movement));
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public ActionResult<OfficeCheckInResponse> UpdateOutgoingCheckIn(int id, OfficeCheckInRequest movement)
        {
            var existingMovement = _dbContext.OfficeMovements.FirstOrDefault(x => x.Id.Equals(id));
            
            var originOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.OriginId))
                .Include(x => x.City)
                .FirstOrDefault();
            
            if (existingMovement == null)
                return new BadRequestObjectResult("Invalid Request");

            if (originOffice == null || !originOffice.IsFund)
                return new BadRequestObjectResult("Invalid Origin");
            
            
            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(originOffice.CustomerId))
                .FirstOrDefault(x => x.OfficeId.Equals(originOffice.Id));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return new NotFoundObjectResult("No funds were found");
            
            
            var destinationOffice = _dbContext.Offices
                .Where(x => x.Id.Equals(movement.DestinationId))
                .Include(x => x.City)
                .FirstOrDefault();

            if (destinationOffice == null || destinationOffice.IsFund)
                return new BadRequestObjectResult("Invalid destination");


            if (!originOffice.City.BranchId.Equals(destinationOffice.City.BranchId))
                return new BadRequestObjectResult("Offices must be in the same branch");
            

            _mapper.Map(_mapper.Map<OfficeMovement>(movement), existingMovement);
            _dbContext.OfficeMovements.Update(existingMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Movement processed successfully");
        }

        public void DeleteCheckIn(OfficeMovement officeMovement)
        {
            _dbContext.OfficeMovements.Remove(officeMovement);
            _dbContext.SaveChanges();
        }
    }
}