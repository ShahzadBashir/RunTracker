﻿namespace Domain.Abstraction;

public abstract class Entity
{
    private readonly List<IDomainEvent> _domainEvents = new();
    protected Entity(Guid id)
    {
        Id = id;
    }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    public Guid Id { get; init; }
    public List<IDomainEvent> DomainEvents => _domainEvents.ToList();
    protected void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}