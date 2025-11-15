using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Application.Services.Base;
using Template.Common.Core;
using Template.Common.DTO.Base;
using Template.Common.DTO.Business.StorageFolder;
using Template.Common.DTO.Lookup.Category.Parameters;

namespace Template.Application.Services.Business.StorageFolder
{
    public interface IStorageFolderService : IBaseService<Domain.Entities.Business.StorageFolder, AddStorageFolderDto, EditStorageFolderDto, StorageFolderDto, Guid, Guid?>
    {
        Task<PagedResult<IEnumerable<StorageFolderDto>>> GetAllPagedAsync(BaseParam<MainFilter> filter);

        Task<PagedResult<IEnumerable<StorageFolderDto>>> GetDropDownAsync(BaseParam<SearchCriteriaFilter> filter);

        Task<Result> DeleteRangeAsync(List<Guid> ids);
    }
}