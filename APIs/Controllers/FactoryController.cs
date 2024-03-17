
using APIs.Services;
using ApplicationCore.DTOs.Request;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactoryController : ControllerBase
    {
        private readonly ILogger<FactoryController> _logger;
        private readonly IFactoryService _FactoryService;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public FactoryController(ILogger<FactoryController> logger, IFactoryService FactoryService, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            this._FactoryService = FactoryService;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Factory>>> GetTodoItems()
        {
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    var cusService = scope.ServiceProvider.GetRequiredService<IFactoryService>();
            //    return await cusService.GetAllAsync();
            //}
            return await _FactoryService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factory>> GetTodoItem(string id)
        {
            return await _FactoryService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Factory>> PostTodoItem(FactoryDTO todoDTO)
        {
            return await _FactoryService.CreateAsync(todoDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(string id, FactoryDTO todoDTO)
        {
            await _FactoryService.UpdateAsync(id, todoDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(string id)
        {
            await _FactoryService.DeleteAsync(id);
            return NoContent();
        }
    }
}