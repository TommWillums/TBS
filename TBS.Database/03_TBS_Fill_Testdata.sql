--=============================================================================
-- 03_TBS_Fill_Testdata.sql
--=============================================================================
use TBS
go

/* Clubs */

delete from Clubs_Tbl
DBCC CheckIdent (Clubs_Tbl, RESEED, 100);
insert into Clubs_Tbl (ClubName, ShortName, Contact) values ('Porsgrunn Tennisklubb', 'PTK', 'Tomm W')
insert into Clubs_Tbl (ClubName, ShortName, Contact) values ('Kristiansand Tennisklubb', 'KTK', 'Lise')
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

insert into Courts_Tbl (ClubId, Name) values (101, 'Innebane 1')
insert into Courts_Tbl (ClubId, Name) values (101, 'Innebane 2')
insert into Courts_Tbl (ClubId, Name) values (101, 'Innebane 3')


/* Users */

delete from Users_Tbl
DBCC CheckIdent (Users_Tbl, RESEED, 10000);

insert into Users_Tbl (Name, ClubId) values ('Tomm Willums', 100)
insert into Users_Tbl (Name, ClubId) values ('Tomas Karell', 100)
insert into Users_Tbl (Name, ClubId) values ('Urban', 100)
insert into Users_Tbl (Name, ClubId) values ('Martin Kristoffersen', 100)

insert into Users_Tbl (Name, ClubId) values ('Lise Larsen', 101)
go

/*
select * from Clubs
select * from Courts
select * from Courts_v
select * from Users
*/
