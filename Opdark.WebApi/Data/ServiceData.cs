using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class ServiceData
    {
        private readonly ApplicationDbContext _context;
        public ServiceData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Service>> GetServicesAsync()
        {
            var result = await _context.Services.ToListAsync();

            return result;
        }

        public async Task<Service> GetServiceAsync(Guid id)
        {
            var result = await _context.Services.FindAsync(id);

            return result;
        }

        public async Task<bool> CreateServiceAsync(Service service)
        {
            try
            {
                await _context.Services.AddAsync(service);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<bool> UpdateServiceAsync(Service service)
        {
            _context.Entry(service).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteServiceAsync(Service service)
        {
            _context.Entry(service).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
