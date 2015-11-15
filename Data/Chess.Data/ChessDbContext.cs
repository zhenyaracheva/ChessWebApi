namespace Chess.Data
{
    using System.Data.Entity;
    using Chess.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;

    public class ChessDbContext : IdentityDbContext<User>
    {
        public ChessDbContext()
            : base("Chess")
        {
        }

        public virtual IDbSet<Figure> Figures { get; set; }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Position> Positions { get; set; }

        public virtual IDbSet<Board> Boards { get; set; }

        public static ChessDbContext Create()
        {
            return new ChessDbContext();
        }
    }
}
