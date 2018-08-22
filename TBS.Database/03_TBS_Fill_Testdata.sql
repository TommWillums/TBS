--=============================================================================
-- 03_TBS_Fill_Testdata.sql
--=============================================================================
use TBS
go

/* All */
delete from Bookings_Tbl
delete from Users_Tbl
delete from Courts_Tbl
delete from BookingTypes
delete from Clubs_Tbl

/* Clubs */
insert into Clubs_Tbl (Id, ClubName, ShortName, Contact, CustomerId) values (1, 'Porsgrunn Tennisklubb', 'PTK', 'Tomm W', 1540)
go

/* BookingTypes */

insert into BookingTypes (Id, Description, Colour) values (1, 'Fast', 'Grønn') 
insert into BookingTypes (Id, Description, Colour) values (2, 'Medlem', 'Gul') 
insert into BookingTypes (Id, Description, Colour) values (3, 'Mesterskap', 'Blå') 
insert into BookingTypes (Id, Description, Colour) values (4, 'Annet', 'Rød') 

/* Courts */

insert into Courts_Tbl (ClubId, Name) values (1, '?')
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

insert into Users_Tbl (Name, ClubId) values ('?', 1)
delete from Users_Tbl
DBCC CheckIdent (Users_Tbl, RESEED, 9999);

insert into Users_Tbl (Name, ClubId) values ('Tomm Willums', 1)
insert into Users_Tbl (Name, ClubId) values ('Tomas Karell', 1)
insert into Users_Tbl (Name, ClubId) values ('Urban', 1)
insert into Users_Tbl (Name, ClubId) values ('Martin Kristoffersen', 1)
insert into Users_Tbl (Name, ClubId) values ('Lise', 1)
go

/* Bookings */

truncate table Bookings_Tbl
DBCC CheckIdent (Bookings_Tbl, RESEED, 1000);

insert into Bookings_Tbl (CourtId, BookingType, UserId, StartTime, Duration) values (1, 1, 10000, GetDate(), 60)
insert into Bookings_Tbl (CourtId, BookingType, UserId, StartTime, Duration) values (1, 2, 10000, GetDate(), 60)
insert into Bookings_Tbl (CourtId, BookingType, UserId, StartTime, Duration) values (1, 3, 10001, GetDate(), 60)
insert into Bookings_Tbl (CourtId, BookingType, UserId, StartTime, Duration) values (1, 4, 10001, GetDate(), 60)

--update Bookings_Tbl set StartTime = dateadd(hour, 1, GetDate()) where Id = 1000
--update Bookings_Tbl set StartTime = dateadd(hour, 2, GetDate()) where Id = 1001
--update Bookings_Tbl set StartTime = dateadd(hour, 3, GetDate()) where Id = 1002
--update Bookings_Tbl set StartTime = dateadd(hour, 4, GetDate()) where Id = 1003

/*
select * from Clubs
select * from BookingTypes
select * from Bookings
select * from Courts
select * from Users
*/
