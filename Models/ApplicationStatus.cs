using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class ApplicationStatus
    {
        public int ApplicationStatusID { get; set; }

        [Display(Name ="Application Status")]
        public string ApplicationStatusName { get; set; }
    }
}
