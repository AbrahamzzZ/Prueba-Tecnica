using DataBaseFirst.Models;
using DataBaseFirst.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.Services
{
    public class SalaCineService
    {
        private readonly SalaCineRepository _salaCineRepository;

        public SalaCineService(SalaCineRepository salaCineRepository)
        {
            _salaCineRepository = salaCineRepository;
        }

        public async Task<List<SalaCine>> ListarSalasCineAsync()
        {
            return await _salaCineRepository.ListarSalasCineAsync();
        }

        public async Task<SalaCine?> ObtenerSalaCineAsync(int idSalaCine)
        {
            return await _salaCineRepository.ObtenerSalaCineAsync(idSalaCine);
        }

        public async Task<int> RegistrarSalaCineAsync(SalaCine salaCine)
        {
            return await _salaCineRepository.RegistrarSalaCineAsync(salaCine);
        }

        public async Task<int> EditarSalaCineAsync(SalaCine salaCine)
        {
            return await _salaCineRepository.EditarSalaCineAsync(salaCine);
        }

        public async Task<int> EliminarSalaCineAsync(int id)
        {
            return await _salaCineRepository.EliminarSalaCineAsync(id);
        }
    }
}
