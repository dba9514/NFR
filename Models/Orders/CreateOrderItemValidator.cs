using FluentValidation;

namespace MyApplication.Models.Orders;

public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemForm>
{

    public CreateOrderItemValidator()
    {
        RuleFor(x => x.Details)
            .NotEmpty().WithMessage("Details is required.");
        RuleFor(x => x.Quantity)
            .NotEmpty().WithMessage("Price is required.");
        RuleFor(x => x.Quantity)
            .Must(x => x > 0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.IndividualPrice)
            .NotEmpty().WithMessage("Price is required.");
        RuleFor(x => x.IndividualPrice)
            .Must(x => x > 0).WithMessage("Price each must be greater than 0.");
    }




    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
            await ValidateAsync(ValidationContext<CreateOrderItemForm>.CreateWithOptions((CreateOrderItemForm)model,
                x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };

}