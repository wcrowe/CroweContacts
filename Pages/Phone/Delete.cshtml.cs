using CroweContacts.Models.ContactVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CroweContacts.Pages.Phone
{
    public class DeleteModel : PageModel
    {
        private readonly CroweContacts.Data.CroweContactsContext _context;

        public DeleteModel(CroweContacts.Data.CroweContactsContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PhoneVm = await _context.PhoneVm.FindAsync(id);

            if (PhoneVm != null)
            {
                _context.PhoneVm.Remove(PhoneVm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("/contact/details", new { id = id});

        }
    }
}
