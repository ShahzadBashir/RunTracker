using Domain.Abstraction;

namespace Domain.Followers;

public static class FollowerErrors
{
    public static readonly Error SameUser = new("Follower.SameUser", "User can't follow yourself");
    public static readonly Error NonPublicProfile = new("Follower.NonPublicProfile", "Can't follow pon-public profile");
    public static readonly Error AlreadyFollowing = new("Follower.AlreadyFollowing", "User is already following");
}