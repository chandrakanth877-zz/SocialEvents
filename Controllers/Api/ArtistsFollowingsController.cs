using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using GigHub.Models;
using Microsoft.AspNet.Identity;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class ArtistsFollowingsController : Controller
    {
        private ApplicationDbContext _context;

        public ArtistsFollowingsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: ArtistsFollowings
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var followings = _context.Followings.Where(f => f.FollowerId == userId).Include(a => a.Followee).ToList();

            return View(followings);
        }
    }
}