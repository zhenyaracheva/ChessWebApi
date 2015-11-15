namespace Chess.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Game
    {
        private ICollection<Figure> figures;

        
        public Game()
        {
            this.Id = Guid.NewGuid();
            this.GameState = GameState.WaitingForSecondPlayer;
            this.figures = new HashSet<Figure>();

            //TODO: Fix board
            //this.Board = new Board();
        }

        //[Key, ForeignKey("User")]
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        [Required]
        public string WhitePlayerId { get; set; }
        
        public User WhitePlayer { get; set; }

        public string BlackPlayerId { get; set; }

        public User BlackPlayer { get; set; }

       // public int BoardId { get; set; }

       // public virtual Board Board { get; set; }

        public ICollection<Figure> Figures
        {
            get { return this.figures; }
            set { this.figures = value; }
        }
    }
}
