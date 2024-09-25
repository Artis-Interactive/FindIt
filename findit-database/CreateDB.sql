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
	IsOwner				bit					NOT NULL DEFAULT 0,
	IsVerified			bit					NOT NULL DEFAULT 0,
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

-- Create Products table:
create table Products(
	ProductID			uniqueidentifier	NOT NULL PRIMARY KEY DEFAULT NewID(),
	CategoryID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Categories(CategoryID),
	CompanyID			uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Companies(CompanyID),
	ProductName		varchar(100) 			NOT NULL,
	Description		varchar(1000)			NOT NULL,
	Image					varchar(250)			NOT NULL,
	Price 				int 							NOT NULL
)

-- Create NonPerishableProducts table:
create table NonPerishableProducts(
	ProductID		uniqueidentifier	NOT NULL FOREIGN KEY REFERENCES Products(ProductID) ON DELETE CASCADE,
	Amount 			int 							NOT NULL
)
