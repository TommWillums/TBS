using TBS.Entities;

namespace TBS.Data.Commands.Users
{
    public class SaveUser : ICommand
    {
        private readonly User _user;

        public SaveUser(User user)
        {
            _user = user;
        }

        public void Execute(ISession session)
        {
            if (_user.Id > 0)
            {
                session.Execute("update Users_Tbl set Name = @Name, ClubId = @ClubId, Deleted = @Deleted where Id = @Id", 
                    new { _user.Id, _user.Name, _user.ClubId, _user.Deleted });
                return;
            }

            session.Execute("insert into Users_Tbl (Name, ClubId) values (@Name, @ClubId)",
                new { _user.Name, _user.ClubId });
        }
    }

}
