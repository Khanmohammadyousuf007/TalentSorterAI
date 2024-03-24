namespace HrHelper.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public int PostID { get; set; }

        public Post Post { get; set; }

        public int RecruitmentID { get; set; }
        public Recruitment Recruitment { get; set; }
        public int CandidateID { get; set; }
        public Candidate Candidate { get; set; }
        public DateTime ApplicationTime { get; set; }
        public int ApplicationStausID { get; set; }
        public ApplicationStatus ApplicationStatus { get; set; }
    }
}
