using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class CommentData
    {
        private readonly ApplicationDbContext _context;
        public CommentData(ApplicationDbContext context)
        {
            _context = context;

        }
        public async Task<List<Comment>> GetCommentsAsync()
        {
            var result = await _context.Comments.ToListAsync();

            return result;
        }
        public async Task<Comment> GetCommentAsync(Guid id)
        {
            var result = await _context.Comments.FindAsync(id);

            return result;
        }
        public async Task<bool> CreateCommentAsync(Comment comment)
        {
            try
            {
                await _context.Comments.AddAsync(comment);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        public async Task<bool> UpdateCommentAsync(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }
        public async Task DeleteCommentAsync(Comment comment)
        {
            _context.Entry(comment).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
