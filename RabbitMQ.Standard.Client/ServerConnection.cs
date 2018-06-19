using System;
using RabbitMQ.Client;

namespace RabbitMQ.Standard.Client {
    public abstract class ServerConnection : IServerConnection, IDisposable {
        protected IConnection Connection { get; set; }

        protected IModel Model { get; set; }

        protected Queue Queue { get; set; }

        protected Exchange Exchange { get; set; }

        protected string RoutingKey { get; set; }

        public ServerConnection (string queue, string exchange) : this (queue, exchange, string.Empty) {

        }

        public ServerConnection (string queue, string exchange, string routingKey) {
            Queue outQueue;
            Exchange outExchange;
            QueueContext.Instance.Exchanges.TryGetValue (exchange, out outExchange);
            QueueContext.Instance.Queues.TryGetValue (queue, out outQueue);
            Queue = outQueue;
            Exchange = outExchange;
            RoutingKey = routingKey;
            Init ();
        }

        public ServerConnection (Queue queue, Exchange exchange) : this (queue, exchange, string.Empty) {

        }

        public ServerConnection (Queue queue, Exchange exchange, string routingKey) {
            Queue = queue;
            Exchange = exchange;
            RoutingKey = routingKey;
            Init ();
        }

        private void Init () {
            Server = new Server ();
            Server.Host = "10.129.6.144";
            Server.UserName = "user1";
            Server.Password = "user1";

            CreateConnection ();
            CreateModel ();
            Binding ();
        }

        public Server Server { get; set; }

        protected virtual void Binding () {
            Model.ExchangeDeclare (Exchange.Name, Exchange.Type, Exchange.Durable, Exchange.AutoDelete, null);
            var result = Model.QueueDeclare (Queue.Name, Queue.Durable, Queue.Exclusive, Queue.AutoDelete, null);
            Model.QueueBind (Queue.Name, Exchange.Name, RoutingKey, null);
        }

        protected void CloseConnection () {
            if (Connection != null) {
                Connection.Close ();
            }
        }

        protected void CloseModel () {
            if (Model != null) {
                Model.Close ();
            }
        }

        protected void Close () {
            CloseModel ();
            CloseConnection ();
        }

        protected virtual void CreateConnection () {
            if (Connection == null) {
                var factory = new ConnectionFactory () {
                HostName = Server.Host,
                UserName = Server.UserName,
                Password = Server.Password
                };
                Connection = factory.CreateConnection ();
            }
        }

        protected virtual void CreateModel () {
            if (Model == null) {
                Model = Connection.CreateModel ();
            }
        }

        public void Dispose () {
            Close ();
        }
    }
}