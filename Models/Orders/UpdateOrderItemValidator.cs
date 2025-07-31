using FluentValidation;
/// <summary>
/// Validator for the <see cref="UpdateOrderItemForm"/> class.
/// Ensures that the provided data meets the specified validation rules.
/// </summary>

namespace MyApplication.Models.Orders;

public class UpdateOrderItemValidator : AbstractValidator<UpdateOrderItemForm>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateOrderItemValidator"/> class.
    /// Defines the validation rules for the <see cref="UpdateOrderItemForm"/>.
    /// </summary>
    public UpdateOrderItemValidator()
    {
        RuleFor(x => x.Details)
            .NotEmpty().WithMessage("Details is required.");
        RuleFor(x => x.Quantity)
            .Must(x => x > 0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.IndividualPrice)
            .Must(x => x > 0).WithMessage("Price each must be greater than 0.");
    }




    /// <summary>
    /// Asynchronously validates a specific property on the <see cref="UpdateOrderItemForm"/> model.
    /// </summary>
    public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
    {
        var result =
            await ValidateAsync(ValidationContext<UpdateOrderItemForm>.CreateWithOptions((UpdateOrderItemForm)model,
                x => x.IncludeProperties(propertyName)));
        if (result.IsValid)
            return Array.Empty<string>();
        return result.Errors.Select(e => e.ErrorMessage);
    };

}