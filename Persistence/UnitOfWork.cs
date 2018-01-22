using GigHub.Models;
using GigHub.Repositories;

namespace GigHub.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IGigRepository Gigs { get; set; }
        public IAttendanceRepository Attendance { get; set; }
        public IFollowingRepository Following { get; set; }
        public IGenreRepository Genre { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Gigs = new GigRepository(context);
            Attendance = new AttendanceRepository(context);
            Following = new FollowingRepository(context);
            Genre = new GenreRepository(context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}