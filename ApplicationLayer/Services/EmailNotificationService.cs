using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using System.Net.Mail;

namespace ApplicationLayer.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        private readonly IConfiguration _configuration;

        public EmailNotificationService(ISubscriberRepository subscriberRepository, IConfiguration configuration)
        {
            _subscriberRepository = subscriberRepository;
            _configuration = configuration;
        }

        public EmailNotificationService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
            
        }

        public async Task SendNotificationAsync(string subject, string message)
        {

            var apiKey = _configuration["SendGrid:ApiKey"];
            var client = new SendGridClient(apiKey);
            var from = new SendGrid.Helpers.Mail.EmailAddress("your-email@example.com", "Example Sender");
            var subscribers = await _subscriberRepository.GetAllSubscribersAsync();

            foreach (var subscriber in subscribers.Where(s => s.IsSubscribed))
            {
                var to = new SendGrid.Helpers.Mail.EmailAddress(subscriber.Email);
                var plainTextContent = message;
                var htmlContent = $"<strong>{message}</strong>";
                var msg = SendGrid.Helpers.Mail.MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                // Optionally, handle the response
            }
        }
    }
}
