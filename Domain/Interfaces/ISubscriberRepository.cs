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
        Task<IEnumerable<Subscribers>> GetAllSubscribersAsync();
        Task<Subscribers> Addsubscribers(Subscribers subscriber);
        Task<Subscribers> RemoveSubscriber(Guid subscriber);
    }
}
