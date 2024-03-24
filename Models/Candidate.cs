using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HrHelper.Models
{
    public class Candidate
    {
        public int CandidateID { get; set; }


        [Display(Name = "Name")]
        public string CandidateName { get; set; }

        public int PostId { get; set; }

        public Post Post { get; set; }

        [Display(Name = "Email")]
        public string CandiateEmail { get; set; }


        [Display(Name = "Phone")]
        public string CandidatePhone { get; set; }

        [Display(Name = "Honor CGPA")]
        public float HonsCGPA { get; set; }

        [Display(Name = "Master's CGPA")]
        public float MastersCGPA { get; set; }

        [Display(Name = "Experinece is Years")]
        public float Experience { get; set; }

        [Display(Name = "MCQ Percentage")]
        public float McqPercentage { get; set; }

        [Display(Name = "Written Exam Percentage")]
        public float WrittenPercentage { get; set; }

        [Display(Name = "Viva Percentage")]
        public float VivaPercentage { get; set; }

        [NotMapped]
        public IFormFile Resume { get; set; }

        public string FilePath { get; set; }


        [Display(Name ="Ai Recommendation Score")]
        public decimal AiRecommendationScore { get; set; }


    }
}
