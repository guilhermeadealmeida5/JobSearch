using JobSearch.Domain.Utility.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Domain.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Company", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string Company { get; set; }
        [Display(Name = "JobTitle", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string JobTitle { get; set; }
        [Display(Name = "CityState", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string CityState { get; set; }
        [Display(Name = "Salary", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public double Salary { get; set; }
        [Display(Name = "ContractType", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string ContractType { get; set; }
        [Display(Name = "TecnologyTools", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string TecnologyTools { get; set; }
        [Display(Name = "CompanyDescription", ResourceType = typeof(Fields))]
        public string CompanyDescription { get; set; }
        [Display(Name = "JobDescription", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        public string JobDescription { get; set; }
        [Display(Name = "Benefits", ResourceType = typeof(Fields))]
        public string Benefits { get; set; }
        [Display(Name = "InterestedSendEmailTo", ResourceType = typeof(Fields))]
        [Required(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E001")]
        [EmailAddress(ErrorMessageResourceType = typeof(Messages), ErrorMessageResourceName = "MSG_E002")]
        public string InterestedSendEmailTo { get; set; }
        [Display(Name = "PublicationDate", ResourceType = typeof(Fields))]
        public DateTime PublicationDate { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
