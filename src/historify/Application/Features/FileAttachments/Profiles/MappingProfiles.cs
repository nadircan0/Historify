using Application.Features.FileAttachments.Commands.Create;
using Application.Features.FileAttachments.Commands.Delete;
using Application.Features.FileAttachments.Commands.Update;
using Application.Features.FileAttachments.Queries.GetById;
using Application.Features.FileAttachments.Queries.GetList;
using Application.Features.FileAttachments.Queries.Download;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Responses;
using NArchitecture.Core.Persistence.Paging;

namespace Application.Features.FileAttachments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateFileAttachmentCommand, FileAttachment>();
        CreateMap<FileAttachment, CreatedFileAttachmentResponse>();

        CreateMap<UpdateFileAttachmentCommand, FileAttachment>();
        CreateMap<FileAttachment, UpdatedFileAttachmentResponse>();

        CreateMap<DeleteFileAttachmentCommand, FileAttachment>();
        CreateMap<FileAttachment, DeletedFileAttachmentResponse>();

        CreateMap<FileAttachment, GetByIdFileAttachmentResponse>();

        CreateMap<FileAttachment, GetListFileAttachmentListItemDto>();
        CreateMap<IPaginate<FileAttachment>, GetListResponse<GetListFileAttachmentListItemDto>>();

        CreateMap<FileAttachment, DownloadFileAttachmentResponse>()
            .ForMember(dest => dest.FileName, opt => opt.MapFrom(src => src.FileName))
            .ForMember(dest => dest.ContentType, opt => opt.MapFrom(src => GetContentType(src.FileName)))
            .ForMember(dest => dest.FileData, opt => opt.Ignore());
    }

    private string GetContentType(string fileName)
    {
        var extension = Path.GetExtension(fileName).ToLowerInvariant();
        return extension switch
        {
            ".jpg" or ".jpeg" => "image/jpeg",
            ".png" => "image/png",
            ".gif" => "image/gif",
            ".bmp" => "image/bmp",
            ".webp" => "image/webp",
            _ => "application/octet-stream"
        };
    }
}
