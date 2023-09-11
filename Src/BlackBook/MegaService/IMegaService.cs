using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MegaService
{
    public interface IMegaService
    {
        Task<Uri?> UploadStreamToMegaAsync(Stream stream, string name);
        Task<Uri?> UploadFormFileToMegaAsync(IFormFile file);
        Task<bool> LoginToMegaAsync(string email, string password);
        Task<Stream> GetBookByDownloadUrl(string url);
    }
}
