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
	PasswordHash		varchar(20)			NOT NULL,
	PhoneNumber			varchar(8)			NOT NULL,
	BirthDate			date				NOT NULL,
	UserType			varchar(3)			NOT NULL,
	IsOwner				bit,
	-- Constraints:
	CONSTRAINT Check_UserType CHECK (UserType IN ('CON', 'EMP', 'ADM')),
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
	CardID				uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Cards(CardID) ON DELETE CASCADE,
	UserID				uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Users(UserID) ON DELETE CASCADE,
	-- Primary key:
	CONSTRAINT PK_UserCards PRIMARY KEY (CardID, UserID),
);
