using System;
using Template.Application.Services.Base;
using Template.Common.Core;
using Template.Common.DTO.Business;
using Template.Common.DTO.Business.StorageFolder;

namespace Template.Application.Services.Business.StorageFolder
{
    public interface IStorageFolderService : IBaseService<Domain.Entities.Business.StorageFolder, AddStorageFolderDto, EditStorageFolderDto, StorageFolderDto, Guid, Guid?>
    {
    }
}