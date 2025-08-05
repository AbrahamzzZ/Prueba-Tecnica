using DataBaseFirst.Context;
using DataBaseFirst.Models;
using DataBaseFirst.Models.Dto;
using DataBaseFirst.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseFirst.Services
{
    public class PeliculaSalaCineService
    {
        private readonly PeliculaSalaCineRepository _peliculaSalaCineRepository;

        public PeliculaSalaCineService(PeliculaSalaCineRepository peliculaSalaCineRepository)
        {
            _peliculaSalaCineRepository = peliculaSalaCineRepository;
        }

        public async Task<List<PeliculaSalaCine>> ListarPeliculasSalasCineAsync()
        {
            return await _peliculaSalaCineRepository.ListarPeliculasSalasCineAsync();
        }

        public async Task<List<FechaPublicacionDto?>> BuscarPeliculaFechaPublicacionAsync(string fechaPublicacion)
        {
            return await _peliculaSalaCineRepository.BuscarPeliculaFechaPublicacionAsync(fechaPublicacion);
        }

        public async Task<int> RegistrarPeliculaSalaCineAsync(PeliculaSalaCine salaCine)
        {
            return await _peliculaSalaCineRepository.RegistrarPeliculaSalaCineAsync(salaCine);
        }
    }
}
