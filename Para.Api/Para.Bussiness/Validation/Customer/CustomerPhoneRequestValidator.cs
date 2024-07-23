using FluentValidation;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerPhoneRequestValidator: AbstractValidator<CustomerPhoneRequest>
    {

        public CustomerPhoneRequestValidator()
        {
            
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("PhoneNumber is required!")
                .NotNull().WithMessage("PhoneNumber is required!")
                .MinimumLength(10).WithMessage("PhoneNumber must be at least 10 characters!");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required!")
                .NotNull().WithMessage("CustomerId is required!");

            RuleFor(x => x.CountyCode)
                .NotEmpty().WithMessage("CountyCode is required!")
                .NotNull().WithMessage("CountyCode is required!")
                .MinimumLength(2).WithMessage("CountyCode must be at least 2 characters!");
        }

    }
}
