using Application.Features.FileAttachments.Queries.Download;
using Application.Features.UserImages.Commands.Create;
using Application.Features.UserImages.Commands.Delete;
using Application.Features.UserImages.Commands.Update;
using Application.Features.UserImages.Queries.DownloadByUserId;
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

        CreateMap<UserImage, DownloadUserImagesResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.UploadDate, opt => opt.MapFrom(src => src.UploadDate))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags))
                .ForMember(dest => dest.FileName, opt => opt.Ignore())
                .ForMember(dest => dest.ContentType, opt => opt.Ignore())
                .ForMember(dest => dest.FileAttachmentId, opt => opt.Ignore());


        CreateMap<DownloadFileAttachmentResponse, DownloadUserImagesResponse>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Description, opt => opt.Ignore())
            .ForMember(dest => dest.UploadDate, opt => opt.Ignore())
            .ForMember(dest => dest.Tags, opt => opt.Ignore())
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => src.ContentType))
            .ForMember(dest => dest.FileAttachmentId, opt => opt.MapFrom(src => src.Id));



        CreateMap<UserImage, GetListUserImageListItemDto>();
        CreateMap<IPaginate<UserImage>, GetListResponse<GetListUserImageListItemDto>>();
    }
}
