using System;
using System.Diagnostics.CodeAnalysis;

namespace Template.Common.DTO.Business
{
    [ExcludeFromCodeCoverage]
    public class StorageFolderDto
    {
        public Guid FolderId { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public Guid? ParentFolderId { get; set; }
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;
        public bool IsDeleted { get; set; } = false;
    }
}