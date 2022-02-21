using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class ProjectData
    {
        private readonly ApplicationDbContext _context;
        public ProjectData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Project>> GetProjectsAsync()
        {
            var result = await _context.Projects.ToListAsync();

            return result;
        }

        public async Task<Project> GetProjectAsync(Guid id)
        {
            var result = await _context.Projects.FindAsync(id);

            return result;
        }

        public async Task<bool> CreateProjectAsync(Project project)
        {
            try
            {
                await _context.Projects.AddAsync(project);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<bool> UpdateProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _context.Entry(project).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
