using TBS.Domain;

namespace TBS.Data.Commands.Clubs
{
    public class SaveClub : ICommand
    {
        private readonly Club _club;

        public SaveClub(Club club)
        {
            _club = club;
        }

        public void Execute(ISession session)
        {
            if (_club.Id > 0)
            {
                session.Execute("update Clubs_Tbl set ClubName = @ClubName, ShortName = @ShortName, Contact = @Contact, Deleted = @Deleted where Id = @Id", 
                    new { _club.Id, _club.ClubName, _club.ShortName, _club.Contact, _club.Deleted });
                return;
            }

            session.Execute("insert into Clubs_Tbl (ClubName, ShortName, Contact) values (@ClubName, @ShortName, @Contact)",
                new { _club.ClubName, _club.ShortName, _club.Contact });
        }
    }

}
