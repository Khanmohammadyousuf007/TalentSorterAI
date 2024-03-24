using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class Recruitment
    {
        public int RecruitmentID { get; set; }
        public int PostID { get; set; }
        public int CompanyID { get; set; }
        
        [Display(Name ="Start of Application")]
        public DateTime SrartDate { get; set; }

        [Display(Name = "End of Application")]
        public DateTime EndOfApplication { get; set; }

        [Display(Name = "Job Description")]
        public string JobDescription { get; set; }
        public Post Post { get; set; }

        public Company Company { get; set; }


    }
}
