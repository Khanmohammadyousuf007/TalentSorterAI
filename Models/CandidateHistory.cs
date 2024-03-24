using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class CandidateHistory
    {
        public int CandidateHistoryID { get; set; }




        [Display(Name = "Honors Marks")]
        public float HonsCGPA { get; set; }

        [Display(Name = "Master's Marks")]
        public float MastersCGPA { get; set; }

        [Display(Name = "Experinece is Years")]
        public float Experience { get; set; }

        [Display(Name = "MCQ Percentage")]
        public float McqPercentage { get; set; }

        [Display(Name = "Written Exam Percentage")]
        public float WrittenPercentage { get; set; }

        [Display(Name = "Viva Percentage")]
        public float VivaPercentage { get; set; }

        [Display(Name ="Ai Recommendation Score")]
        public decimal AiRecommendationScore { get; set; }


    }
}
