using Solution.Core.Objects;
using Solution.App.Domain;
using System;
using System.Collections.Generic;

namespace Solution.App.Application
{
    public sealed class FileApplication : IFileApplication
    {
        public FileApplication(IFileDomain fileDomain)
        {
            FileDomain = fileDomain;
        }

        private IFileDomain FileDomain { get; }

        public IEnumerable<FileBinary> Save(string directory, IEnumerable<FileBinary> files)
        {
            return FileDomain.Save(directory, files);
        }

        public FileBinary Select(string directory, Guid id)
        {
            return FileDomain.Select(directory, id);
        }
    }
}
