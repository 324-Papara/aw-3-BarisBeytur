using Microsoft.AspNetCore.Mvc;
using Para.Data.Domain;
using Para.Data.UnitOfWork;

namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [NonController]
    public class Customers2Controller : ControllerBase
    {
        private readonly IUnitOfWork<Para.Data.Domain.Customer> unitOfWork;

        public Customers2Controller(IUnitOfWork<Para.Data.Domain.Customer> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            var entityList = await unitOfWork.Repository.GetAll();
            return entityList;
        }

        [HttpGet("{customerId}")]
        public async Task<Customer?> Get(long customerId)
        {
            var entity = await unitOfWork.Repository.GetById(customerId);
            return entity;
        }

        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            await unitOfWork.Repository.Insert(value);
            await unitOfWork.Repository.Insert(value);
            await unitOfWork.Repository.Insert(value);
            await unitOfWork.CompleteWithTransaction();
        }

        [HttpPut("{customerId}")]
        public async Task Put(long customerId, [FromBody] Customer value)
        {
            unitOfWork.Repository.Update(value);
            await unitOfWork.Complete();
        }

        [HttpDelete("{customerId}")]
        public async Task Delete(long customerId)
        {
            await unitOfWork.Repository.Delete(customerId);
            await unitOfWork.Complete();
        }
    }
}