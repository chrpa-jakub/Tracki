using System;
using System.Threading.Tasks;

namespace API.Helpers
{
    
        public interface IFileStorageService
        {
            Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute);
            Task DeleteFile(string fileRoute, string containerName);
            Task<string> SaveFile(byte[] content, string extension, string containerName);
        }
}