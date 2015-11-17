namespace Chess.Server.Controllers
{

    using System;
    using System.Linq;
    using System.Web.Http;

    using Chess.Models;
    using Common;
    using GameLogic;
    using Microsoft.AspNet.Identity;
    using Models;
    using Services.Contracts;

    public class GameController : ApiController
    {
        private IGameService gameService;
        private IGameResultValidator resultValidator;

        public GameController(IGameService gameService, IGameResultValidator resultValidator)
        {
            this.gameService = gameService;
            this.resultValidator = resultValidator;
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
        
        [HttpGet]
        public IHttpActionResult Status(string id)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var gameIdAsGuid = new Guid(id);

            var game = this.gameService.All()
                                        .Where(x => x.Id == gameIdAsGuid)
                                        .Select(x => new GameResponseModel
                                        {
                                            Id = x.Id,
                                            GameState = x.GameState,
                                            WhitePlayerId = x.WhitePlayerId,
                                            WhitePlayerUsername = x.WhitePlayer.UserName,
                                            BlackPlayerId = x.BlackPlayerId,
                                            BlackPlayerUsername = x.BlackPlayer.UserName,
                                            Board = x.Board
                                        })
                                        .FirstOrDefault();

            if (game == null)
            {
                return this.NotFound();
            }

            if (game.WhitePlayerId != currentUserId && game.BlackPlayerId != currentUserId)
            {
                return this.Unauthorized();
            }


            return this.Ok(game);
        }

        [HttpPost]
        public IHttpActionResult Play(PlayRequestModel request)
        {
            if (request == null || !this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var currentUserId = this.User.Identity.GetUserId();
            var gameIdAsGuid = new Guid(request.GameId);

            var game = this.gameService.All()
                                        .Where(x => x.Id == gameIdAsGuid)
                                        .FirstOrDefault();

            // check if exist that game
            if (game == null)
            {
                return this.BadRequest(GameMessages.InvalidGameIdMessage);
            }

            // chaeck if current user is part of this game
            if (game.WhitePlayerId != currentUserId && game.BlackPlayerId != currentUserId)
            {
                this.BadRequest(GameMessages.NotPartOfGameMessage);
            }

            //check if game is still playing
            if (game.GameState != GameState.TurnWhitePlayer && game.GameState != GameState.TurnBlackPlayer)
            {
                return this.BadRequest(GameMessages.NotPlayingGameMessage);
            }

            // check if current player must play
            if ((game.GameState == GameState.TurnWhitePlayer && game.WhitePlayerId != currentUserId) ||
                (game.GameState == GameState.TurnBlackPlayer && game.BlackPlayerId != currentUserId))
            {
                return this.BadRequest(GameMessages.NotYourTurnMessage);
            }

            var result = this.resultValidator.GetGameResult(game.Board);

            switch (result)
            {
                case GameResult.NotFinished:
                    break;
                case GameResult.WonByWhitePlayer:
                    game.GameState = GameState.WonWhitePlayer;
                    this.gameService.Update(game);
                    break;
                case GameResult.WonByBlackPlayer:
                    game.GameState = GameState.WonBlackPlayer;
                    this.gameService.Update(game);
                    break;
                case GameResult.Draw:
                    game.GameState = GameState.DrawGame;
                    this.gameService.Update(game);
                    break;
                default:
                    break;
            }

            //TODO:
            // Update board
            // Check position
            // Check if game ends

            return this.Ok();
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
    }
}
