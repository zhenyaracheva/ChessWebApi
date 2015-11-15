namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        private ICollection<Figure> figures;
       
        public Game()
        {
            this.figures = new HashSet<Figure>();
        }

        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        [Required]
        public User WhitePlayer { get; set; }

        public User BlackPlayer { get; set; }

        public int BoardId { get; set; }

        public virtual Board Board { get; set; }

        public ICollection<Figure> Figures
        {
            get { return this.figures; }
            set { this.figures = value; }
        }
    }
}
