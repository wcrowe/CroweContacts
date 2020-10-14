using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CroweContacts.Data;
using CroweContacts.Models.ContactVM;

namespace CroweContacts.Pages.Phone
{
    public class EditModel : PageModel
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;

        public EditModel(CroweContacts.Data.CroweContactsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PhoneVm PhoneVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhoneVm = await _context.PhoneVm.FirstOrDefaultAsync(m => m.PhoneId == id);

            if (PhoneVm == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PhoneVm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneVmExists(PhoneVm.PhoneId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("/contact/details", new { id = PhoneVm.ContactId });
        }

        private bool PhoneVmExists(int id)
        {
            return _context.PhoneVm.Any(e => e.PhoneId == id);
        }
    }
}
