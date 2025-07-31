using MudBlazor;

namespace MyApplication.Services.Dialogs;

/// <summary>
/// Provides a service for displaying and managing dialog interactions.
/// </summary>
public interface INfrDialogService
{
    /// <summary>
    /// Displays a confirmation dialog with customizable options.
    /// </summary>
    /// <param name="title">The title displayed in the dialog.</param>
    /// <param name="contentText">The message or content displayed inside the dialog body.</param>
    /// <param name="confirmText">The text displayed on the confirmation button. Default is "Confirm".</param>
    /// <param name="cancelText">The text displayed on the cancel button. Default is "Cancel".</param>
    /// <param name="color">The color of the confirmation button. Default is <see cref="Color.Error"/>.</param>
    /// <returns>
    /// A <see cref="Task"/> representing the asynchronous operation, which resolves to <c>true</c> if the confirmation button is clicked, or <c>false</c> if the cancel button is clicked.
    /// </returns>
    Task<bool> OpenConfirmDialog(string title, string contentText, string confirmText = "Confirm",
        string cancelText = "Cancel", Color color = Color.Error);
}