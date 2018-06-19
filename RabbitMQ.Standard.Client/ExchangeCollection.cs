using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace RabbitMQ.Standard.Client
{
    public class ExchangeCollection : ConcurrentDictionary<string, Exchange>
    {
    }
}