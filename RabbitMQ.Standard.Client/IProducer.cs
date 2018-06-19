using System;

namespace RabbitMQ.Standard.Client {
    public interface IProducer<T> {
        void Send (T message);
        event Action<T> BeforeSend;
        event Action<T> AfterSend;
    }
}