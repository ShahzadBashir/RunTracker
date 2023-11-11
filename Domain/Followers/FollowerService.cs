using Domain.Users;

namespace Domain.Followers;

public sealed class FollowerService
{
    private readonly IFollowerRepository _followerRepository;

    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }

    public async Task StartFollowing(
        User user, 
        User followed, 
        DateTime createdOnUtc, 
        CancellationToken cancellationToken)
    {
        if(user.Id == followed.Id)
        {
            throw new Exception("User can't follow yourself");
        }

        if(!followed.HasPublicProfile)
        {
            throw new Exception("Can't follow pon-public profile");
        }

        if(await _followerRepository.IsAlreadyFollowing(
            user.Id,
            followed.Id, 
            cancellationToken))
        {
            throw new Exception("Already following");
        }

        var follower = Follower.Create(user.Id, followed.Id, createdOnUtc);

        await _followerRepository.Insert(follower, cancellationToken);
    }
}

public interface IFollowerRepository
{
    Task<bool> IsAlreadyFollowing(Guid userId, Guid followedId, CancellationToken cancellationToken);
    Task Insert(Follower follower, CancellationToken cancellationToken);
}