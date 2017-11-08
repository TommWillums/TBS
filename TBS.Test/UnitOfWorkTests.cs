using System;
using System.Collections.Generic;
using System.Text;

namespace TBS.Test
{
    class UnitOfWorkTests
    {
#if XXX
                    //TEST START
            if (club.Id == 100)
            {
                var uow = new UnitOfWork(_repository.Session);
                var userRepo = new UserRepository(new CQHandler(new Session(new Data.Dapper.DapperContext(Util.AppSettings.DefaultDatabaseConnection))));

                User user1 = userRepo.Get(10003);
                user1.Name = "USER Martin 1";
                userRepo.Save(user1);

                userRepo.JoinUnitOfWork(uow);
                _repository.JoinUnitOfWork(uow);

                user1.Name = "USER NAME 1 AGAIN";
                club.Contact = "CONTACT NAME 1";
                userRepo.Save(new User { Name = "USER GOOD 1", ClubId = 100 });
                userRepo.Save(user1);
                _repository.Save(club);

                uow.Rollback();
            }
            if (club.Id == 101)
            {
                var uow = new UnitOfWork(_repository.Session);
                var userRepo = new UserRepository(new CQHandler(new Session(new Data.Dapper.DapperContext(Util.AppSettings.DefaultDatabaseConnection))));

                User user1 = userRepo.Get(10003);
                user1.Name = "USER NAME 2";
                userRepo.Save(user1);

                userRepo.JoinUnitOfWork(uow);
                _repository.JoinUnitOfWork(uow);

                user1.Name = "USER NAME 2";
                club.Contact = "CONTACT NAME 2";
                userRepo.Save(new User { Name = "USER GOOD 2", ClubId = 100 });
                userRepo.Save(user1);
                _repository.Save(club);

                uow.Commit();
            }
            //TEST END
#endif
    }
}
