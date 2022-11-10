using AutoMapper;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.HttpQuerys;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using GamesDB.WebApi.Models.GamesAggregate.Developers;
using MediatR;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.CreateDeveloper;
using Microsoft.Extensions.DependencyInjection;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperDetails;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Queries.GetDeveloperList;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.UpdateDeveloper;
using GamesDB.WebApi.DAL.MediatR.GamesAggregate.Developers.Commands.DeleteDeveloper;

namespace GamesDB.WebApi.Controllers
{
    public class MediatRDeveloperController : BaseController
    {
        private readonly IMapper _mapper;
        private IMediator _mediator;
        private IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public MediatRDeveloperController(IMapper mapper) =>
            _mapper = (mapper);


        // POST: DeveloperController
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<int>> Create([FromBody] CreateDeveloperDto createDeveloperDto)
        {
            var command = _mapper.Map<CreateDeveloperCommand>(createDeveloperDto);
            //command.Name = ;
            var developerId = await Mediator.Send(command);
            return Ok(developerId);
        }


        // GET: DeveloperController
        [HttpGet("{id}", Name = "MediatRGetDeveloper")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DeveloperDetailsVm>> Get(int id)
        {
            var query = new GetDeveloperDetailsQuery
            {
               Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }


        // GET: DeveloperController
        [HttpGet(Name = "MediatRGetAllDevelopers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAll()
        {
            var query = new GetDeveloperListQuery();
            
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }


        // PUT: DeveloperController
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update([FromBody] UpdateDeveloperDto updateDeveloperDto)
        {
            var command = _mapper.Map<UpdateDeveloperCommand>(updateDeveloperDto);
            
            await Mediator.Send(command);

            return NoContent();
        }


        // DELETE: DeveloperController
        [HttpDelete("{id}", Name = "MediatRDeleteDeveloper")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteDeveloperCommand
            {
                Id = id,
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
