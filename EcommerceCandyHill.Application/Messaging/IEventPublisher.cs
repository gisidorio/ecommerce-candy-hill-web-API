using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Application.Messaging
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T @event, string queueName) where T : class;
    }
}
