using Domain.Abstraction;

namespace Domain.Users;

public sealed class User : Entity
{
    private User(Guid id, Email email, Name name, bool hasPublicProfile)
        : base(id)
    {
        Name = name;
        Email = email;
        HasPublicProfile = hasPublicProfile;
    }

    private User() { }

    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public bool HasPublicProfile { get; private set; }

    public static User Create(Email email, Name name, bool hasPublicProfile)
    {
        var user = new User(Guid.NewGuid(), email, name, hasPublicProfile);

        user.Raise(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}