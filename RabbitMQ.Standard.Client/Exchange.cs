using System.Collections.Generic;

namespace RabbitMQ.Standard.Client {
    public class Exchange {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool Durable { get; set; }

        public bool AutoDelete { get; set; }

        public Dictionary<string, object> Arguments { get; set; }
    }
}