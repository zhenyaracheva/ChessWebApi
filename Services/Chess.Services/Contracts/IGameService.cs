namespace Chess.Services.Contracts
{
    using Chess.Models;
    using System;
    using System.Linq;

    public interface IGameService
    {
        IQueryable<Game> All();

        IQueryable<Game> GetById(Guid id);

        void Add(Game game);

        void Update(Game game);
    }
}
