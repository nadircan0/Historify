using NArchitecture.Core.Application.Responses;

namespace Application.Features.Users.Commands.Create;

public class CreatedUserResponse : IResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string UserName { get; set; }
    public string CountryCode { get; set; }
    public string PhoneNumber { get; set; }

    public CreatedUserResponse()
    {
        Email = string.Empty;
        Name = string.Empty;
        Surname = string.Empty;
        UserName = string.Empty;
        CountryCode = string.Empty;
        PhoneNumber = string.Empty;

    }

    public CreatedUserResponse(Guid id, string email, string name, string surname, string userName, string countryCode, string phoneNumber)
    {
        Id = id;
        Email = email;
        Name = name;
        Surname = surname;
        UserName = userName;
        CountryCode = countryCode;
        PhoneNumber = phoneNumber;

    }
}