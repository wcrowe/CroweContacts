using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CroweContacts.Data;
using CroweContacts.Models.ContactVM;

namespace CroweContacts.Pages.Phone
{
    public class IndexModel : PageModel
    {
        private readonly CroweContacts.Data.ApplicationDbContext _context;

        public IndexModel(CroweContacts.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<PhoneVm> PhoneVm { get;set; }

        public async Task OnGetAsync()
        {
            PhoneVm = await _context.PhoneVm.ToListAsync();
        }
    }
}
