using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IFollowingRepository
    {
        Following GetFollowing(string userId, string gigArtistId);
        void RemoveFollowing(Following following);
        void Add(Following following);
    }
}