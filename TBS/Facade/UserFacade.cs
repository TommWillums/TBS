using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Users;
using TBS.Data.Queries.Users;
using TBS.Domain;

namespace TBS.Facade
{
    public interface IUserFacade
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers(int clubId);
        void Save(User user);
    }

    public class UserFacade : FacadeBase, IUserFacade
    {
        public UserFacade(IDatabase database = null) : base(database) { }

        public User GetUser(int id)
        {
            return Database.Query(new GetUser(id));
        }

        public IEnumerable<User> GetUsers(int clubId)
        {
            return Database.Query(new GetUsersByClub(clubId)).ToList();
        }

        public void Save(User user)
        {
            Database.Execute(new SaveUser(user));
        }

    }
}
