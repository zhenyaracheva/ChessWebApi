namespace Chess.Data
{
    using System.Data.Entity;
    using Chess.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Contracts;

    public class ChessDbContext : IdentityDbContext<User>, IChessDbContext
    {
        public ChessDbContext()
            : base("Chess")
        {
        }

        public virtual IDbSet<Figure> Figures { get; set; }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Position> Positions { get; set; }

        public static ChessDbContext Create()
        {
            return new ChessDbContext();
        }
    }
}
