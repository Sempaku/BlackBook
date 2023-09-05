using CG.Web.MegaApiClient;

namespace Mega.Client
{
    public interface IMegaClient
    {
        Task<INode> UploadStreamAsync(Stream stream, string name);
        Task<INode> UploadFileAsync(string filename);

        Task<bool> CreateClientAsync(string email, string password);
        Task<Uri> GetDownloadLinkAsync(INode node);
    }
}