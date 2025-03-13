using Application.Features.UserImages.Commands.Create;
using Application.Features.UserImages.Commands.Delete;
using Application.Features.UserImages.Commands.Update;
using Application.Features.UserImages.Queries.GetById;
using Application.Features.UserImages.Queries.GetList;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.UserImages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateUserImageCommand, UserImage>();
        CreateMap<UserImage, CreatedUserImageResponse>();

        CreateMap<UpdateUserImageCommand, UserImage>();
        CreateMap<UserImage, UpdatedUserImageResponse>();

        CreateMap<DeleteUserImageCommand, UserImage>();
        CreateMap<UserImage, DeletedUserImageResponse>();

        CreateMap<UserImage, GetByIdUserImageResponse>();

        CreateMap<UserImage, GetListUserImageListItemDto>();
        CreateMap<IPaginate<UserImage>, GetListResponse<GetListUserImageListItemDto>>();
    }
}