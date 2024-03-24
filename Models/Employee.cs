using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        [Display(Name ="Employee Name")]
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [Display(Name ="Employee Code")]
        public string EmployeeCode { get; set; }
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        public int EmployeeTypeID { get; set; }
        [Display(Name ="Employee Type")]
        public EmployeeType EmployeeType { get; set; }

        [Display(Name ="Job Post")]
        public int PostID { get; set; }
        public Post Post { get; set; }
        public Decimal Salary { get; set; }

    }
}
