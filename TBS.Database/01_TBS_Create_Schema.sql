--=============================================================================
-- 01_TBS_Create_Schema.sql
--=============================================================================
use TBS
go

if (exists(select * from sys.tables where name = 'Clubs'))
	drop table Clubs;

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

if (exists(select * from sys.tables where name = 'Users'))
	drop table Users;

create table Users (
	Id			int			not null identity primary key,
	Name		varchar(50)	not null
)
go