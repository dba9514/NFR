using MudBlazor;
using MyApplication.Components.ReusableComponents.Common.Dialogs;

namespace MyApplication.Services.Dialogs;

public class NfrDialogService(IDialogService dialogService): INfrDialogService
{
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