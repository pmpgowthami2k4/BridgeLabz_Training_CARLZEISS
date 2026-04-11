using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.RabbitMQ
{
    public interface IRabbitMQProducer
    {
        Task SendMessage<T>(T message); // ✅ MUST BE Task
    }
}
