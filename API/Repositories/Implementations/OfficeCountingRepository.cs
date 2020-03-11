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
using Microsoft.EntityFrameworkCore.Internal;
using ValueType = API.Enums.ValueType;

namespace API.Repositories.Implementations
{
    public class OfficeCountingRepository : IOfficeCountingRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public OfficeCountingRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public ActionResult<CountingProcessResponse> FindById(int id)
        {
            var movement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));

            if (movement == null)
                return new NotFoundObjectResult("Movement not found");

            return new OkObjectResult(_mapper.Map<CountingProcessResponse>(movement));
        }

        public ActionResult<Movement> FindMovementById(int id)
        {
            var movement = _dbContext.Movements.FirstOrDefault(x => x.Id.Equals(id));

            if (movement == null)
                return new NotFoundObjectResult("Movement not found");

            return new OkObjectResult(movement);
        }

        public List<CountingProcessResponse> GetAll()
        {
            var countedMovements = _dbContext.Movements
                .Where(x => x.Envelopes.Any() 
                            || x.Bags.Any() 
                            || x.Cheques.Any())
                .ToList();
            
            return _mapper.Map<List<CountingProcessResponse>>(countedMovements);
        }

        public List<CountingProcessResponse> FindByOptions(int branchId, DateTime from, DateTime until)
        {
            var movements = _dbContext.Movements
                .Where(x => x.Destination.City.BranchId.Equals(branchId))
                .Where(x => x.ServiceDate.CompareTo(from) >= 0)
                .Where(x => x.ServiceDate.CompareTo(until) <= 0)
                .ToList();
            
            return _mapper.Map<List<CountingProcessResponse>>(movements);
        }

        public IActionResult CountIncomingService(int id, CountingProcessRequest movement)
        {
            var storedMovement = _dbContext.Movements
                .Include(x => x.Bags)
                .Include(x => x.Cheques)
                .Include(x => x.Envelopes)
                .FirstOrDefault(x => x.Id.Equals(id));

            var fund = _dbContext.OfficesAndFunds
                .FirstOrDefault(x => x.OfficeId.Equals(storedMovement.DestinationId));

            if(storedMovement == null || storedMovement.Failed || storedMovement.Custody || storedMovement.OfficeToOffice)
                return new NotFoundObjectResult("Movement not found");

            if(fund == null || fund.ClosedAt.CompareTo(DateTime.Now) <= 0)
                return new BadRequestObjectResult("No fund was found");
            
            if(storedMovement.Bags.Any() || storedMovement.Cheques.Any() || storedMovement.Envelopes.Any())
                return new BadRequestObjectResult("The choosen movement has already been counted");

            if(storedMovement.ValueType == ValueType.Bag && !movement.Bags.Any() && (movement.Cheques.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Cheque && !movement.Cheques.Any() && (movement.Bags.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Envelope && !movement.Envelopes.Any() && (movement.Bags.Any() || movement.Cheques.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            
            _mapper.Map(movement, storedMovement);

            if (storedMovement.Bags.Any())
            {
                storedMovement.Bags.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Bags.AddRange(storedMovement.Bags);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Cheques.Any())
            {
                storedMovement.Cheques.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Cheques.AddRange(storedMovement.Cheques);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Envelopes.Any())
            {
                storedMovement.Envelopes.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Envelopes.AddRange(storedMovement.Envelopes);
                _dbContext.SaveChanges();
            }

            _dbContext.Movements.Update(storedMovement);
            _dbContext.SaveChanges();

            return new OkObjectResult("Counting processed successfully");
        }

        public ActionResult<CountingProcessResponse> UpdateIncomingService(int id, CountingProcessRequest movement)
        {
            var storedMovement = _dbContext.Movements
                .Include(x => x.Bags)
                .Include(x => x.Cheques)
                .Include(x => x.Envelopes)
                .FirstOrDefault(x => x.Id.Equals(id));

            var fund = _dbContext.OfficesAndFunds
                .FirstOrDefault(x => x.OfficeId.Equals(storedMovement.DestinationId));

            if(storedMovement == null || storedMovement.Failed || storedMovement.Custody || storedMovement.OfficeToOffice)
                return new NotFoundObjectResult("Movement not found");

            if(fund == null || fund.ClosedAt.CompareTo(DateTime.Now) <= 0)
                return new BadRequestObjectResult("No fund was found");
            
            if(!storedMovement.Bags.Any() || !storedMovement.Cheques.Any() || !storedMovement.Envelopes.Any())
                return new BadRequestObjectResult("The choosen movement has not been counted");

            if(storedMovement.ValueType == ValueType.Bag && !movement.Bags.Any() && (movement.Cheques.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Cheque && !movement.Cheques.Any() && (movement.Bags.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Envelope && !movement.Envelopes.Any() && (movement.Bags.Any() || movement.Cheques.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            
            if (storedMovement.Bags.Any())
            {
                _dbContext.Bags.RemoveRange(storedMovement.Bags);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Cheques.Any())
            {
                _dbContext.Cheques.RemoveRange(storedMovement.Cheques);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Envelopes.Any())
            {
                _dbContext.Envelopes.RemoveRange(storedMovement.Envelopes);
                _dbContext.SaveChanges();
            }

            _mapper.Map(movement, storedMovement);

            if (storedMovement.Bags.Any())
            {
                storedMovement.Bags.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Bags.AddRange(storedMovement.Bags);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Cheques.Any())
            {
                storedMovement.Cheques.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Cheques.AddRange(storedMovement.Cheques);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Envelopes.Any())
            {
                storedMovement.Envelopes.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Envelopes.AddRange(storedMovement.Envelopes);
                _dbContext.SaveChanges();
            }

            _dbContext.Movements.Update(storedMovement);
            _dbContext.SaveChanges();
            
            return new OkObjectResult("Counting processed successfully");
        }

        public IActionResult CountOutgoingService(int id, CountingProcessRequest movement)
        {
            var storedMovement = _dbContext.Movements
                .Include(x => x.Bags)
                .Include(x => x.Cheques)
                .Include(x => x.Envelopes)
                .FirstOrDefault(x => x.Id.Equals(id));

            var fund = _dbContext.OfficesAndFunds
                .FirstOrDefault(x => x.OfficeId.Equals(storedMovement.OriginId));

            if(storedMovement == null || storedMovement.Failed || storedMovement.Custody || storedMovement.OfficeToOffice)
                return new NotFoundObjectResult("Movement not found");

            if(fund == null || fund.ClosedAt.CompareTo(DateTime.Now) <= 0)
                return new BadRequestObjectResult("No fund was found");
            
            if(storedMovement.Bags.Any() || storedMovement.Cheques.Any() || storedMovement.Envelopes.Any())
                return new BadRequestObjectResult("The choosen movement has already been counted");

            if(storedMovement.ValueType == ValueType.Bag && !movement.Bags.Any() && (movement.Cheques.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Cheque && !movement.Cheques.Any() && (movement.Bags.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Envelope && !movement.Envelopes.Any() && (movement.Bags.Any() || movement.Cheques.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            _mapper.Map(movement, storedMovement);

            if (storedMovement.Bags.Any())
            {
                storedMovement.Bags.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Bags.AddRange(storedMovement.Bags);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Cheques.Any())
            {
                storedMovement.Cheques.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Cheques.AddRange(storedMovement.Cheques);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Envelopes.Any())
            {
                storedMovement.Envelopes.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Envelopes.AddRange(storedMovement.Envelopes);
                _dbContext.SaveChanges();
            }

            _dbContext.Movements.Update(storedMovement);
            _dbContext.SaveChanges();

            return new OkObjectResult("Counting processed successfully");
        }

        public ActionResult<CountingProcessResponse> UpdateOutgoingService(int id, CountingProcessRequest movement)
        {
            var storedMovement = _dbContext.Movements
                .Include(x => x.Bags)
                .Include(x => x.Cheques)
                .Include(x => x.Envelopes)
                .FirstOrDefault(x => x.Id.Equals(id));

            var fund = _dbContext.OfficesAndFunds
                .FirstOrDefault(x => x.OfficeId.Equals(storedMovement.OriginId));

            if(storedMovement == null || storedMovement.Failed || storedMovement.Custody || storedMovement.OfficeToOffice)
                return new NotFoundObjectResult("Movement not found");

            if(fund == null || fund.ClosedAt.CompareTo(DateTime.Now) <= 0)
                return new BadRequestObjectResult("No fund was found");
            
            if(!storedMovement.Bags.Any() || !storedMovement.Cheques.Any() || !storedMovement.Envelopes.Any())
                return new BadRequestObjectResult("The choosen movement has not been counted");

            if(storedMovement.ValueType == ValueType.Bag && !movement.Bags.Any() && (movement.Cheques.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Cheque && !movement.Cheques.Any() && (movement.Bags.Any() || movement.Envelopes.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if(storedMovement.ValueType == ValueType.Envelope && !movement.Envelopes.Any() && (movement.Bags.Any() || movement.Cheques.Any()))
                return new BadRequestObjectResult("The valuetype is not the same as the request value type");
            
            if (storedMovement.Bags.Any())
            {
                _dbContext.Bags.RemoveRange(storedMovement.Bags);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Cheques.Any())
            {
                _dbContext.Cheques.RemoveRange(storedMovement.Cheques);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Envelopes.Any())
            {
                _dbContext.Envelopes.RemoveRange(storedMovement.Envelopes);
                _dbContext.SaveChanges();
            }

            _mapper.Map(movement, storedMovement);

            if (storedMovement.Bags.Any())
            {
                storedMovement.Bags.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Bags.AddRange(storedMovement.Bags);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Cheques.Any())
            {
                storedMovement.Cheques.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Cheques.AddRange(storedMovement.Cheques);
                _dbContext.SaveChanges();
            }
            
            if (storedMovement.Envelopes.Any())
            {
                storedMovement.Envelopes.ForEach(x => x.MovementId = storedMovement.Id);
                _dbContext.Envelopes.AddRange(storedMovement.Envelopes);
                _dbContext.SaveChanges();
            }

            _dbContext.Movements.Update(storedMovement);
            _dbContext.SaveChanges();

            return new OkObjectResult("Counting processed successfully");
        }

        public void Delete(Movement movement)
        {
            _dbContext.Movements.Remove(movement);
            _dbContext.SaveChanges();
        }
    }
}