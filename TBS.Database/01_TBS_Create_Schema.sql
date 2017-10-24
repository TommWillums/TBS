--=============================================================================
-- 01_TBS_Create_Schema.sql
--=============================================================================
use TBS
go

if (exists(select * from sys.tables where name = 'Users'))
	drop table Users;

if (exists(select * from sys.tables where name = 'Courts'))
	drop table Courts;

if (exists(select * from sys.tables where name = 'Clubs'))
	drop table Clubs;

/* Club */

create table Clubs (
	Id				int			 not null identity primary key,
	ClubName		varchar(50)  not null,
	ShortName		varchar(10)  not null,
	Contact			varchar(50)	 not null,
	Address			varchar(100) null,
	CourtCount		int			 not null default 0,
	Subscription	varchar(20)	 null,
	Price			money		 not null default 0.0,
	AutoRenewal		bit			 not null default 0,
	NextRenewalDate	DateTime2	 null,
	Created			DateTime2	 not null default GetDate(),
)
create unique index ix_ShortName on Clubs (ShortName)
go

/* Courts */

create table Courts (
	Id				int			not null identity primary key,
	Name			varchar(20) not null,       
    ClubId			int			not null references Clubs(Id),         
    CourtGroup		int			not null default 0,    
    Active			bit			not null default 1,
    CourtType		varchar(20) null,       
    Location		varchar(20) null,
	MapCoordinates	geography	null,
    VisibleFor		varchar(50)	null, 
	Created			DateTime2	not null default GetDate(),
)
go

/* Users */

create table Users (
	Id			int			not null identity primary key,
	Name		varchar(50)	not null
)
go

/* VIEWS */

if (exists(select * from sys.views where name = 'Courts_v'))
	drop view Courts_v;
go

create view Courts_v as 
  select c.Id, c.Name, c.ClubId, k.ShortName Club, c.CourtGroup, c.Active, c.CourtType 
  from Courts c join Clubs k on c.ClubId = k.Id 
go

