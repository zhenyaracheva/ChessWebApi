namespace Chess.Data.Contracts
{

    using System.Data.Entity;
    using Chess.Models;
    using System.Data.Entity.Infrastructure;

    public interface IChessDbContext
    {
        IDbSet<Figure> Figures { get; set; }

        IDbSet<Game> Games { get; set; }

        IDbSet<Position> Positions { get; set; }
        

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        void Dispose();

        int SaveChanges();
    }
}
