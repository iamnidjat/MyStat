using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MyStat.Models
{
    [Index("UserName", IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
