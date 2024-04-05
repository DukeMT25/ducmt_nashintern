using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fredperry.Core.Entities.Business
{
    public class EditAccountViewModel
    {
        [Required]
        public string UserId { get; set; }

        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Current Role")]
        public string CurrentRole { get; set; }

        [Display(Name = "Select Role")]
        public string? SelectedRole { get; set; }

        public List<string> AllRoles { get; set; }

        // Explicitly convert IList<string> to List<string>
        public EditAccountViewModel()
        {
            AllRoles = new List<string>();
        }
    }
}
