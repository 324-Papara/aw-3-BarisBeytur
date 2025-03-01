using MediatR;
using Microsoft.AspNetCore.Mvc;
using Para.Base.Response;
using Para.Bussiness.Command.Customer.CreateCustomer;
using Para.Bussiness.Command.Customer.DeleteCustomer;
using Para.Bussiness.Command.Customer.UpdateCustomer;
using Para.Bussiness.Query.Customer.GetAll;
using Para.Bussiness.Query.Customer.GetById;
using Para.Bussiness.Query.Customer.GetByParameter;
using Para.Schema;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;
        
        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet]
        public async Task<ApiResponse<List<CustomerResponse>>> Get()
        {
            var operation = new GetAllCustomerQuery();
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("{customerId}")]
        public async Task<ApiResponse<CustomerResponse>> Get([FromRoute]long customerId)
        {
            var operation = new GetCustomerByIdQuery(customerId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpPost]
        public async Task<ApiResponse<CustomerResponse>> Post([FromBody] CustomerRequest value)
        {
            CreateCustomerCommand command = new CreateCustomerCommand(value);
            var result = await mediator.Send(command);
            return result;
        }

        [HttpPut("{customerId}")]
        public async Task<ApiResponse> Put(long customerId, [FromBody] CustomerRequest value)
        {
            var operation = new UpdateCustomerCommand(customerId,value);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpDelete("{customerId}")]
        public async Task<ApiResponse> Delete(long customerId)
        {
            var operation = new DeleteCustomerCommand(customerId);
            var result = await mediator.Send(operation);
            return result;
        }

        [HttpGet("GetByQuery")]
        public async Task<ApiResponse<List<CustomerResponse>>> Get([FromQuery] string? name, [FromQuery] string? identityNumber, [FromQuery] long? customerId)
        {
            var operation = new GetCustomerByParametersQuery(customerId, name, identityNumber);
            var result = await mediator.Send(operation);
            return result;
        }



        [HttpGet("GetCustomerByIdWithDetails/{customerId}")]
        public async Task<ApiResponse<Para.Data.Domain.Customer>> GetByIdWithDetails([FromRoute] long customerId)
        {
            var operation = new GetCustomerByIdWithDetailsQuery(customerId);
            var result = await mediator.Send(operation);
            return result;
        }

    }
}