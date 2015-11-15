namespace Chess.Server.Models
{
    using Chess.Models;
    using System;

    public class GameResponseModel
    {
         public Guid Id { get; set; }

        public string WhitePlayerId { get; set; }

        public string WhitePlayerUsername { get; set; }

        public string BlackPlayerId { get; set; }

        public string BlackPlayerUsername { get; set; }

        public GameState GameState { get; set; }
    }
}