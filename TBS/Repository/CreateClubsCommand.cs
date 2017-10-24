using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using TBS.Domain;
using TBS.Persistence;

namespace TBS.Repository
{
    public class CreateClubsCommand : ICommand
    {
        readonly Club club;

        public CreateClubsCommand(Club club)
        {
            this.club = new Club() { ClubName = "Sandefjord Tennisklubb", ShortName = "STK", Contact = "Espen S" };
        }
        public void Execute(IDbConnection db)
        {
            db.Execute("insert into Clubs (ClubName, ShortName, Contact) values (@ClubName, @ShortName, @Contact)",
                new { club.ClubName, club.ShortName, club.Contact });
        }
    }
}
