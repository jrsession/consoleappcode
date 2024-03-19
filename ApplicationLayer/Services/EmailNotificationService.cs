using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Services
{
    public class EmailNotificationService : INotificationService
    {
        private readonly ISubscriberRepository _subscriberRepository;
        // Assuming EmailClient is a simplified class to send emails
        private readonly EmailClient _emailClient;

        public EmailNotificationService(ISubscriberRepository subscriberRepository, EmailClient emailClient)
        {
            _subscriberRepository = subscriberRepository;
            _emailClient = emailClient;
        }

        public async Task SendNotificationAsync(string subject, string message)
        {
            var subscribers = await _subscriberRepository.GetAllSubscribersAsync();
            foreach (var subscriber in subscribers.Where(s => s.IsSubscribed))
            {
                _emailClient.Send(subscriber.Email, subject, message); // Simplified send method
            }
        }
    }
}
