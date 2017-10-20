--=============================================================================
-- 03_TBS_Fill_Testdata.sql
--=============================================================================
use TBS
go

/* Clubs */

delete from Clubs
DBCC CheckIdent (Clubs, RESEED, 100);

insert into Clubs (ClubName, ShortName, Contact) values ('Porsgrunn Tennisklubb', 'PTK', 'Tomm W')
go

/* Users */

delete from Users
DBCC CheckIdent (Users, RESEED, 10000);

insert into Users (Name) values ('Tomm Willums')
insert into Users (Name) values ('Tomas Karell')
insert into Users (Name) values ('Urban')
insert into Users (Name) values ('Martin Kristoffersen')
go

/*
select * from Clubs
select * from Users
*/
