using Microsoft.EntityFrameworkCore;

using System.ComponentModel.DataAnnotations;

namespace AuthWebApplication.Models
{
    [Index("Email", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }
        public DateTime Birthday { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [MinLength(8)]
        public string? Password { get; set; }

        public string? Role { get; set; }
    }
}
