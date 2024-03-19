using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
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

            var subscribers = await _subscriberRepository.GetAllSubscribersAsync();
            foreach (var subscriber in subscribers.Where(s => s.IsSubscribed))
            {
                //_emailClient.Send(subscriber.Email, subject, message); // Simplified send method
            }
        }
    }
}
