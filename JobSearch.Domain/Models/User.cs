using JobSearch.Domain.Utility.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Domain.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Name", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string Name { get; set; }
        [Display(Name = "Email", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType =typeof(Messages), ErrorMessageResourceName ="MSG_E002")]
        public string Email { get; set; }
        [Display(Name = "Password", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        [MinLength(6)]
        public string Password { get; set; }

    }
}
