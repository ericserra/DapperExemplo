using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using DapperExemplo.Domain.Entities;
using DapperExemplo.Infra.Contracts;

namespace DapperExemplo.Infra.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly ISqlConnectionFactory _connection;
        public PetRepository(ISqlConnectionFactory connection)
        {
            _connection = connection;
        }
        // Add
        public async Task AddAsync(Pet pet)
        {
            using var connection = _connection.Connection();
            connection.Open();
            await connection.InsertAsync(pet);
        }

        // GetById
        public async Task<Pet> GetByIdAsync(Guid id)
        {
            //const string sql = "SELECT * FROM Pet Where Id = @id";
            //var parameters = new DynamicParameters();
            //parameters.Add(name:"@id", id);


            //var pet = await connection.QuerySingleOrDefaultAsync<Pet>(sql, parameters, commandType: System.Data.CommandType.Text);
            using var connection = _connection.Connection();
            var pet = await connection.GetAsync<Pet>(id);

            return pet;
        }

        // GetAll
        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            using var connection = _connection.Connection();

            var pet = await connection.GetAllAsync<Pet>();

            return pet;
        }

        // UpdateById
        public async Task<Pet> UpdateByIdAsync(Pet pet)
        {
            const string sql = "UPDATE Pet SET Name = @Name, Description = @Description WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add(name: "@Id", pet.Id);
            parameters.Add(name: "@Name", pet.Name);
            parameters.Add(name: "@Description", pet.Description);
            
            using var connection = _connection.Connection();
            return (await connection.QueryFirstOrDefaultAsync<Pet>(sql, parameters));
        }

        // DeleteById
        public async Task<Pet> DeleteByIdAsync(Guid id)
        {
            const string sql = "DELETE FROM Pet WHERE Id = @id";
            var parameters = new DynamicParameters();
            parameters.Add(name: "@Id", id);

            using var connection = _connection.Connection();
            return (await connection.QueryFirstOrDefaultAsync<Pet>(sql, parameters));
        }
 
    }
}
