using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetAllSubscribersAsync();
        Task AddSubscriberAsync(Subscriber subscriber);
        Task RemoveSubscriberAsync(Guid subscriberId);
    }
}
