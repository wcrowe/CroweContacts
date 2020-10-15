using CroweContacts.Models.ContactVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CroweContacts.Pages.Contact
{
    public class CreateModel : PageModel
    {
        private readonly CroweContacts.Data.ApplicationDbContext _context;

        public CreateModel(CroweContacts.Data.ApplicationDbContext context)
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
