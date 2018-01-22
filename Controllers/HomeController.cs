using GigHub.Models;
using GigHub.Persistence;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new ApplicationDbContext());
        }
        public ActionResult Index(string query = null)
        {
            var upcomingGigs = _unitOfWork.Gigs.GetFutureGigs();

            if (!String.IsNullOrWhiteSpace(query))
            {
                upcomingGigs = (List<Gig>)upcomingGigs.Where(g =>
                   g.Artist.Name.Contains(query) ||
                   g.Genre.Name.Contains(query) ||
                   g.Venue.Contains(query));
            }

            var userId = User.Identity.GetUserId();
            var attendances = _unitOfWork.Attendance.GetFutureAttendances(userId).ToLookup(a => a.GigId);

            var viewModel = new GigsViewModel
            {
                UpComingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated,
                Heading = "Upcoming Events",
                SearchTerm = query,
                Attaendances = attendances
            };
            return View("Gigs", viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}