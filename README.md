# DDD

```cs
var store = new List<Tuple<int, IDomainEventType>>()
{
    new Tuple<int, IDomainEventType>(
        127, 
        new TabEventType(
            new TabCreatedEvent(127, "VIP-Table")
        )
    ),
    new Tuple<int, IDomainEventType>(
        127,
        new TabEventType(
            new TabOpendEvent("Saba")
        )
    )
};


var eventStream = new EventStream(
                    127,
                    store
                );

var events = new Tab(
                eventStream
             ).Apply(
                 new TabEventType(
                     new TabClosedEvent(49.50m)
                 )
             ).UncommitedEvents(); // TabClosedEvent - 49.50m
```
