using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Woolies.Exercise.Application.Features.User
{
    public class GetUserQueryValidator : AbstractValidator<GetUserQuery>
    {
        public GetUserQueryValidator()
        {
            RuleFor(v => v.test)
                .MaximumLength(200)
                .NotEmpty();
        }

        public async override Task<ValidationResult> ValidateAsync(ValidationContext<GetUserQuery> context, CancellationToken cancellation = default)
        {
            var validationResult = await base.ValidateAsync(context, cancellation);

            var getUserQuery = context.InstanceToValidate;

            validationResult.Errors.Add(new ValidationFailure("Error", "Error"));

            return validationResult;
        }


    }
}
