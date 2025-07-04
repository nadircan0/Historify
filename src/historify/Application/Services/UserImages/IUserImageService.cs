using System.Linq.Expressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Services.UserImages;

public interface IUserImageService
{
    Task<UserImage?> GetAsync(
        Expression<Func<UserImage, bool>> predicate,
        Func<IQueryable<UserImage>, IIncludableQueryable<UserImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<UserImage>?> GetListAsync(
        Expression<Func<UserImage, bool>>? predicate = null,
        Func<IQueryable<UserImage>, IOrderedQueryable<UserImage>>? orderBy = null,
        Func<IQueryable<UserImage>, IIncludableQueryable<UserImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<UserImage> AddAsync(UserImage userImage);
    Task<UserImage> UpdateAsync(UserImage userImage);
    Task<UserImage> DeleteAsync(UserImage userImage, bool permanent = false);
    Task<UserImage?> GetByIdAsync(Guid id);
    Task<List<UserImage>> GetListByUserIdAsync(Guid userId);
}
