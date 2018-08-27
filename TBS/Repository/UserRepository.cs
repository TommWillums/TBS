using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Users;
using TBS.Data.Queries.Users;
using TBS.Entities;

namespace TBS.Repository
{
    public interface IUserRepository
    {
        User GetUser(int id);
        IEnumerable<User> GetUsers(int clubId);
        void Save(User user);
    }

    public class UserRepository : RepositoryBase, IUserRepository
    {
        public User GetUser(int id)
        {
            return QueryCmdHandler.Query(new GetUser(id));
        }

        public IEnumerable<User> GetUsers(int clubId)
        {
            return QueryCmdHandler.Query(new GetBookings(clubId)).ToList();
        }

        public void Save(User user)
        {
            QueryCmdHandler.Execute(new SaveUser(user));
        }

    }
}
