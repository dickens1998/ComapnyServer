using CompanyServer.Core.Application.Warehouses.Commands;
using FluentValidation;

namespace CompanyServer.Core.Application.Warehouses.Validators;

public class AddWarehouseCommandValidator : AbstractValidator<AddWarehouseCommand>
{
    public AddWarehouseCommandValidator()
    {
        RuleFor(v => v.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(v => v.Code)
            .MaximumLength(30);

        RuleFor(v => v.Address)
            .MaximumLength(255);

        RuleFor(v => v.Description)
            .MaximumLength(250);
    }
}