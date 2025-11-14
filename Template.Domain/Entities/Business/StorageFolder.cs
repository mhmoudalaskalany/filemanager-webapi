using System;
using System.Diagnostics.CodeAnalysis;

namespace Template.Domain.Entities.Business
{
    /// <summary>
    /// Represents a storage folder entity for organizing files in the system.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class StorageFolder
    {
        /// <summary>
        /// Unique identifier for the storage folder.
        /// </summary>
        public Guid FolderId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Name of the storage folder.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Optional reference to the parent folder (for nested directory structure).
        /// </summary>
        public Guid? ParentFolderId { get; set; }

        /// <summary>
        /// Timestamp when the folder was created.
        /// </summary>
        public DateTime CreationTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Optional access control settings for folder permissions.
        /// </summary>
        public string AccessControl { get; set; } = string.Empty;
    }
}