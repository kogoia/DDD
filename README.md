# DDD

```cs
var events = new TabAggregateRoot(
                 new AppliedTabCreatedEvent(127, "VIP-Table")
             ).Apply(
                 new TabEvent(
                     new TabOpendEvent("Saba")
                 )
             ).Apply(
                 new TabEvent(
                     new TabClosedEvent(49.50m)
                 )
             ).UncommitedEvents();
```
