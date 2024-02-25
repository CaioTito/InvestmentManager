using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentos.Infra.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        private readonly InvestmentManagerDataContext _context;

        public OperationTypeRepository(InvestmentManagerDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(OperationType operation)
        {
            await _context.OperationTypes.AddAsync(operation);
            await _context.SaveChangesAsync();
        }

        public async Task<OperationType> GetOperationByIdAsync(Guid id)
        {
            var operation = await _context.OperationTypes.FirstOrDefaultAsync(p => p.Id == id);

            if (operation == null)
                return null;

            if (operation.DeletedAt != null)
                return null;

            return operation;
        }

        public void Update(OperationType operation)
        {
            _context.OperationTypes.Update(operation);
            _context.SaveChanges();
        }
    }
}
