using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CroweContacts.Data
{
    public class CroweContactsContext : IdentityDbContext // DbContext
    {
        public CroweContactsContext (DbContextOptions<CroweContactsContext> options)
            : base(options)
        {
        }

        public DbSet<CroweContacts.Models.ContactVM.ContactVm> ContactVm { get; set; }
        public DbSet<CroweContacts.Models.ContactVM.PhoneVm> PhoneVm { get; set; }

    }
}
