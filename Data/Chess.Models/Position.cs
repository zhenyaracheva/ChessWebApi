namespace Chess.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Position
    {
        [Key, ForeignKey("Figure")]
        public int Id { get; set; }


        public int Row { get; set; }


        public int Col { get; set; }

        public int FigureId { get; set; }

        public virtual Figure Figure { get; set; }
    }
}
