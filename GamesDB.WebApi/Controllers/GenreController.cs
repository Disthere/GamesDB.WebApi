using AutoMapper;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.HttpQuerys;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Controllers
{
    public class GenreController : BaseController
    {
        private readonly IGenreService _genreService;
        private readonly IMapper _mapper;

        public GenreController(IGenreService genreService, IMapper mapper) =>
            (_genreService, _mapper) = (genreService, mapper);


        // POST: GenreController
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateGenreQuery createGenreQuery)
        {
            var genreViewModel = _mapper.Map<GenreViewModel>(createGenreQuery);

            var response = await _genreService.Add(genreViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return BadRequest();
        }


        // GET: GenreController
        [HttpGet("{id}", Name = "GetGenre")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _genreService.Get(id);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }


        // GET: GenreController
        [HttpGet(Name = "GetAllGenres")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _genreService.GetAll();

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }


        // PUT: GenreController
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateGenreQuery updateGenreQuery)
        {
            var genreViewModel = _mapper.Map<GenreViewModel>(updateGenreQuery);

            var response = await _genreService.Update(genreViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return BadRequest();
        }


        // DELETE: GenreController
        [HttpDelete("{id}", Name = "DeleteGenre")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _genreService.Delete(id);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }
    }
}
