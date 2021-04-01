using System.ComponentModel.DataAnnotations;

namespace AboCafes.Common.Requests
{
    public class EmailRequest
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

    }
}
