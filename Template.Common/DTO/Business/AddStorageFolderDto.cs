using System;
using System.Diagnostics.CodeAnalysis;

namespace Template.Common.DTO.Business
{
    [ExcludeFromCodeCoverage]
    public class AddStorageFolderDto
    {
        /// <summary>
        /// Name of the storage folder.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Optional reference to the parent folder (for nested directory structure).
        /// </summary>
        public Guid? ParentFolderId { get; set; }

        /// <summary>
        /// Optional access control settings for folder permissions.
        /// </summary>
        public string AccessControl { get; set; } = string.Empty;
    }
}