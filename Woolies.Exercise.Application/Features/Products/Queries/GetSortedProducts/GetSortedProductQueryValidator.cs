using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Woolies.Exercise.Application.Features.Products
{
    public class GetSortedProductQueryValidator : AbstractValidator<GetSortedProductsQuery>
    {

        public GetSortedProductQueryValidator()
        {
            RuleFor(v => v.SortOption)
                              .NotEmpty().WithMessage("sortOption is Invalid , should be 'high', 'low','ascending','decending' or 'Recommended' ");
        }

        public async override Task<ValidationResult> ValidateAsync(ValidationContext<GetSortedProductsQuery> context, CancellationToken cancellation = default)
        {
            var validationResult = await base.ValidateAsync(context, cancellation);

            var getUserQuery = context.InstanceToValidate;

            //validationResult.Errors.Add(new ValidationFailure("Error", "Error"));

            return validationResult;
        }


    }
}
