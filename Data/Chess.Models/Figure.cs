namespace Chess.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Figure
    {
        [Key, ForeignKey("Position")]
        public int Id { get; set; }


        public string Name { get; set; }

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
    }
}
