using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class SkillData
    {
        private readonly ApplicationDbContext _context;
        public SkillData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Skill>> GetSkillsAsync()
        {
            var result = await _context.Skills.ToListAsync();

            return result;
        }

        public async Task<Skill> GetSkillAsync(Guid id)
        {
            var result = await _context.Skills.FindAsync(id);

            return result;
        }

        public async Task<bool> CreateSkillAsync(Skill skill)
        {
            try
            {
                await _context.Skills.AddAsync(skill);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<bool> UpdateSkillAsync(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteSkillAsync(Skill skill)
        {
            _context.Entry(skill).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
