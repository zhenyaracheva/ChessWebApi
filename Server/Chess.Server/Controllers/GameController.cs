namespace Chess.Server.Controllers
{
    using Chess.Models;
    using Models;
    using Data;
    using Services;
    using Services.Contracts;
    using System.Linq;
    using System.Web.Http;

    public class GameController : ApiController
    {
        private IGameService gameService;

        public GameController()
            : this(new GameService(new Repository<Game>(new ChessDbContext())))
        {
        }

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public IHttpActionResult GetAllGames()
        {
            var games = this.gameService.All()
                                        .Select(x => new GameRequestModel
                                        {
                                            WhitePlayer = x.WhitePlayer.UserName,
                                            BlackPlayer = x.BlackPlayer.UserName
                                        })
                                        .ToList();

            return this.Ok(games);
        }


    }
}
