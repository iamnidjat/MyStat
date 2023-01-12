using System.ComponentModel.DataAnnotations;

namespace MyStat.DTOModels
{
    public class HomeworkItemDTO
    {
        [MaxLength(450)]
        public string? Title { get; set; }

        [MaxLength(450)]
        public string? Content { get; set; }

        [Required]
        public DateTime Sent { get; set; }
    }
}
