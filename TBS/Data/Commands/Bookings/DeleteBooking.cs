using System.Data;
using Dapper;

namespace TBS.Data.Commands.Bookings
{
    public class DeleteBooking : ICommand
    {
        private readonly int _id;

        public DeleteBooking(int id)
        {
            _id = id;
        }

        public void Execute(IDbConnection connection)
        {
            connection.Execute("update Bookings_Tbl set Deleted = 1 where Id = @Id", new { Id = _id });
        }
    }

}
