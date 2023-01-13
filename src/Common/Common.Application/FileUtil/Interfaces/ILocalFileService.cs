using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Application.FileUtil.Interfaces
{
   public interface ILocalFileService
    {
        void DeleteDirectory(string directoryPath);
        void DeleteFile(string path, string fileName);
        void DeleteFile(string filePath);
        Task SaveFile(IFormFile file, string directoryPath);
        Task SaveFile(IFormFile file, string directoryPath, string fileName);
        Task<string> SaveFileAndGenerateName(IFormFile file, string directoryPath);
    }
}
