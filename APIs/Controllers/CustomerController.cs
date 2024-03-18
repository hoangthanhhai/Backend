
using APIs.Services;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IServiceScopeFactory serviceScopeFactory;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            this._customerService = customerService;
            this.serviceScopeFactory = serviceScopeFactory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetTodoItems()
        {
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    var cusService = scope.ServiceProvider.GetRequiredService<ICustomerService>();
            //    return await cusService.GetAllAsync();
            //}
            return await _customerService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetTodoItem(string id)
        {
            return await _customerService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostTodoItem(Customer todoDTO)
        {
            return await _customerService.CreateAsync(todoDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(string id, Customer todoDTO)
        {
            await _customerService.UpdateAsync(id, todoDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(string id)
        {
            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}