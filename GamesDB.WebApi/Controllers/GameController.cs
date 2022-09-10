﻿using AutoMapper;
using GamesDB.WebApi.Domain.Entities.GameAggregate;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Service.Implementations;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.GameAggregateQuery;
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
        public GameController(IGameService gameService, IMapper mapper) =>
            (_gameService, _mapper) = (gameService, mapper);
        
        private readonly IGameService _gameService;
        private readonly IMapper _mapper;

        //public GameController(GameService<Game, GameViewModel> gameService) =>
        //    (_gameService) = (gameService);

        //private readonly GameService<Game, GameViewModel> _gameService;

        // GET: GameController
        [HttpGet("{id}", Name = "GetGame")]
        public async Task<IActionResult> Get(int id)
        {
            
            var response = await _gameService.Get(id);
                        
            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpGet(Name = "GetAllGames")]
        public async Task<IActionResult> GetAll()
        {

            var response = await _gameService.GetAll();

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }
            return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<ActionResult<GameViewModel>> Create([FromBody] CreateGameQuery createGameQuery)
        {
            var gameViewModel = _mapper.Map<GameViewModel>(createGameQuery);
            var response = await _gameService.Add(gameViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }
            return RedirectToAction("Error");
                       
        }
    }
}
