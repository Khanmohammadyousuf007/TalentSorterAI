using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class EmployeeType
    {
        public int EmployeeTypeID { get; set; }
        [Display(Name ="Employee Type")]
        public string EmployeeTypeName { get; set; } 


    }
}
