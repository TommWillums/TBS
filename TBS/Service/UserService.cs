using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Users;
using TBS.Data.Queries.Users;
using TBS.Domain;

namespace TBS.Service
{
    public interface IUserService
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers(int clubId);
        void Save(User user);
    }

    public class UserService : ServiceBase, IUserService
    {
        public UserService(IDatabase database = null) : base(database) { }

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
