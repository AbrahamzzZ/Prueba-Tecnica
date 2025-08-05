using DataBaseFirst.Context;
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
        private readonly PruebaTecnicaDbContext _context;
        public PeliculaSalaCineService(PruebaTecnicaDbContext context)
        {
            _context = context;
        }
    }
}
