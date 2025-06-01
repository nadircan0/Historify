using Application.Features.FileAttachments.Queries.Download;
using Application.Features.UserImages.Commands.Create;
using Application.Features.UserImages.Commands.Delete;
using Application.Features.UserImages.Commands.Update;
using Application.Features.UserImages.Queries.DownloadById;
using Application.Features.UserImages.Queries.GetById;
using Application.Features.UserImages.Queries.GetList;
using Microsoft.AspNetCore.Mvc;
using NArchitecture.Core.Application.Requests;
using NArchitecture.Core.Application.Responses;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserImagesController : BaseController
{
    [HttpPost]
    public async Task<ActionResult<CreatedUserImageResponse>> Add([FromForm] CreateUserImageCommand command)
    {
        CreatedUserImageResponse response = await Mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { response.Id }, response);
    }

    [HttpPut]
    public async Task<ActionResult<UpdatedUserImageResponse>> Update([FromBody] UpdateUserImageCommand command)
    {
        UpdatedUserImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<DeletedUserImageResponse>> Delete([FromRoute] Guid id)
    {
        DeleteUserImageCommand command = new() { Id = id };

        DeletedUserImageResponse response = await Mediator.Send(command);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetByIdUserImageResponse>> GetById([FromRoute] Guid id)
    {
        GetByIdUserImageQuery query = new() { Id = id };

        GetByIdUserImageResponse response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet]
    public async Task<ActionResult<GetListResponse<GetListUserImageListItemDto>>> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListUserImageQuery query = new() { PageRequest = pageRequest };

        GetListResponse<GetListUserImageListItemDto> response = await Mediator.Send(query);

        return Ok(response);
    }

    [HttpGet("download/{userId}")]
    public async Task<ActionResult<List<DownloadUserImagesResponse>>> DownloadByUserId([FromRoute] Guid userId)
    {
        DownloadUserImagesQuery query = new() { UserId = userId };

        List<DownloadUserImagesResponse> response = await Mediator.Send(query);

        return Ok(response);
    }
}
