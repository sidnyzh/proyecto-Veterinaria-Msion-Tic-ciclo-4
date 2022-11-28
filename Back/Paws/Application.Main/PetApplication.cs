using Application.Interfaces;
using Domain.Entity;
using Domain.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Main
{
    public class PetApplication : IPetApplication
    {
        private readonly IRepository<Pet> _pet;

        public PetApplication(IRepository<Pet> pet)
        {
            _pet = pet;
        }

        public async Task<IEnumerable<Pet>> GetPets()
        {
            return await _pet.GetAllAsync("pets");
        }

        public async Task CreatePet(Pet pet)
        {
            await _pet.CreateAsync(pet, "pets");
        }
        public async Task<Pet> GetById(string id)
        {

            var filter = Builders<Pet>.Filter.Eq("Id", id);
            return await _pet.GetBySmtAsync(filter, "pets");
        }

        public async Task<Pet> GetByOwner(string owner)
        {

            var filter = Builders<Pet>.Filter.Eq("Owner", owner);
            return await _pet.GetBySmtAsync(filter, "pets");
        }

        public async Task<bool> deleteById(string id)
        {
            var filter = Builders<Pet>.Filter.Eq("Id", id);
            return await _pet.DeleteAsync(filter, "pets");

        }
    }

}

