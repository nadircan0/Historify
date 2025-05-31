using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Users.Queries.GetList;

public class GetListUserListItemDto : IDto
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public int TotalSearchCount { get; set; }
    public List<string> Roles { get; set; } = new();


    public GetListUserListItemDto()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        UserName = string.Empty;
        CountryCode = string.Empty;
        PhoneNumber = string.Empty;
        Email = string.Empty;
    }

    public GetListUserListItemDto(Guid id, string firstName, string lastName, string userName, string countryCode, string phoneNumber, string email)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        CountryCode = countryCode;
        PhoneNumber = phoneNumber;
        Email = email;


    }
}
