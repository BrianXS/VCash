using System;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming.OfficeMovementResources;
using API.Resources.Outgoing.OfficeMovementResources;
using API.Services.Database;
using AutoMapper;

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

        public List<OfficeCheckInResponse> FindByOptions(int branchId, DateTime from, DateTime until)
        {
            var movements = _dbContext.Movements
                .Where(x => x.Destination.City.BranchId.Equals(branchId))
                .Where(x => x.ServiceDate.CompareTo(from) >= 0)
                .Where(x => x.ServiceDate.CompareTo(until) <= 0)
                .ToList();
            
            return _mapper.Map<List<OfficeCheckInResponse>>(movements);
        }

        public string CreateCheckInWithFailure(OfficeCheckInCreateRequest movement)
        {
            var failure = _dbContext.Failures.FirstOrDefault(x => x.Id.Equals(movement.FailureId));
            
            if (!movement.Failed || failure == null)
                return "Invalid Request";
            
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return "Invalid Origin";

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return "No funds were found";

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return "Movement processed successfully";
        }

        public OfficeCheckInResponse UpdateCheckInWithFailure()
        {
            throw new NotImplementedException();
        }

        public string CreateCheckInWithCustody(OfficeCheckInCreateRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return "Invalid Origin";
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return "Invalid Destination";

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return "Movement processed successfully";
        }

        public OfficeCheckInResponse UpdateCheckInWithCustody()
        {
            throw new NotImplementedException();
        }

        public string CreateLogisticsOnlyCheckIn(OfficeCheckInCreateRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return "Invalid Origin";
            
            var destinationOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.DestinationId));

            if (destinationOffice == null || destinationOffice.IsFund)
                return "Invalid Destination";

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return "Movement processed successfully";
        }

        public OfficeCheckInResponse UpdateLogisticsOnlyCheckIn()
        {
            throw new NotImplementedException();
        }

        public string CreateNormalCheckIn(OfficeCheckInCreateRequest movement)
        {
            var originOffice = _dbContext.Offices
                .FirstOrDefault(x => x.Id.Equals(movement.OriginId));

            if (originOffice == null || originOffice.IsFund)
                return "Invalid Origin";

            var fund = _dbContext.OfficesAndFunds
                .Where(x => x.CustomerId.Equals(movement.DestinationId))
                .FirstOrDefault(x => x.OfficeId.Equals(movement.DestinationId));
            
            if (fund == null || fund.ClosedAt.CompareTo(movement.ServiceDate) >= 0)
                return "No funds were found";

            _dbContext.Movements.Add(_mapper.Map<Movement>(movement));
            _dbContext.SaveChanges();
            
            return "Movement processed successfully";
        }

        public OfficeCheckInResponse UpdateNormalCheckIn()
        {
            throw new NotImplementedException();
        }

        public void DeleteCheckIn(Movement movement)
        {
            _dbContext.Movements.Remove(movement);
            _dbContext.SaveChanges();
        }
    }
}