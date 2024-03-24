using System.ComponentModel.DataAnnotations;

namespace HrHelper.Models
{
    public class Post
    {
        public int PostId { get; set; }

        [Display(Name ="Post Name")]
        public string PostName { get; set; }

    }
}
