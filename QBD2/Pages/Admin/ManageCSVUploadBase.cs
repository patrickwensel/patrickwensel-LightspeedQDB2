using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace QBD2.Pages.Admin
{
    public class ManageCSVUploadBase : ComponentBase
    {
        //private IWebHostEnvironment Environment;

        //public ManageCSVUploadBase(IWebHostEnvironment _environment)
        //{
        //    Environment = _environment;
        //}

        public async Task LoadFiles(InputFileChangeEventArgs e)
        {
            //string wwwPath = this.Environment.WebRootPath;
            //string contentPath = this.Environment.ContentRootPath;

            //var path = Path.GetFullPath("wwwroot");

            var path = Path.Combine(Path.GetFullPath("wwwroot"), "wwwroot", "upload", e.File.Name);

            await using FileStream fs = new(path, FileMode.Create);
            await e.File.OpenReadStream().CopyToAsync(fs);

            var x = fs;
        }

    }
}
