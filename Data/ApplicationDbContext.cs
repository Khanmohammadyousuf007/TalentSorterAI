using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HrHelper.Models;

namespace HrHelper.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<HrHelper.Models.Group> Group { get; set; }

        public DbSet<HrHelper.Models.Company> Company { get; set; }

        public DbSet<HrHelper.Models.EmployeeType> EmployeeType { get; set; }

        public DbSet<HrHelper.Models.Post> Post { get; set; }

        public DbSet<HrHelper.Models.Employee> Employee { get; set; }

        public DbSet<HrHelper.Models.Candidate> Candidate { get; set; }

        public DbSet<HrHelper.Models.CandidateHistory> CandidateHistory { get; set; }

        public DbSet<HrHelper.Models.Application> Application { get; set; }

        public DbSet<HrHelper.Models.Recruitment> Recruitment { get; set; }

        public DbSet<HrHelper.Models.ApplicationStatus> ApplicationStatus { get; set; }
    }
}