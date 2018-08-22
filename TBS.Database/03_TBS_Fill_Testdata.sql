--=============================================================================
-- 03_TBS_Fill_Testdata.sql
--=============================================================================
use TBS
go

/* All */
delete from Users_Tbl
delete from Courts_Tbl
delete from Clubs_Tbl

/* Clubs */

delete from Clubs_Tbl
insert into Clubs_Tbl (Id, ClubName, ShortName, Contact, CustomerId) values (1, 'Porsgrunn Tennisklubb', 'PTK', 'Tomm W', 1540)
go

/* Courts */

delete from Courts_Tbl
DBCC CheckIdent (Courts_Tbl, RESEED, 0);
insert into Courts_Tbl (ClubId, Name) values (1, 'Bane 1 Hall')
insert into Courts_Tbl (ClubId, Name) values (1, 'Bane 2 Hall')
insert into Courts_Tbl (ClubId, Name) values (1, 'Bane 3 Hall')
insert into Courts_Tbl (ClubId, Name) values (1, 'Bane 4 Hall')
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (1, 'Bane 1 Ute', 1, 0)
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (1, 'Bane 2 Ute', 1, 0)
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (1, 'Bane 3 Ute', 1, 0)
insert into Courts_Tbl (ClubId, Name, CourtGroup, Active) values (1, 'Bane 4 Ute', 1, 0)

/* Users */

delete from Users_Tbl
DBCC CheckIdent (Users_Tbl, RESEED, 9999);

insert into Users_Tbl (Name, ClubId) values ('Tomm Willums', 1)
insert into Users_Tbl (Name, ClubId) values ('Tomas Karell', 1)
insert into Users_Tbl (Name, ClubId) values ('Urban', 1)
insert into Users_Tbl (Name, ClubId) values ('Martin Kristoffersen', 1)
insert into Users_Tbl (Name, ClubId) values ('Lise', 1)
go

/*
select * from Clubs
select * from Courts
select * from Courts_v
select * from Users
*/
