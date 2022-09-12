using AutoMapper;
using GamesDB.WebApi.Domain.Enums;
using GamesDB.WebApi.Service.Interfaces;
using GamesDB.WebApi.Service.ViewModels.HttpQuerys;
using GamesDB.WebApi.Service.ViewModels.GameAggregateViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesDB.WebApi.Controllers
{
    public class DeveloperController : BaseController
    {
        private readonly IDeveloperService _developerService;
        private readonly IMapper _mapper;

        public DeveloperController(IDeveloperService developerService, IMapper mapper) =>
            (_developerService, _mapper) = (developerService, mapper);


        // POST: DeveloperController
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CreateDeveloperQuery createDeveloperQuery)
        {
            var developerViewModel = _mapper.Map<DeveloperViewModel>(createDeveloperQuery);

            var response = await _developerService.Add(developerViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return BadRequest();
        }


        // GET: DeveloperController
        [HttpGet("{id}", Name = "GetDeveloper")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _developerService.Get(id);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }


        // GET: DeveloperController
        [HttpGet(Name = "GetAllDevelopers")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _developerService.GetAll();

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }


        // PUT: DeveloperController
        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateDeveloperQuery updateDeveloperQuery)
        {
            var developerViewModel = _mapper.Map<DeveloperViewModel>(updateDeveloperQuery);

            var response = await _developerService.Update(developerViewModel);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return BadRequest();
        }


        // DELETE: DeveloperController
        [HttpDelete("{id}", Name = "DeleteDeveloper")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _developerService.Delete(id);

            if (response.StatusCode == RequestToDbErrorStatusCode.Success)
            {
                return new ObjectResult(response.Data);
            }

            return NotFound();
        }
    }
}
