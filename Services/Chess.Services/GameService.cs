namespace Chess.Services
{
    using System;
    using System.Linq;
    using Models;
    using Chess.Services.Contracts;
    using Data.Contracts;

    public class GameService : IGameService
    {
        private IRepository<Game> games;

        public GameService(IRepository<Game> games)
        {
            this.games = games;
        }

        public void Add(Game game)
        {
            this.games.Add(game);
            this.games.SaveChanges();
        }

        public IQueryable<Game> All()
        {
            return this.games.All();
        }
        
        public IQueryable<Game> GetById(Guid id)
        {
            return this.games.All()
                             .Where(x => x.Id == id);
        }

        public void Update(Game game)
        {
            this.games.Update(game);
            this.games.SaveChanges();
        }
    }
}
