using System.ComponentModel.DataAnnotations;

namespace WbApiDemo3_22_5.Dtos
{
    public class PlayerDto
    {
        [Required]
        public string? PlayerName { get; set; }
        [Required]
        public string? City { get; set; }
        [Required]
        public int Score { get; set; }
    }
}
