namespace Application.SubServices.MailService
{
    public interface IMailService
    {
        Task SendMailAsync(MailDto mailDto);
        Task SendEmailAsync(NArchitecture.Core.Mailing.Mail mail);
    }
}
