using GigHub.Dtos;
using GigHub.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigHub.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .Select(u => u.Notification)
                .Include(n => n.Gig.Artist)
                .ToList();

            return notifications.Select(n => new NotificationDto
            {
                DateTime = n.DateTime,
                Type = n.Type,
                Gig = new GigDto
                {
                    Artist = new UserDto
                    {
                        Id = n.Gig.Artist.Id,
                        Name = n.Gig.Artist.Name
                    },
                    DateTime = n.Gig.DateTime,
                    Id = n.Gig.Id,
                    Venue = n.Gig.Venue,
                    IsCanceled = n.Gig.IsCanceled
                },
                OriginalVenue = n.OriginalVenue,
                OriginalDateTime = n.OriginalDateTime
            });
        }

        [HttpPost]
        public IHttpActionResult MaekAsRead()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(u => u.UserId == userId && !u.IsRead)
                .ToList();
            notifications.ForEach(n => n.Read());
            _context.SaveChanges();
            return Ok();
        }
    }
}
