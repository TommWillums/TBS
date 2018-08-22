--=============================================================================
-- 01_TBS_Create_Schema.sql
--=============================================================================
if (not exists(select name from sys.databases where name = 'TBS'))
	create database TBS;
go

use TBS
go

if (exists(select * from sys.tables where name = 'Users_Tbl'))
	drop table Users_Tbl;

if (exists(select * from sys.tables where name = 'Courts_Tbl'))
	drop table Courts_Tbl;

if (exists(select * from sys.tables where name = 'Clubs_Tbl'))
	drop table Clubs_Tbl;

/* 
   Club -- Only one club per database is allowed.
   Use separate databases for each club due to security, scalability and simpler restore on the expense of maintainability. 
*/
create table Clubs_Tbl (
	Id				int			 not null primary key check (Id in (1,2)),	-- 1 is prod, 2 is for test
	ClubName		varchar(100) not null,
	ShortName		varchar(20)  not null,
	Contact			varchar(50)	 not null,
	CustomerId		int			 not null,
--	Address			varchar(100) null,
--	CourtCount		int			 not null default 0,
--	Subscription	varchar(20)	 null,
--	Price			money		 not null default 0.0,
--	AutoRenewal		bit			 not null default 0,
--	NextRenewalDate	datetime2	 null,
	Active			bit			 not null default 1,
	Created			datetime2	 not null default GetDate()
)
create unique index ix_ShortName on Clubs_Tbl (ShortName)
go

/* Courts */

create table Courts_Tbl (
	Id				int			not null identity primary key,
	Name			varchar(20) not null,       
    ClubId			int			not null references Clubs_Tbl(Id),
    CourtGroup		int			not null default 0,    
    Active			bit			not null default 1,
    CourtType		varchar(20) null,       
    Location		varchar(20) null,
	MapCoordinates	geography	null,
    VisibleFor		varchar(50)	null, 
	Created			datetime2	not null default GetDate(),
	Deleted			bit			not null default 0,
)
go

/* Users */

create table Users_Tbl (
	Id			int			not null identity primary key,
	Name		varchar(50)	not null,
	ClubId		int			null references Clubs_Tbl (Id),
	Deleted		bit			not null default 0,
)
go

/* VIEWS */

if (exists(select * from sys.views where name = 'Clubs'))
	drop view Clubs;
go

create view Clubs as 
  select * from Clubs_Tbl
go

if (exists(select * from sys.views where name = 'Courts'))
	drop view Courts;
go

create view Courts as 
  select * from Courts_Tbl where Deleted = 0
go

if (exists(select * from sys.views where name = 'Courts_v'))
	drop view Courts_v;
go

create view Courts_v as 
  select c.Id, c.Name, c.ClubId, k.ShortName Club, c.CourtGroup, c.Active, c.CourtType 
  from Courts_Tbl c 
  join Clubs k on c.ClubId = k.Id 
  where c.Deleted = 0
go

if (exists(select * from sys.views where name = 'Users'))
	drop view Users;
go

create view Users as 
  select * from Users_Tbl where Deleted = 0
go

