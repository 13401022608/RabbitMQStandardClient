using System;

namespace RabbitMQ.Standard.Client {
    public class DefaultMessageProducer<T> : ServerConnection, IProducer<T> where T : Message {
        public DefaultMessageProducer (string queue, string exchange) : base (queue, exchange) {

        }

        public DefaultMessageProducer (string queue, string exchange, string routingKey) : base (queue, exchange, routingKey) {

        }

        public DefaultMessageProducer (Queue queue, Exchange exchange) : base (queue, exchange) {

        }

        public DefaultMessageProducer (Queue queue, Exchange exchange, string routingKey) : base (queue, exchange, routingKey) {

        }

        public event Action<T> BeforeSend;
        public event Action<T> AfterSend;

        public void Send (T message) {
            if(BeforeSend!=null){
                BeforeSend(message);
            }
            //Model.BasicPublish(exchange, routingKey, false, null, )

            if(AfterSend!=null){
                AfterSend(message);
            }
        }
    }
}