using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Domain;

namespace TBS.Data.Commands.Clubs
{
    public class SaveClub : ICommand
    {
        private readonly Club _animal;

        public SaveClub(Club animal)
        {
            _animal = animal;
        }

        public void Execute(ISession session)
        {
            if (_animal.Id > 0)
            {
                session.Execute("UPDATE Clubs SET Name = @Name, CommonName = @CommonName WHERE Id = @Id", new { _animal.Id, _animal.Name, _animal.CommonName });
                return;
            }

            session.Execute("INSERT INTO Clubs (Name, CommonName) VALUES (@Name, @CommonName)", new { _animal.Name, _animal.CommonName });
        }
    }

}
