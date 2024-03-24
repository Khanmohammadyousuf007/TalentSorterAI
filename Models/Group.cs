using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class Group
    {
        public int GroupID { get; set; }
        [Display(Name ="Group Name")]
        public string GroupName { get; set; }

    }
}
