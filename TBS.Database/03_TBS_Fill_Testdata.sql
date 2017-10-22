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

/* Courts */

delete from Courts
DBCC CheckIdent (Courts, RESEED, 0);

insert into Courts (ClubId, Name) values (100, 'Bane 1 Hall')
insert into Courts (ClubId, Name) values (100, 'Bane 2 Hall')
insert into Courts (ClubId, Name) values (100, 'Bane 3 Hall')
insert into Courts (ClubId, Name) values (100, 'Bane 4 Hall')
insert into Courts (ClubId, Name, CourtGroup, Active) values (100, 'Bane 1 Ute', 1, 0)
insert into Courts (ClubId, Name, CourtGroup, Active) values (100, 'Bane 2 Ute', 1, 0)
insert into Courts (ClubId, Name, CourtGroup, Active) values (100, 'Bane 3 Ute', 1, 0)
insert into Courts (ClubId, Name, CourtGroup, Active) values (100, 'Bane 4 Ute', 1, 0)

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
select * from Courts_v
select * from Users
*/

