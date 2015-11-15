namespace Chess.Server.Controllers
{
    using Chess.Models;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
    using System;
    using System.Linq;
    using System.Web.Http;

    public class GameController : ApiController
    {
        private IGameService gameService;

        public GameController(IGameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpGet]
        public IHttpActionResult Create()
        {

            var currentUser = this.User.Identity.GetUserId();

            var newGame = new Game
            {
                WhitePlayerId = currentUser

            };

            this.gameService.Add(newGame);

            return this.Ok(newGame.Id);
        }

        [HttpPost]
        public IHttpActionResult Join()
        {
            var blackPlayerId = this.User.Identity.GetUserId();
            var game = this.gameService.All()
                                        .Where(x => x.GameState == GameState.WaitingForSecondPlayer && x.WhitePlayerId != blackPlayerId)
                                        .FirstOrDefault();

            if (game == null)
            {
                return this.NotFound();
            }

            game.BlackPlayerId = blackPlayerId;
            game.GameState = GameState.TurnWhitePlayer;
            this.gameService.Update(game);

            return this.Ok(game.Id);
        }

        [HttpGet]
        public IHttpActionResult Status(string gameId)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var gameIdAsGuid = new Guid(gameId);

            var game = this.gameService.All()
                                        .Where(x => x.Id == gameIdAsGuid)
                                        .Select(x => new
                                        {
                                            x.WhitePlayerId,
                                            x.BlackPlayerId
                                        })
                                        .FirstOrDefault();

            if (this.gameService.All().Any())
            {
                return this.NotFound();
            }

            if (game.WhitePlayerId != currentUserId && game.BlackPlayerId == currentUserId)
            {
                return this.Unauthorized();
            }


            return this.Ok(game);
        }
    }
}
