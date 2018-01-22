using GigHub.Models;
using System.Linq;

namespace GigHub.Repositories
{
    public class FollowingRepository : IFollowingRepository
    {
        private readonly ApplicationDbContext _context;

        public FollowingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Following GetFollowing(string userId, string gigArtistId)
        {
            return _context
                .Followings
                .SingleOrDefault(f => f.Follower.Id == userId && f.Followee.Id == gigArtistId);
        }



        public void RemoveFollowing(Following following)
        {
            _context.Followings.Remove(following);
        }

        public void Add(Following following)
        {
            _context.Followings.Add(following);
        }
    }
}