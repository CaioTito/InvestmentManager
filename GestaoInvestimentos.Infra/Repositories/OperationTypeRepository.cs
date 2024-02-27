using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Infra.Repositories
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
            var operation = await _context.OperationTypes.FirstOrDefaultAsync(ot => ot.Id == id && ot.DeletedAt == null);

            if (operation == null)
                return null;

            return operation;
        }

        public async Task<List<OperationType>> GetAllOperationTypes(string query)
        {
            var operationTypes = await _context.OperationTypes.AsNoTracking().Where(ot => ot.Name.Contains(query) && ot.DeletedAt == null).ToListAsync();

            if (operationTypes == null)
                return null;

            return operationTypes;
        }

        public void Update(OperationType operation)
        {
            _context.OperationTypes.Update(operation);
            _context.SaveChanges();
        }
    }
}
