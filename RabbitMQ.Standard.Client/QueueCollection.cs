using System.Collections.Concurrent;

namespace RabbitMQ.Standard.Client {
    public class QueueCollection : ConcurrentDictionary<string, Queue> {

    }
}