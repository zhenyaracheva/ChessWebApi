namespace Chess.Server.Controllers
{
    using Chess.Models;
    using Microsoft.AspNet.Identity;
    using Services.Contracts;
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


    }
}
