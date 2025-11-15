using System;
using Template.Application.Services.Base;
using Template.Common.Core;
using Template.Common.DTO.Business;

namespace Template.Application.Services.Business.StorageFolder
{
    public class StorageFolderService : BaseService<Domain.Entities.Business.StorageFolder, AddStorageFolderDto, EditStorageFolderDto, StorageFolderDto, Guid, Guid?>, IStorageFolderService
    {
        public StorageFolderService(IServiceBaseParameter<Domain.Entities.Business.StorageFolder> parameters) : base(parameters)
        {
        }
    }
}