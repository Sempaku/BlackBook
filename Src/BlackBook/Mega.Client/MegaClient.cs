using CG.Web.MegaApiClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Mega.Client
{
    public class MegaClient : IMegaClient
    {
        private const string SYS_DIRECTORY_NAME = ".blackbook$sys";
        private MegaApiClient? _client;
        private INode? _sysDirectory;

        public async Task<bool> CreateClientAsync(string email, string password)
        {
            if (_client == null)
                _client = new MegaApiClient();
            try
            {
                await _client.LoginAsync(email, password);
                _sysDirectory = await GetBookDirectoryAsync();
                if (_sysDirectory == null)
                    _sysDirectory = await InitBookDirectoryAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return _client.IsLoggedIn;
        }

        public async Task<INode> UploadFileAsync(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                return null;

            if (_sysDirectory == null)
            {
            }

            INode uploadedFile = await _client.UploadFileAsync(filename, _sysDirectory);
            return uploadedFile;
        }

        public async Task<INode> UploadStreamAsync(Stream stream, string name)
        {
            INode uploadedFile = await _client.UploadAsync(stream, name, _sysDirectory);
            return uploadedFile;
        }

        private async Task<INode> InitBookDirectoryAsync()
        {
            var nodes = await _client.GetNodesAsync();
            var root = nodes.Single(node => node.Type == NodeType.Root);

            return await _client.CreateFolderAsync(SYS_DIRECTORY_NAME, root);
        }

        private async Task<INode?> GetBookDirectoryAsync()
        {
            var nodes = await _client.GetNodesAsync();
            return nodes.SingleOrDefault(node => node.Name == SYS_DIRECTORY_NAME);
        }

        public async Task<Uri> GetDownloadLinkAsync(INode node)
        {
            return await _client.GetDownloadLinkAsync(node);
        }

        public async Task<INode> GetNodeFromLinkAsync(Uri fileLink)
        {
            return await _client.GetNodeFromLinkAsync(fileLink);
        }

        public async Task DownloadFileAsync(Uri fileLink, string name)
        {
            await _client.DownloadFileAsync(fileLink, name);
        }

        public async Task<Stream> DownloadAsync(INode node)
        {
            return await _client.DownloadAsync(node);
        }
    }
}