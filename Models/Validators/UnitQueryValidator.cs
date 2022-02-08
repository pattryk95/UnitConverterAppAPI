using FluentValidation;
using UnitConverterAppAPI.Entities;

namespace UnitConverterAppAPI.Models.Validators
{
    public class UnitQueryValidator : AbstractValidator<UnitQuery>
    {
        private int[] allowedPageSize = new[] { 5, 10, 15 };
        private string[] allowedSortByColumnNames = { nameof(Unit.Name) };
        public UnitQueryValidator()
        {
            RuleFor(u => u.PageNumber).GreaterThanOrEqualTo(1);
            RuleFor(u => u.PageSize).Custom((value, context) =>
               {
                   if (!allowedPageSize.Contains(value))
                   {
                       context.AddFailure("PageSize", $"PageSize must in [{string.Join(",", allowedPageSize)}]");
                   }
               });

            RuleFor(u => u.SortBy)
                .Must(value => string.IsNullOrEmpty(value) || allowedSortByColumnNames.Contains(value))
                .WithMessage($"Sort by is optional, or must be in [{string.Join(",", allowedSortByColumnNames)}]");

        }
    }
}
