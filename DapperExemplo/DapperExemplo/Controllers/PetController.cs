using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperExemplo.Domain.Entities;
using DapperExemplo.Infra.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace DapperExemplo.Controllers
{
    [Route(template:"/api/pets")]
    public class PetController : ControllerBase
    {
        private readonly IPetRepository _repository;
        
        public PetController(IPetRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Pet pet)
        {
            await _repository.AddAsync(pet);

            return Created(uri: $"/api/pets/{pet.Id}", pet);
        }

        [HttpGet(template:"id")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var pet = await _repository.GetByIdAsync(id);

            return Ok(pet); // 200
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pets = await _repository.GetAllAsync();
            return Ok(pets.ToList());
        }

        [HttpPut(template:"pet")]
        public async Task<IActionResult> UpdateByIdAsync(Pet pet)
        {
            await _repository.UpdateByIdAsync(pet);

            return Ok(pet);
        }
        
        [HttpDelete]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _repository.DeleteByIdAsync(id);

            return Ok();
        }

    }
}
