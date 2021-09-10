using FileUploadAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace FileUploadAPI.Services.Interfaces
{
    public interface IFileManager
    {
        public List<FileU> getFiles(); 
        public bool UploadFile(IFormFile file);
    }
}