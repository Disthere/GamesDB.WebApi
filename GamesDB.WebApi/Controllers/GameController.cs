using GamesDB.WebApi.Domain.Entities.GameAggregate;
using GamesDB.WebApi.Service.Implementations;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Controllers
{
    public class GameController : BaseController
    {
        public GameController(GameService<Game, GameViewModel> gameService) =>
            (_gameService) = (gameService);
        
        private readonly GameService<Game,GameViewModel> _gameService;

        // GET: GameController
        [HttpGet("{id}", Name = "GetGame")]
        public async Task<IActionResult> Get(int id)
        {
            
            var response = await _gameService.Get(id);
                        
            if (response.StatusCode == Domain.Enums.RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }
            return RedirectToAction("Error");
        }
    }
}
