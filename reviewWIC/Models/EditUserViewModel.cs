using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using reviewWIC.Areas.Identity.Data;

namespace reviewWIC.Models
{
    public class EditUserViewModel
    {
        public ApplicationUser User { get; set; }
        public IList<SelectListItem> Roles { get; set; }
    }
}
