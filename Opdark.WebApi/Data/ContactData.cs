using Microsoft.EntityFrameworkCore;
using Opdark.WebApi.Data.Context;
using Opdark.WebApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Opdark.WebApi.Data
{
    public class ContactData
    {
        private readonly ApplicationDbContext _context;
        public ContactData(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            var result = await _context.Contacts.ToListAsync();

            return result;
        }

        public async Task<Contact> GetContactAsync(Guid id)
        {
            var result = await _context.Contacts.FindAsync(id);

            return result;
        }

        public async Task<bool> CreateContactAsync(Contact contact)
        {
            try
            {
                await _context.Contacts.AddAsync(contact);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public async Task<bool> UpdateContactAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task DeleteContactAsync(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}
