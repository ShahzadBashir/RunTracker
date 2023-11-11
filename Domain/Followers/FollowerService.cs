using Domain.Abstraction;
using Domain.Users;

namespace Domain.Followers;

public sealed class FollowerService
{
    private readonly IFollowerRepository _followerRepository;

    public FollowerService(IFollowerRepository followerRepository)
    {
        _followerRepository = followerRepository;
    }

    public async Task<Result> StartFollowing(
        User user, 
        User followed, 
        DateTime createdOnUtc, 
        CancellationToken cancellationToken)
    {
        if(user.Id == followed.Id)
        {
            return Result.Failure(FollowerErrors.SameUser);
        }

        if(!followed.HasPublicProfile)
        {
            return Result.Failure(FollowerErrors.NonPublicProfile);
        }

        if(await _followerRepository.IsAlreadyFollowing(
            user.Id,
            followed.Id, 
            cancellationToken))
        {
            return Result.Failure(FollowerErrors.AlreadyFollowing);
        }

        var follower = Follower.Create(user.Id, followed.Id, createdOnUtc);

        await _followerRepository.Insert(follower, cancellationToken);

        return Result.Success();
    }
}
