using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ClarkCodingChallenge.Models
{
    public class Contact
    {
        [StringLength(60, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        [Required]
        public string Email { get; set; }
        public Contact(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
