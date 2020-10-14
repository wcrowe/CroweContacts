using CroweContacts.Models.ContactVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CroweContacts.Pages.Contact
{
    public class DeleteModel : PageModel
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;

        public DeleteModel(CroweContacts.Data.CroweContactsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactVm ContactVm { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactVm = await _context.ContactVm.FirstOrDefaultAsync(m => m.ContactId == id);

            if (ContactVm == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ContactVm = await _context.ContactVm.FindAsync(id);

            if (ContactVm != null)
            {
                _context.ContactVm.Remove(ContactVm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
