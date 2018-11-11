using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Solution.App.Application;
using Solution.Core.AspNetCore;
using Solution.Core.Objects;
using System;
using System.Collections.Generic;
using System.IO;

namespace Solution.App.Web
{
    [ApiController]
    [RouteController]
    public class FilesController : ControllerBase
    {
        public FilesController(IHostingEnvironment environment, IFileApplication fileApplication)
        {
            Environment = environment;
            FileApplication = fileApplication;
            Directory = Path.Combine(Environment.ContentRootPath, "Files");
        }

        private string Directory { get; }

        private IHostingEnvironment Environment { get; }

        private IFileApplication FileApplication { get; }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var file = FileApplication.Select(Directory, id);

            new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out var contentType);

            return File(file.Bytes, contentType, file.Name);
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public IEnumerable<FileBinary> Post()
        {
            return FileApplication.Save(Directory, Request.Files());
        }
    }
}
