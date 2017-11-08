using System.Collections.Generic;
using System.Linq;
using TBS.Data;
using TBS.Data.Commands.Users;
using TBS.Data.Queries.Users;
using TBS.Domain;

namespace TBS.Repository
{
    public class UserRepository : IRepository<User>
    {
        private readonly ICQHandler _cqhandler;
        ICQHandler CQHandler => _cqhandler;

        public UserRepository(ICQHandler cqhandler)
        {
            _cqhandler = cqhandler;
        }

        //public UserRepository(UnitOfWork unitOfWork = null) : base(unitOfWork) { }

        public User Get(int id)
        {
            return CQHandler.Query(new GetUser(id));
        }

        public IEnumerable<User> GetAll()
        {
            return null;
        }

        public IEnumerable<User> GetList(int id)
        {
            return CQHandler.Query(new GetUsersByClub(id)).ToList();
        }

        public void Save(User user)
        {
            CQHandler.Execute(new SaveUser(user));
        }

        public void Remove(User entity)
        {
            entity.Deleted = true;
            Save(entity);
        }
    }
}
