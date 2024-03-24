using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string CompanyName { get; set; }
        public int GroupID { get; set; }
        public Group Group { get; set; }
    }
}
