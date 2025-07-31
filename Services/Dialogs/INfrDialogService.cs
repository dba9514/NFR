using MudBlazor;

namespace MyApplication.Services.Dialogs;

public interface INfrDialogService
{
    Task<bool> OpenConfirmDialog(string title, string contentText, string confirmText = "Confirm",
        string cancelText = "Cancel", Color color = Color.Error);
}