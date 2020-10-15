using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CroweContacts.Data
{
    public class ApplicationDbContext : IdentityDbContext // DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CroweContacts.Models.ContactVM.ContactVm> ContactVm { get; set; }
        public DbSet<CroweContacts.Models.ContactVM.PhoneVm> PhoneVm { get; set; }

    }
}
