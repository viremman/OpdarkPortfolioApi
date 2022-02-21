using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class BlogData
    {
        private readonly ApplicationDbContext _context;
        public BlogData(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<List<Blog>> GetBlogsAsync()
        {
            var result = await _context.Blogs.ToListAsync();

            return result;
        }
        public async Task<Blog> GetBlogAsync(Guid id)
        {
            var result = await _context.Blogs.FindAsync(id);

            return result;
        }
        public async Task<bool> CreateBlogAsync(Blog blog)
        {
            try
            {
                await _context.Blogs.AddAsync(blog);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public async Task<bool> UpdateBlogAsync(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task DeleteBioAsync(Blog blog)
        {
            _context.Entry(blog).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        internal Task DeleteBlogAsync(Blog deletable)
        {
            throw new NotImplementedException();
        }
    }
}
