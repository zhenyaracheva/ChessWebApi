namespace Chess.Server.Models
{

    using System.ComponentModel.DataAnnotations;
    using Chess.Server.Common;

    public class PlayRequestModel
    {
        [Required]
        public string GameId { get; set; }

        [Required]
        [Range(GlobalConstants.MinPositionValue, GlobalConstants.MaxPositionValue)]
        public int Row { get; set; }

        [Required]
        [Range(GlobalConstants.MinPositionValue, GlobalConstants.MaxPositionValue)]
        public int Col { get; set; }
    }
}