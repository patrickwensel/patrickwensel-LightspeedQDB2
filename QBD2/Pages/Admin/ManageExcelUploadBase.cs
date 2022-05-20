using Blazored.Toast.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;
using QBD2.Data;
using QBD2.Models;
using QBD2.Services;
using static QBD2.Models.Enum;
using static QBD2.Services.ExcelUploadService;

namespace QBD2.Pages.Admin
{
    public class ManageExcelUploadBase : ComponentBase
    {
        [Inject]
        private IOptions<ApplicationSettings> _appSettings { get; set; }
        [Inject]
        private BlobService _blobService { get; set; }
        [Inject]
        private ExcelUploadService _excelUploadService { get; set; }

        [Inject]
        private IToastService ToastService { get; set; }

        public List<AddPartsToExcelUploadError> AddPartsToExcelUploadError { get; set; }

        string Message = "No file(s) selected";
        IReadOnlyList<IBrowserFile> selectedFiles;

        public void OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles = e.GetMultipleFiles();
            Message = $"{selectedFiles.Count} file(s) selected";
            this.StateHasChanged();
        }

        public async void OnSubmit()
        {
            string? path = null;
            if (selectedFiles != null)
            {
                foreach (var file in selectedFiles)
                {
                    if (this._appSettings.Value.FileUploadType.ToLower() == FileUploadType.Local.ToString().ToLower())
                    {
                        Stream stream = file.OpenReadStream();
                        path = _appSettings.Value.LocalFileUploadPath + file.Name;
                        FileStream fs = File.Create(path);
                        await stream.CopyToAsync(fs);
                        stream.Close();
                        fs.Close();

                        var errors = await _excelUploadService.ProcessExcelFile(path);
                        if (errors != null && errors.AddPartsToExcelUploadError != null && errors.AddPartsToExcelUploadError.Count() > 0)
                        {
                            AddPartsToExcelUploadError = errors.AddPartsToExcelUploadError;
                        }
                        else
                        {
                            AddPartsToExcelUploadError = null;
                        }
                        StateHasChanged();
                    }
                    else
                    {

                    }
                }

                Message = $"{selectedFiles.Count} file(s) uploaded on server";
                this.StateHasChanged();
            }
            else
            {
                ToastService.ShowError("Please Select file", "Error");
                return;
            }
        }
    }
}
