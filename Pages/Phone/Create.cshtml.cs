using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CroweContacts.Data;
using CroweContacts.Models.ContactVM;

namespace CroweContacts.Pages.Phone
{
    public class CreateModel : PageModel
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;

        public CreateModel(CroweContacts.Data.CroweContactsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            TempData["ContactId"] = id.Value;
            return Page();
        }

        [BindProperty]
        public PhoneVm PhoneVm { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.PhoneVm.Add(PhoneVm);
            await _context.SaveChangesAsync();

            return RedirectToPage("/contact/details", new { id = PhoneVm.ContactId });

        }
    }
}
