using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CroweContacts.Data;
using CroweContacts.Models.ContactVM;

namespace CroweContacts.Pages.Contact
{
    public class DetailsModel : PageModel
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;

        public DetailsModel(CroweContacts.Data.CroweContactsContext context)
        {
            _context = context;
        }

        public ContactVm ContactVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var customers = context.Customers
            //        .Include(i => i.Invoices)
            //        .ThenInclude(it => it.Items))
            //    .ToList();

            ContactVm = await _context.ContactVm.Include(i => i.Phones).FirstOrDefaultAsync(m => m.ContactId == id);

            if (ContactVm == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
