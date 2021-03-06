﻿using System;
using System.Collections.Generic;

namespace DDD.CQRS.ES.Infrastructure
{
    public interface Reaction<out TEvent, TEntity>
        where TEvent : Message
    {
        public (Type eventType, Func<TEntity, Message, (TEntity state, IEnumerable<Message>)> react) Content();
    }
}
