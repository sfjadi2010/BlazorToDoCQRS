using BlazorToDoCQRS.Commands;
using FluentValidation;

namespace BlazorToDoCQRS.Validators;

public class DeleteToDoItemCommandValidator : AbstractValidator<DeleteToDoItemCommand>
{
    public DeleteToDoItemCommandValidator()
    {
        RuleFor(x => x.Id)
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
