using Application.Features.FileAttachments.Commands.Create;
using Application.Features.FileAttachments.Commands.Delete;
using Application.Features.FileAttachments.Commands.Update;
using Application.Features.FileAttachments.Queries.GetById;
using Application.Features.FileAttachments.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FileAttachmentsController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedFileAttachmentResponse>> Add([FromBody] CreateFileAttachmentCommand command)
    {
        CreatedFileAttachmentResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedFileAttachmentResponse>> Update([FromBody] UpdateFileAttachmentCommand command)
    {
        UpdatedFileAttachmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedFileAttachmentResponse>> Delete([FromRoute] Guid id)
    {
        DeleteFileAttachmentCommand command = new() { Id = id };

        DeletedFileAttachmentResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdFileAttachmentResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdFileAttachmentQuery query = new() { Id = id };

        GetByIdFileAttachmentResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListFileAttachmentListItemDto>>> GetList(
        [FromQuery] PageRequest pageRequest
    )
    {
        GetListFileAttachmentQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListFileAttachmentListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }
}
