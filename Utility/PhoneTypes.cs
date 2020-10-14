using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CroweContacts.Utility
{
    public static class PhoneTypes
    {
    public static List<SelectListItem> GetPhoneTypes()
        {
            return new List<SelectListItem>
            {
                new SelectListItem("Emergency", "Emergency"),
                new SelectListItem("Home", "Home"),
                new SelectListItem("Mobile", "Mobile"),
                new SelectListItem("Office", "Office"),
                new SelectListItem("Other", "Other"),
            };
        }
    }
}
