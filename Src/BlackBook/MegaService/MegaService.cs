using CG.Web.MegaApiClient;
using Mega.Client;
using Microsoft.AspNetCore.Http;

namespace MegaService
{
    public class MegaService : IMegaService
    {
        private readonly IMegaClient _megaClient;

        public MegaService(IMegaClient megaClient)
        {
            _megaClient = megaClient;
        }

        public async Task<Stream> GetBookByDownloadUrl(string url)
        {
            Uri fileLink = new Uri(url);
            INode node = await _megaClient.GetNodeFromLinkAsync(fileLink);

            var stream = await _megaClient.DownloadAsync(node);
            return stream;
        }

        public async Task<bool> LoginToMegaAsync(string email, string password)
        {
            bool connectionResult = await _megaClient.CreateClientAsync(email, password);
            if (connectionResult)
                return true;

            return false;
        }

        public async Task<Uri?> UploadFormFileToMegaAsync(IFormFile file)
        {
            if (_megaClient == null)
                throw new Exception();

            INode uploadedFile;
            using (var stream = new MemoryStream())
            {
                file.CopyTo(stream);
                uploadedFile = await _megaClient.UploadStreamAsync(stream, file.Name);
            }
            if (uploadedFile != null)
                return await _megaClient.GetDownloadLinkAsync(uploadedFile);

            return null;
        }

        public async Task<Uri?> UploadStreamToMegaAsync(Stream stream, string name)
        {
            if (_megaClient == null)
                throw new Exception("_megaClient is null");

            INode uploadedFile = await _megaClient.UploadStreamAsync(stream, name);

            if (uploadedFile != null)
                return await _megaClient.GetDownloadLinkAsync(uploadedFile);

            return null;
        }
    }
}