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
            this.Id = Guid.NewGuid();
            this.GameState = GameState.WaitingForSecondPlayer;
            this.figures = new HashSet<Figure>();
            this.Board = "BBBBBBBBBBBBBBBB--------------------------------WWWWWWWWWWWWWWWW"; 
        }
        
        public Guid Id { get; set; }

        public GameState GameState { get; set; }

        [Required]
        public string WhitePlayerId { get; set; }
        
        public User WhitePlayer { get; set; }

        public string BlackPlayerId { get; set; }

        public User BlackPlayer { get; set; }

        public string Board { get; set; }

        public ICollection<Figure> Figures
        {
            get { return this.figures; }
            set { this.figures = value; }
        }
    }
}
