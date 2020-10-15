using CroweContacts.Models.ContactVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CroweContacts.Pages.Phone
{
    public class DetailsModel : PageModel
    {
        private readonly CroweContacts.Data.ApplicationDbContext _context;
        public DetailsModel(CroweContacts.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
