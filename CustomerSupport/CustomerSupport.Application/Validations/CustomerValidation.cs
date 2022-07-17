using CustomerSupport.Application.Helpers;
using CustomerSupport.Domain.Entities;
using CustomerSupport.Resource;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSupport.Application.Validations
{
    public class CustomerValidation : AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Email))
                .Must(EmailValidationHelper.IsValidEmail).WithMessage(string.Format(Geral.InvalidField, Geral.Email));

            RuleFor(c => c.Phone)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.Phone))
                .Length(0, 20).WithMessage(string.Format(Geral.MustHaveMaxCharacters, Geral.Phone, 20));

            RuleFor(c => c.IssueDescription)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.IssueDescription))
                .Length(0, 250).WithMessage(string.Format(Geral.IssueDescription, Geral.Phone, 250));

            RuleFor(c => c.TypeInquiry)
                .NotEmpty().WithMessage(string.Format(Geral.Required, Geral.TypeInquiry));
        }
    }
}
