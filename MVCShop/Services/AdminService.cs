using MVCShop.Models;
using MVCShop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCShop.Services
{
    public class AdminService
    {
        private readonly ToyRepository _toyRepository;
        public AdminService(ToyRepository toyRepository)
        {
            _toyRepository = toyRepository;
        }
        public async Task CreateToy(Toy toy)
        {
            await _toyRepository.CreateToy(toy).ConfigureAwait(false);
        }

        public async Task DeleteToy(int id)
        {
            await _toyRepository.DeleteToy(id).ConfigureAwait(false);
        }

        public async Task UpdateToy(Toy toy)
        {
            await _toyRepository.UpdateToy(toy).ConfigureAwait(false);
        }

        public async Task<Toy> GetToy(int id)
        {
           return await _toyRepository.GetToy(id).ConfigureAwait(false);
        }

        public async Task<ICollection<Toy>> GetToysList()
        {
            return await _toyRepository.GetToys().ConfigureAwait(false);
        }

    }
}
