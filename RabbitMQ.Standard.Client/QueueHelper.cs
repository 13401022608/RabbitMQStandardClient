using RabbitMQ.Client;

namespace RabbitMQ.Standard.Client
{
    public static class QueueHelper
    {
        private static Server _server;
        static QueueHelper()
        {
            _server = new Server();
        }

        public static bool CreateQueue(Queue queue)
        {
            return true;
        }

         public static bool CreateQueue(string name)
        {
            return true;
        }
    }
}