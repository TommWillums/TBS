--=============================================================================
-- 03_TBS_Fill_Testdata.sql
--=============================================================================
use TBS
go

/* Clubs */

delete from Clubs_Tbl
DBCC CheckIdent (Clubs_Tbl, RESEED, 100);

insert into Clubs_Tbl (ClubName, ShortName, Contact) values ('Porsgrunn Tennisklubb', 'PTK', 'Tomm W')
go

/* Courts */

delete from Courts_Tbl
DBCC CheckIdent (Courts_Tbl, RESEED, 0);

insert into Courts_Tbl (ClubId, Name) values (100, 'Bane 1 Hall')
insert into Courts_Tbl (ClubId, Name) values (100, 'Bane 2 Hall')
insert into Courts_Tbl (ClubId, Name) values (100, 'Bane 3 Hall')
insert into Courts_Tbl (ClubId, Name) values (100, 'Bane 4 Hall')
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (100, 'Bane 1 Ute', 1, 0)
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (100, 'Bane 2 Ute', 1, 0)
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (100, 'Bane 3 Ute', 1, 0)
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (100, 'Bane 4 Ute', 1, 0)

/* Users */

delete from Users_Tbl
DBCC CheckIdent (Users_Tbl, RESEED, 10000);

insert into Users_Tbl (Name) values ('Tomm Willums')
insert into Users_Tbl (Name) values ('Tomas Karell')
insert into Users_Tbl (Name) values ('Urban')
insert into Users_Tbl (Name) values ('Martin Kristoffersen')
go

/*
select * from Clubs
select * from Courts
select * from Courts_v
select * from Users
*/
