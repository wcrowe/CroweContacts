using System.Collections.Specialized;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace CroweContacts.Pages.Report
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var nvc = Request.Form;
            var Rpt1StartDate = nvc["Rpt1StartDate"];
            var Rpt1EndDate = nvc["Rpt1EndDate"];
            return RedirectToPage("./Index");
        }
    }
}
