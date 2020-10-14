using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CroweContacts.Data;
using CroweContacts.Models.ContactVM;

namespace CroweContacts.Pages.Contact
{
    public class CreateModel : PageModel
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;

        public CreateModel(CroweContacts.Data.CroweContactsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ContactVm ContactVm { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.ContactVm.Add(ContactVm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
