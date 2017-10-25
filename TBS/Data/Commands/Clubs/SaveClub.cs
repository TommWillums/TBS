using System;
using System.Collections.Generic;
using System.Linq;
using TBS.Domain;

namespace TBS.Data.Commands.Clubs
{
    public class SaveClub : ICommand
    {
        private readonly Club _club;

        public SaveClub(Club animal)
        {
            _club = animal;
        }

        public void Execute(ISession session)
        {
            if (_club.Id > 0)
            {
                session.Execute("UPDATE Clubs SET Name = @Name, CommonName = @CommonName WHERE Id = @Id", new { _club.Id, _club.Name, _club.CommonName });
                return;
            }

            session.Execute("insert into Clubs (ClubName, ShortName, Contact) values (@ClubName, @ShortName, @Contact)",
                new { _club.ClubName, _club.ShortName, _club.Contact });
        }
    }

}
