using FluentValidation;
using Para.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Para.Bussiness.Validation.Customer
{
    public class CustomerAddressRequestValidator : AbstractValidator<CustomerAddressRequest>
    {
        public CustomerAddressRequestValidator()
        {
            
            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("CustomerId is required!")
                .NotNull().WithMessage("CustomerId is required!");

            RuleFor(x => x.AddressLine)
                .NotEmpty().WithMessage("Address is required!")
                .NotNull().WithMessage("Address is required!")
                .MinimumLength(10).WithMessage("Address must be at least 10 characters!");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required!")
                .NotNull().WithMessage("City is required!")
                .MinimumLength(2).WithMessage("City must be at least 2 characters!");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required!")
                .NotNull().WithMessage("Country is required!")
                .MinimumLength(2).WithMessage("Country must be at least 2 characters!");

            RuleFor(x => x.ZipCode)
                .NotEmpty().WithMessage("PostalCode is required!")
                .NotNull().WithMessage("PostalCode is required!")
                .MinimumLength(4).WithMessage("PostalCode must be at least 4 characters!");
        }
    }
}
