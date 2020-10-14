using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CroweContacts.Data;
using CroweContacts.Models.ContactVM;
using Microsoft.EntityFrameworkCore;

namespace CroweContacts.Service
{
    public class ContactService : IContactService
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;
        public ContactService(CroweContactsContext context) => this._context = context;

        public async Task<List<ContactVm>> GetContactListAsync() => await _context.ContactVm.ToListAsync();
        public async Task<ContactVm> GetContactByIdAsync(int? id) => await _context.ContactVm.FirstOrDefaultAsync(m => m.ContactId == id);
        public bool ContactVmExists(int id) =>  _context.ContactVm.Any(e => e.ContactId == id);
        //  public async Task<Dictionary<int, string>> GetProductListAsync() => await context.Products.ToDictionaryAsync(k => k.ProductId, v => v.ProductName);
        //  public async Task<Product> GetProductAsync(int id) => await context.Products.Include(p => p.Category).Include(p => p.Supplier).FirstOrDefaultAsync(p => p.ProductId == id);
        public async Task SaveChangesAsync(ContactVm contactVm)
        {
            _context.Attach(contactVm).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}

