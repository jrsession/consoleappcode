using Domain.Interfaces;
using Domain.Entities;

namespace ApplicationLayer.Services
{
    public class SubscriptionService
    {
        private readonly ISubscriberRepository _subscriberRepository;

        public SubscriptionService(ISubscriberRepository subscriberRepository)
        {
            _subscriberRepository = subscriberRepository;
        }

        public async Task SubscribeAsync(string email)
        {
            var subscriber = new Subscriber { Id = Guid.NewGuid(), Email = email, IsSubscribed = true };
            await _subscriberRepository.AddSubscriberAsync(subscriber);
        }

        public async Task UnsubscribeAsync(Guid subscriberId)
        {
            await _subscriberRepository.RemoveSubscriberAsync(subscriberId);
        }

    }
}
