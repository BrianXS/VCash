using System.Collections.Generic;
using System.Linq;
using API.Entities;
using API.Repositories.Interfaces;
using API.Resources.Incoming;
using API.Resources.Incoming.AdministrativeResources;
using API.Resources.Outgoing;
using API.Resources.Outgoing.AdministrativeResources;
using API.Services.Database;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Implementations
{
    public class CashierRepository : ICashierRepository
    {
        private readonly VcashDbContext _dbContext;
        private readonly IMapper _mapper;

        public CashierRepository(VcashDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        
        public CashierResponse FindCashierResponseById(int id)
        {
            var cashier = _dbContext.Cashiers.Where(x => x.Id.Equals(id))
                .Include(x => x.Customer).FirstOrDefault();
            
            return _mapper.Map<CashierResponse>(cashier);
        }

        public Cashier FindCashierById(int id)
        {
            return _dbContext.Cashiers.Where(x => x.Id.Equals(id)).Include(x => x.Customer)
                .FirstOrDefault();
        }

        public List<CashierResponse> GetAllCashiers()
        {
            var cashiers = _dbContext.Cashiers.Include(x => x.Customer).ToList();
            return _mapper.Map<List<CashierResponse>>(cashiers);
        }

        public void CreateCashier(CashierCreateRequest cashier)
        {
            _dbContext.Cashiers.Add(_mapper.Map<Cashier>(cashier));
            _dbContext.SaveChanges();
        }

        public void CreateCashiersRange(List<CashierCreateRequest> cashiers)
        {
            _dbContext.Cashiers.AddRange(_mapper.Map<List<Cashier>>(cashiers));
            _dbContext.SaveChanges();
        }

        public CashierResponse UpdateCashier(int id, CashierUpdateRequest updatedCashier)
        {
            var cashierToUpdate = _dbContext.Cashiers.Include(x => x.Customer)
                .FirstOrDefault(x => x.Id.Equals(id));
            
            _mapper.Map(updatedCashier, cashierToUpdate);

            _dbContext.Cashiers.Update(cashierToUpdate);
            _dbContext.SaveChanges();

            return _mapper.Map<CashierResponse>(cashierToUpdate);
        }

        public void DeleteCashier(Cashier cashier)
        {
            _dbContext.Cashiers.Remove(cashier);
            _dbContext.SaveChanges();
        }

        public int CountCashiers()
        {
            return _dbContext.Cashiers.Count();
        }
    }
}