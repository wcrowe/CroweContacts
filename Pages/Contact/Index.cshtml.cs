using CroweContacts.Models.ContactVM;
using CroweContacts.Service;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CroweContacts.Pages.Contact
{
    public class IndexModel : PageModel
    {
        private readonly IContactService _contactService;
        public IndexModel(IContactService contactService) => this._contactService = contactService;
        public IList<ContactVm> ContactVm { get; set; }

        public async Task OnGetAsync()
        {
            ContactVm = await _contactService.GetContactListAsync();
        }
    }
}
