using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace MyApplication.Utilities;

/// <summary>
/// Provides extension methods for enumerations to facilitate common tasks such as retrieving display names.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Retrieves the display name of an enumeration value if it has a <see cref="DisplayAttribute"/>,
    /// otherwise returns the string representation of the enumeration value.
    /// </summary>
    /// <param name="value">The enumeration value from which to retrieve the display name.</param>
    /// <returns>The display name as defined in the <see cref="DisplayAttribute"/>, or the enumeration value as a string if no such attribute is present.</returns>
    public static string GetDisplayName(this Enum value)
    {
        return (value.GetType()
                .GetMember(value.ToString())
                .FirstOrDefault() ?? null)?
            .GetCustomAttribute<DisplayAttribute>()?
            .Name ?? value.ToString();
    }
}