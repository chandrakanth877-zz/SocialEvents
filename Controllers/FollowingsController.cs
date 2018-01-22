using GigHub.Dtos;
using GigHub.Models;
using GigHub.Persistence;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace GigHub.Controllers
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FollowingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }

        [HttpPost]
        public IHttpActionResult Follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if (_unitOfWork.Following.GetFollowing(userId, dto.FolloweeId) != null)
            {
                return BadRequest();
            }
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _unitOfWork.Following.Add(following);
            _unitOfWork.Complete();
            return Ok();
        }


        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var userId = User.Identity.GetUserId();
            if (_unitOfWork.Following.GetFollowing(userId, id) == null)
            {
                return BadRequest();
            }
            var following = new Following
            {
                FollowerId = userId,
                FolloweeId = id
            };
            _unitOfWork.Following.RemoveFollowing(following);
            _unitOfWork.Complete();
            return Ok();
        }
    }
}
