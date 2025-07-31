
using FluentValidation;

namespace MyApplication.Models.Orders;

/// <summary>
/// Validator for the CreateOrderItemForm model.
/// Ensures that all required fields meet their validation constraints.
/// </summary>
public class CreateOrderItemValidator : AbstractValidator<CreateOrderItemForm>
{

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateOrderItemValidator"/> class.
    /// Configures validation rules for the CreateOrderItemForm.
    /// </summary>
    public CreateOrderItemValidator()
    {
        RuleFor(x => x.Details)
            .NotEmpty().WithMessage("Details is required.");
        RuleFor(x => x.Quantity)
            .Must(x => x > 0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.IndividualPrice)
            .Must(x => x > 0).WithMessage("Price each must be greater than 0.");
    }

    /// <summary>
    /// A delegate that validates a specific property of the given model asynchronously.
    /// </summary>
    /// <param name="model">The object instance to validate.</param>
    /// <param name="propertyName">The name of the property to validate.</param>
    /// <returns>A list of validation error messages for the specified property, if any.</returns>
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