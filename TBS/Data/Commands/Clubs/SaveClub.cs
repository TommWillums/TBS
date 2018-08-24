using System.Data;
using Dapper;
using TBS.Entities;

namespace TBS.Data.Commands.Clubs
{
    public class SaveClub : ICommand
    {
        private readonly Club _club;

        public SaveClub(Club club)
        {
            _club = club;
        }

        public void Execute(IDbConnection session)
        {
            if (_club.Id > 0)
            {
                session.Execute("update Clubs_Tbl set ClubName = @ClubName, ShortName = @ShortName, Contact = @Contact, CustomerId = @CustomerId, Active = @Active where Id = @Id", 
                    new { _club.Id, _club.ClubName, _club.ShortName, _club.Contact, _club.CustomerId, _club.Active });
                return;
            }

            session.Execute("insert into Clubs_Tbl (ClubName, ShortName, Contact, CustomerId) values (@ClubName, @ShortName, @Contact, @CustomerId)",
                new { _club.ClubName, _club.ShortName, _club.Contact, _club.CustomerId });
        }
    }

}
