using AutoMapper;
using MediatR;
using Para.Base.Response;
using Para.Bussiness.Command.CustomerDetail.UpdateCustomerDetail;
using Para.Data.UnitOfWork;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Command.CustomerDetail.UpdateCustomerDetail
{
    public class UpdateCustomerDetailCommandHandler : IRequestHandler<UpdateCustomerDetailCommand, ApiResponse>
    {

        private readonly IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork;
        private readonly IMapper mapper;

        public UpdateCustomerDetailCommandHandler(IUnitOfWork<Para.Data.Domain.CustomerDetail> unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ApiResponse> Handle(UpdateCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            //CustomerDetailRequestValidator validator = new CustomerDetailRequestValidator();
            //await validator.ValidateAndThrowAsync(request.Request);

            var mapped = mapper.Map<CustomerDetailRequest, Data.Domain.CustomerDetail>(request.Request);
            mapped.Id = request.CustomerDetailId;
            mapped.InsertUser = "system";
            mapped.InsertDate = DateTime.Now;
            unitOfWork.Repository.Update(mapped);
            await unitOfWork.Complete();
            return new ApiResponse();
        }
    }
}
