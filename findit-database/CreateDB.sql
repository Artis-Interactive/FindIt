-- From master context:
use master
-- Create new db:
create database FindIt
-- switch context:
use FindIt
-- create Users table:
create table Users(
	UserID				uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	LegalID				varchar(15)			NOT NULL UNIQUE,
	Email				varchar(50)			NOT NULL UNIQUE,
	[Name]				varchar(50)			NOT NULL,	
    LastNames			varchar(100)		NOT NULL,
	PasswordHash		varchar(100)		NOT NULL,
	PhoneNumber			varchar(8)			NOT NULL,
	BirthDate			date				NOT NULL,
	UserType			varchar(3)			NOT NULL DEFAULT 'CON',
	AccountState		varchar(6)			NOT NULL DEFAULT 'NotVER',

	-- Constraints:
	CONSTRAINT Check_UserType CHECK (UserType IN ('CON', 'EMP', 'ADM')),
	CONSTRAINT Check_AccountState CHECK (AccountState IN ('NotVer', 'ACT', 'BAN')),
);

-- Create Cards table:
create table Cards(
	CardID				uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	CardNumber			varchar(20)			NOT NULL UNIQUE,
	NameOnCard			varchar(100)		NOT NULL,	
	ExpirationDate		date				NOT NULL,
);

-- Create UserCards table:
create table UserCards(
	CardID				uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Cards(CardID),
	UserID				uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
	-- Primary key:
	CONSTRAINT PK_UserCards PRIMARY KEY (CardID, UserID),
);

-- Create Companies table:
create table Companies(
	CompanyID		uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	Name			varchar(150)		NOT NULL UNIQUE,
	LegalID			varchar(15)			NOT NULL UNIQUE,
	Type			varchar(8)			CHECK (Type IN ('physical', 'legal')),
	Description		varchar(1000),		
	Email			varchar(50),
	PhoneNumber		int,
	Logo			varchar(250),
	HeroImage		varchar(250)
)

-- Create User/Company table:
create table UsersCompany(
	UserID				uniqueidentifier	PRIMARY KEY FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
	CompanyID			uniqueidentifier	FOREIGN KEY REFERENCES Companies(CompanyID),	
	IsOwner				bit					NOT NULL,
)

-- Create Address table:
create table Address(
	AddressID			uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	UserID				uniqueidentifier	FOREIGN KEY REFERENCES Users(UserID),
	CompanyID			uniqueidentifier	FOREIGN KEY REFERENCES Companies(CompanyID),	
	Province			varchar(12)			NOT NULL,
	Canton				varchar(50)			NOT NULL,
	District			varchar(50)			NOT NULL,
	Details				varchar(1000)		NOT NULL,
	Coords				geography,
	-- Foreign keys
	CONSTRAINT FK_UserID FOREIGN KEY (UserID) REFERENCES Users (UserID) ON DELETE CASCADE
)

-- Create WorkingDays table:
create table WorkingDays(
	CompanyID		uniqueidentifier	FOREIGN KEY REFERENCES Companies(CompanyID),
	Day				varchar(9)			NOT NULL	CHECK (Day IN ('Lunes', 'Martes', 'Mi�rcoles', 'Jueves', 'Viernes', 'S�bado', 'Domingo')),
	StartTime		time				NOT NULL,
	EndTime			time				NOT NULL
)

-- Create Categories table:
create table Categories(
	CategoryID		uniqueidentifier	NOT NULL  PRIMARY KEY DEFAULT NewID(),
	CategoryName	varchar(20)			NOT NULL
)

-- Create Products table:
create table Products(
	ProductID		uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	CategoryID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Categories(CategoryID),
	CompanyID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Companies(CompanyID),
	ProductName		varchar(100) 		NOT NULL,
	Description		varchar(1000)		NOT NULL,
	Image			varchar(250)		NOT NULL,
	Price 			money 				NOT NULL
)

-- Create NonPerishableProducts table:
create table NonPerishableProducts(
	ProductID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Amount 			int 				NOT NULL
)

-- Create PerishableProducts table:
create table PerishableProducts(
	ProductID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Lifespan 			int 				NOT NULL,
	ProductDay		varchar(9)  NOT NULL CHECK (Day IN ('Lunes', 'Martes', 'Mi�rcoles', 'Jueves', 'Viernes', 'S�bado', 'Domingo'))
)

-- Create ProductionBatch table:
create table ProductionBatch(
	ProductID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Amount 			int 				NOT NULL,
	OrderDeadline	time				NOT NULL,
	ProductionDate	date				NOT NULL
)