using CG.Web.MegaApiClient;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Mega.Client
{
    public interface IMegaClient
    {
        Task<INode> UploadStreamAsync(Stream stream, string name);

        Task<INode> UploadFileAsync(string filename);

        Task<bool> CreateClientAsync(string email, string password);

        Task<Uri> GetDownloadLinkAsync(INode node);

        Task<INode> GetNodeFromLinkAsync(Uri fileLink);

        Task DownloadFileAsync(Uri fileLink, string name);

        Task<Stream> DownloadAsync(INode node);
    }
}