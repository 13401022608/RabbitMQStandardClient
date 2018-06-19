namespace RabbitMQ.Standard.Client {
    public class QueueContext {

        private static QueueContext _context = new QueueContext ();
        private QueueContext () {
            Exchanges = new ExchangeCollection ();
            Queues = new QueueCollection ();

            Exchanges.GetOrAdd ("xuyan-core-exchange", new Exchange {
                Name = "xuyan-core-exchange",
                Type = "direct",
                Durable = true,
                AutoDelete = false
            });
            Queues.GetOrAdd ("xuyan-core-queue", new Queue {
                Name = "xuyan-core-queue",
                Durable = true,
                Exclusive = false,
                AutoDelete = false
            });
        }
        public static QueueContext Instance {
            get {
                return _context;
            }
        }

        public ExchangeCollection Exchanges { get; }

        public QueueCollection Queues { get; }

        public void ReloadExchanges () {

        }

        public void ReloadQueues () {

        }
    }
}