using AutoMapper;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.HttpQuerys;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Controllers
{
    public class GameController : BaseController
    {
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        public GameController(IGameService gameService, IMapper mapper) =>
            (_gameService, _mapper) = (gameService, mapper);


        // POST: GameController
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateGameQuery createGameQuery)
        {
            var gameViewModel = _mapper.Map<GameViewModel>(createGameQuery);

            var response = await _gameService.Add(gameViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return BadRequest();
        }


        // GET: GameController
        [HttpGet("{id}", Name = "GetGame")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _gameService.Get(id);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }


        // GET: GameController
        [HttpGet(Name = "GetAllGames")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _gameService.GetAll();

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }


        // PUT: GameController
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateGameQuery updateGameQuery)
        {
            var gameViewModel = _mapper.Map<GameViewModel>(updateGameQuery);

            var response = await _gameService.Update(gameViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return RedirectToAction("Error");
        }


        // DELETE: GameController
        [HttpDelete("{id}", Name = "DeleteGame")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _gameService.Delete(id);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }

        // GET: GameController
        [HttpGet("{genreId}", Name = "GetGameByGenre")]
        public async Task<IActionResult> GetByGenre(int genreId)
        {
            var response = await _gameService.GetByGenre(genreId);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }
    }
}
