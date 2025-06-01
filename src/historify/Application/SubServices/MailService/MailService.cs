using MimeKit;
using NArchitecture.Core.Mailing;

namespace Application.SubServices.MailService;

public class MailService : IMailService
{
    private readonly NArchitecture.Core.Mailing.IMailService _mailService;

    public MailService(NArchitecture.Core.Mailing.IMailService mailService)
    {
        _mailService = mailService;
    }

    public async Task SendMailAsync(MailDto mailDto)
    {
        try
        {
            var mail = new Mail
            {
                Subject = mailDto.Subject,
                HtmlBody = mailDto.IsBodyHtml ? mailDto.Body : null,
                TextBody = !mailDto.IsBodyHtml ? mailDto.Body : null,
                ToList = new List<MailboxAddress> { new(mailDto.To, mailDto.To) }
            };

            await SendEmailAsync(mail);
        }
        catch (Exception ex)
        {
            throw new Exception($"Send Mail Error: {ex.Message}", ex);
        }
    }

    public async Task SendEmailAsync(Mail mail)
    {
        try
        {
            await _mailService.SendEmailAsync(mail);
        }
        catch (Exception ex)
        {
            throw new Exception($"Send Mail Error: {ex.Message}", ex);
        }
    }
}
