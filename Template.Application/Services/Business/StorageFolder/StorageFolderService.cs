using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Template.Application.Services.Base;
using Template.Common.Core;
using Template.Common.DTO.Base;
using Template.Common.DTO.Business.StorageFolder;
using Template.Common.DTO.Business.StorageFolder.Parameters;
using Template.Domain;

namespace Template.Application.Services.Business.StorageFolder
{
    public class StorageFolderService : BaseService<Domain.Entities.Business.StorageFolder, AddStorageFolderDto, EditStorageFolderDto, StorageFolderDto, Guid, Guid?>, IStorageFolderService
    {
        public StorageFolderService(IServiceBaseParameter<Domain.Entities.Business.StorageFolder> parameters) : base(parameters)
        {
        }

        public async Task<PagedResult<IEnumerable<StorageFolderDto>>> GetAllPagedAsync(BaseParam<MainFilter> filter)
        {

            var limit = filter.PageSize;

            var offset = ((--filter.PageNumber) * filter.PageSize);

            var query = await UnitOfWork.Repository.FindPagedAsync(predicate: PredicateBuilderFunction(filter.Filter), pageNumber: offset, pageSize: limit, filter.OrderByValue);

            var data = Mapper.Map<IEnumerable<Domain.Entities.Business.StorageFolder>, IEnumerable<StorageFolderDto>>(query.Item2);

            return PagedResult<IEnumerable<StorageFolderDto>>.Success(data, filter.PageNumber, filter.PageSize, query.Item1, MessagesConstants.Success);

        }


        public async Task<PagedResult<IEnumerable<StorageFolderDto>>> GetDropDownAsync(BaseParam<SearchCriteriaFilter> filter)
        {

            var limit = filter.PageSize;

            var offset = ((--filter.PageNumber) * filter.PageSize);

            var predicate = DropDownPredicateBuilderFunction(filter.Filter);

            var query = await UnitOfWork.Repository.FindPagedAsync(predicate: predicate, pageNumber: offset, pageSize: limit);

            var data = Mapper.Map<IEnumerable<Domain.Entities.Business.StorageFolder>, IEnumerable<StorageFolderDto>>(query.Item2);

            return PagedResult<IEnumerable<StorageFolderDto>>.Success(data, filter.PageNumber, filter.PageSize, query.Item1, MessagesConstants.Success);

        }

        public async Task<Result> DeleteRangeAsync(List<Guid> ids)
        {
            var rows = await UnitOfWork.Repository.RemoveBulkAsync(x => ids.Contains(x.FolderId));

            if (rows > 0)
            {
                return Result.Success(MessagesConstants.DeleteSuccess);
            }
            return Result.Failure(MessagesConstants.DeleteError);
        }

        static Expression<Func<Domain.Entities.Business.StorageFolder, bool>> PredicateBuilderFunction(MainFilter filter)
        {
            var predicate = PredicateBuilder.New<Domain.Entities.Business.StorageFolder>(x => x.IsDeleted == filter.IsDeleted);

            if (!string.IsNullOrWhiteSpace(filter?.NameAr))
            {
                predicate = predicate.And(b => b.Name.Contains(filter.NameAr));
            }
            if (!string.IsNullOrWhiteSpace(filter?.NameEn))
            {
                predicate = predicate.And(b => b.Name.Contains(filter.NameEn));
            }
            if (!string.IsNullOrWhiteSpace(filter?.Name))
            {
                predicate = predicate.And(b => b.Name.Contains(filter.Name));
            }
            return predicate;
        }

        static Expression<Func<Domain.Entities.Business.StorageFolder, bool>> DropDownPredicateBuilderFunction(SearchCriteriaFilter filter)
        {
            var predicate = PredicateBuilder.New<Domain.Entities.Business.StorageFolder>(true);
            if (!string.IsNullOrWhiteSpace(filter?.SearchCriteria))
            {
                predicate = predicate.And(b => b.Name.Contains(filter.SearchCriteria));
            }
            return predicate;
        }
    }
}
