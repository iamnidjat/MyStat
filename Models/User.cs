using System.Collections;
using System.Collections.ObjectModel;
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
        [MinLength(6)]
        public string? Password { get; set; }

        public ICollection<HomeworkItem> Homeworks { get; set; } = new ObservableCollection<HomeworkItem>();
    }
}
