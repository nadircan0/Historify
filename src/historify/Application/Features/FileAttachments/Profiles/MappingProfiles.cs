using Application.Features.FileAttachments.Commands.Create;
using Application.Features.FileAttachments.Commands.Delete;
using Application.Features.FileAttachments.Commands.Update;
using Application.Features.FileAttachments.Queries.GetById;
using Application.Features.FileAttachments.Queries.GetList;
using AutoMapper;
using NArchitecture.Core.Application.Responses;
using Domain.Entities;
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
    }
}