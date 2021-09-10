using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUploadAPI.Services.Interfaces;
using FileUploadAPI.Models;

namespace FileUploadAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FileUploadController : ControllerBase
    {
        private IFileManager _manager;

        public FileUploadController(IFileManager manager)
        {
            this._manager = manager;
        }

        [HttpGet]
        public IActionResult getFiles(){
            return Ok(_manager.getFiles());
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult upload(IFormFile file)
        {
            return Ok(_manager.UploadFile(file));
        }
    }
}