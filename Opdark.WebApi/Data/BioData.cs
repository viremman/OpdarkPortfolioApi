using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.DTOs.Bio;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class BioData
    {
        private readonly ApplicationDbContext _context;
        public BioData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Bio>> GetBiosAsync()
        {
            var result = await _context.Bios.ToListAsync();

            return result;
        }

        public async Task<Bio> GetBioAsync(Guid id)
        {
            var result = await _context.Bios.FindAsync(id);

            return result;
        }

        public async Task<bool> CreateBioAsync(Bio bio)
        {
            try
            {
                await _context.Bios.AddAsync(bio);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<bool> UpdateBioAsync(Bio bio)
        {
            _context.Entry(bio).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteBioAsync(Bio bio)
        {
            _context.Entry(bio).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        internal Task UpdateBioAsync(OutgoingBioDto outgoingBioDto)
        {
            throw new NotImplementedException();
        }
    }
}
