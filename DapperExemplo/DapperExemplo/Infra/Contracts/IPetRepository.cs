using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExemplo.Domain.Entities;

namespace DapperExemplo.Infra.Contracts
{
    public interface IPetRepository
    {
        Task AddAsync(Pet pet);
        Task<Pet> GetByIdAsync(Guid id);
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet> UpdateByIdAsync(Pet pet);
        Task<Pet> DeleteByIdAsync(Guid id);
        
    }
}
