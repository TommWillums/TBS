--=============================================================================
-- 01_TBS_Create_Schema.sql
--=============================================================================
use TBS
go

if (exists(select * from sys.tables where name = 'Clubs'))
	drop table Clubs;

if (exists(select * from sys.tables where name = 'Users'))
	drop table Users;
go

create table Clubs (
	Id				int			 not null identity primary key,
	Name			varchar(50)  not null,
	Contact			varchar(50)	 not null,
	Address			varchar(100) not null,
	CourtCount		int			 not null,
	Subscription	varchar(20)	 null,
	AutoRenewal		bit			 not null default 1,
	NextRenewalDate	DateTime2	 null,
	Price			money		 not null default 0.0,
	Created			DateTime2	 not null default GetDate()
)

create table Users (
	Id			int			not null identity primary key,
	Name		varchar(50)	not null
)

