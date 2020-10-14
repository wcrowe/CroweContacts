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
using CroweContacts.Service;

namespace CroweContacts.Pages.Contact
{
    public class EditModel : PageModel
    {
        private readonly IContactService _contactService;
        public EditModel(IContactService contactService) => this._contactService = contactService;

        [BindProperty]
        public ContactVm ContactVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactVm = await _contactService.GetContactByIdAsync(id);

            if (ContactVm == null)
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


            //_context.Attach(ContactVm).State = EntityState.Modified;

            try
            {
                await _contactService.SaveChangesAsync(ContactVm);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_contactService.ContactVmExists(ContactVm.ContactId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

    }
}
