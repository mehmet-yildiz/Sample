using System.ComponentModel.DataAnnotations;

namespace Sample.Web.Models
{
    public class CustomerViewModel : BaseViewModel
    {
        public long Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string EMail { get; set; }
    }
}