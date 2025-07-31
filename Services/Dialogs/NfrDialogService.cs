using MudBlazor;
using MyApplication.Components.ReusableComponents.Common.Dialogs;

namespace MyApplication.Services.Dialogs;

/// <summary>
/// Provides a service to interact with and display dialogs using MudBlazor components.
/// This service focuses primarily on confirmation dialogs.
/// </summary>
public class NfrDialogService(IDialogService dialogService): INfrDialogService
{
    /// <summary>
    /// Displays a confirmation dialog with a specified title, content, and action buttons.
    /// </summary>
    /// <param name="title">The title to be displayed at the top of the dialog.</param>
    /// <param name="contentText">The main content or message to display in the dialog body.</param>
    /// <param name="confirmText">The text for the confirmation button. Defaults to "Confirm".</param>
    /// <param name="cancelText">The text for the cancel button. Defaults to "Cancel".</param>
    /// <param name="color">The color of the confirmation button. Defaults to <see cref="Color.Error"/>.</param>
    /// <returns>
    /// A task that resolves to <c>true</c> if the user clicks the confirmation button, or <c>false</c> if the dialog is canceled.
    /// </returns>
    public async Task<bool> OpenConfirmDialog(string title, string contentText, string confirmText = "Confirm", string cancelText = "Cancel", Color color = Color.Error)
    {
        var parameters = new DialogParameters<ConfirmDialog>
        {
            { x => x.ContentText, contentText },
            { x => x.CancelButtonText, cancelText },
            { x => x.ConfirmButtonText, confirmText },
            { x => x.ConfirmColor, color }
        };

        var dialog = await dialogService.ShowAsync<ConfirmDialog>(title, parameters);
        var result = await dialog.Result;
        
        if(result is not null && !result.Canceled) return true;
        return false;
    }
}