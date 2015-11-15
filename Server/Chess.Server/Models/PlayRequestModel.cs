using System.ComponentModel.DataAnnotations;

namespace Chess.Server.Models
{
    public class PlayRequestModel
    {
        [Required]
        public string GameId { get; set; }

        [Required]
        [Range(1, 8)]
        public int Row { get; set; }

        [Required]
        [Range(1, 8)]
        public int Col { get; set; }
    }
}