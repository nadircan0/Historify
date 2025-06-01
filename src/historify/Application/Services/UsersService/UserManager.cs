using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Query;
using NArchitecture.Core.CrossCuttingConcerns.Exception.Types;
using NArchitecture.Core.Persistence.Paging;
using NArchitecture.Core.Security.Hashing;
using System.Linq.Expressions;
using System.Security.Claims;

namespace Application.Services.UsersService;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserBusinessRules _userBusinessRules;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserManager(
        IUserRepository userRepository,
        UserBusinessRules userBusinessRules,
        IHttpContextAccessor httpContextAccessor
    )
    {
        _userRepository = userRepository;
        _userBusinessRules = userBusinessRules;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<User?> GetAsync(
        Expression<Func<User, bool>> predicate,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        User? user = await _userRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return user;
    }

    public async Task<IPaginate<User>?> GetListAsync(
        Expression<Func<User, bool>>? predicate = null,
        Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null,
        Func<IQueryable<User>, IIncludableQueryable<User, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<User> userList = await _userRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return userList;
    }

    public async Task<User> AddAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenInsert(user.Email);

        User addedUser = await _userRepository.AddAsync(user);

        return addedUser;
    }

    public async Task<User> UpdateAsync(User user)
    {
        await _userBusinessRules.UserEmailShouldNotExistsWhenUpdate(user.Id, user.Email);

        User updatedUser = await _userRepository.UpdateAsync(user);

        return updatedUser;
    }

    public async Task<User> DeleteAsync(User user, bool permanent = false)
    {
        User deletedUser = await _userRepository.DeleteAsync(user);

        return deletedUser;
    }

    public async Task<bool> VerifyCurrentPassword(string currentPassword)
    {
        User currentUser = await GetCurrentUser();
        return HashingHelper.VerifyPasswordHash(currentPassword, currentUser.PasswordHash, currentUser.PasswordSalt);
    }

    public async Task ChangePasswordAsync(string currentPassword, string newPassword)
    {
        User currentUser = await GetCurrentUser();

        byte[] passwordHash,
            passwordSalt;
        HashingHelper.CreatePasswordHash(newPassword, out passwordHash, out passwordSalt);

        currentUser.PasswordHash = passwordHash;
        currentUser.PasswordSalt = passwordSalt;

        await UpdateAsync(currentUser);
    }

    private async Task<User> GetCurrentUser()
    {
        string userId =
            _httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
            ?? throw new BusinessException("User not found");

        return await GetAsync(predicate: u => u.Id == Guid.Parse(userId)) ?? throw new BusinessException("User not found");
    }
}
