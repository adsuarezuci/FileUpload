using System.Collections.Generic;
using FileUploadAPI.Models;
using FileUploadAPI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace FileUploadAPI.Services
{
    public class FileManager : IFileManager
    {
        private string folderName = "files";
        public List<FileU> getFiles()
        {
            var list = new List<FileU>();
            var files = Directory.GetFiles(folderName);
            foreach (var item in files)
            {
                var f = new  FileU{ Name = Path.GetFileName(item), Url = item};
                list.Add(f);
            }
            return list;
        }

        public bool UploadFile(IFormFile file)
        {
            try
            {
                if (!Directory.Exists(folderName))
                {
                    Directory.CreateDirectory(folderName);
                }
                using (FileStream stream = File.Create(folderName + "\\" + file.FileName))
                {
                    file.CopyTo(stream);
                    stream.Flush();
                    return true;
                }
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }
}