namespace PropMZ.Services
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.Extensions.Options;
    using SendGrid;
    using SendGrid.Helpers.Mail;

    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<AuthMessageSenderOptions> optionsAccessor) => Options = optionsAccessor.Value;

        private AuthMessageSenderOptions Options { get; } //set only via Secret Manager

        #region IEmailSender Members
        public Task SendEmailAsync(string email, string subject, string message) =>
                Execute(Options.SendGridKey, subject, message, email);
        #endregion

        private Task Execute(string apiKey, string subject, string message, string email)
        {
            SendGridClient client = new SendGridClient(apiKey);
            SendGridMessage msg = new SendGridMessage
                                  {
                                          From             = new EmailAddress("Joe@contoso.com", "Password Recovery"),
                                          Subject          = subject,
                                          PlainTextContent = message,
                                          HtmlContent      = message
                                  };
            msg.AddTo(new EmailAddress(email));

            // Disable click tracking.
            // See https://sendgrid.com/docs/User_Guide/Settings/tracking.html
            msg.SetClickTracking(false, false);

            return client.SendEmailAsync(msg);
        }
    }
}
