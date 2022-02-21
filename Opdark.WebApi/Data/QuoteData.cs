using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class QuoteData
    {
        private readonly ApplicationDbContext _context;
        public QuoteData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Quote>> GetQuotesAsync()
        {
            var result = await _context.Quotes.ToListAsync();

            return result;
        }

        public async Task<Quote> GetQuoteAsync(Guid id)
        {
            var result = await _context.Quotes.FindAsync(id);

            return result;
        }

        public async Task<bool> CreateQuoteAsync(Quote quote)
        {
            try
            {
                await _context.Quotes.AddAsync(quote);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<bool> UpdateQuoteAsync(Quote quote)
        {
            _context.Entry(quote).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteQuoteAsync(Quote quote)
        {
            _context.Entry(quote).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        internal Task CreateContactAsync(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
