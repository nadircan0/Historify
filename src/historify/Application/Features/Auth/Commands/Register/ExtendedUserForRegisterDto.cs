using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Auth.Commands.Register;

public class ExtendedUserForRegisterDto : UserForRegisterDto
{
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string CountryCode { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;


    public ExtendedUserForRegisterDto() : base()
    {
    }

    public ExtendedUserForRegisterDto(string email, string password, string name, string surname, string userName, string countryCode, string phoneNumber, string role = "User", int totalSearchCount = 0)
        : base(email, password)
    {
        Name = name;
        Surname = surname;
        UserName = userName;
        CountryCode = countryCode;
        PhoneNumber = phoneNumber;
    }
}
