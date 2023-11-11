namespace Domain.Followers;

public interface IFollowerRepository
{
    Task<bool> IsAlreadyFollowing(Guid userId, Guid followedId, CancellationToken cancellationToken);
    Task Insert(Follower follower, CancellationToken cancellationToken);
}