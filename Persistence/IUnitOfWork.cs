using GigHub.Repositories;

namespace GigHub.Persistence
{
    public interface IUnitOfWork
    {
        IGigRepository Gigs { get; set; }
        IAttendanceRepository Attendance { get; set; }
        IFollowingRepository Following { get; set; }
        IGenreRepository Genre { get; set; }
        void Complete();
    }
}