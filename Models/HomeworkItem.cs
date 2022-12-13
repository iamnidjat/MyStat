using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyStat.Models
{
    [Index("Title", IsUnique = true)]
    public class HomeworkItem
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(450)]
        public string? Title { get; set; }

        [MaxLength(450)]
        public string? Content { get; set; }

        [Required]
        public DateTime Sent { get; set; }

        public int UserId { get; set; }

        public User? User { get; set; }
    }
}
