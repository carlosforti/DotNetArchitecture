using Solution.Core.Objects;
using System;
using System.Collections.Generic;

namespace Solution.App.Application
{
    public interface IFileApplication
    {
        IEnumerable<FileBinary> Save(string directory, IEnumerable<FileBinary> files);

        FileBinary Select(string directory, Guid id);
    }
}
