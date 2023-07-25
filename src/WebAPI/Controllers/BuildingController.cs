using ApplicationCore.Dtos;
using ApplicationCore.Entities.MongoEntity;
using ApplicationCore.Interfaces.MongoDbRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMongoDbRepository _mongoDbRepository;

        public BuildingController(IMongoDbRepository mongoDbRepository)
        {
            _mongoDbRepository = mongoDbRepository;
        }

        [HttpPost("AddBuilding")]
        public async Task<IActionResult> AddBuilding([FromBody] BuildingDto model)
        {
            Buildings buildings = new Buildings();
            buildings.UserId = model.UserId;
            buildings.BuildingCost = model.BuildingCost;
            buildings.ConstructionTime = model.ConstructionTime;
            buildings.BuildingType= model.BuildingType;
            await _mongoDbRepository.Add(buildings);
            return new JsonResult(true);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mongoDbRepository.GetAll();
            return Ok(result);

        }
    }
}
