
CREATE DATABASE KoiFishAdvertisementDB2;
GO

USE KoiFishAdvertisementDB2;
GO


CREATE TABLE Role (
    RoleID INT PRIMARY KEY IDENTITY(1,1),
    RoleName NVARCHAR(50) NOT NULL
);


CREATE TABLE Account (
    AccountID INT PRIMARY KEY IDENTITY(1,1),
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    RoleID INT NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (RoleID) REFERENCES Role(RoleID)
);


CREATE TABLE FengShuiElement (
    ElementID INT PRIMARY KEY IDENTITY(1,1),
    ElementName NVARCHAR(50) NOT NULL,
    Description NVARCHAR(255) NULL
);


CREATE TABLE KoiFish (
    KoiFishID INT PRIMARY KEY IDENTITY(1,1),
    KoiFishName NVARCHAR(50) NOT NULL,
    KoiFishColor NVARCHAR(50) NOT NULL,
    KoiFishSize DECIMAL(5,2) NOT NULL, 
    KoiFishAge INT NOT NULL,
    FengShuiElementID INT NULL,
    SymbolicMeaning NVARCHAR(255) NULL,
    EnergyType NVARCHAR(50) NULL,
    FavorableNumber INT NULL,
    Origin NVARCHAR(100) NULL,
    Price DECIMAL(18,2) NOT NULL, 
    FOREIGN KEY (FengShuiElementID) REFERENCES FengShuiElement(ElementID)
);


CREATE TABLE Advertisement (
    AdvertisementID INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(100) NOT NULL,
    Description NVARCHAR(1000) NOT NULL,
    KoiFishID INT NOT NULL,
    PostedBy INT NOT NULL, -- AccountID
	Verified BIT DEFAULT 0,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    UpdatedAt DATETIME NULL,
    FOREIGN KEY (KoiFishID) REFERENCES KoiFish(KoiFishID),
    FOREIGN KEY (PostedBy) REFERENCES Account(AccountID)
);

-- Insert data into the Role table
INSERT INTO Role (RoleName) VALUES
('Admin'),
('User');

-- Insert data into the Account table
INSERT INTO Account (Username, PasswordHash, Email, RoleID) VALUES
('admin', 'doantri123', 'admin@example.com', 1),
('minhtri', 'hashed_password_2', 'user2@example.com', 2),
('minhduc', 'hashed_password_1', 'user4@example.com', 1),
('tinhdx', 'hashed_password_2', 'user5@example.com', 2);

-- Insert data into the FengShuiElement table
INSERT INTO FengShuiElement (ElementName, Description) VALUES
('Metal', 'Represents metal, known for its resilience and strength'),
('Wood', 'Represents trees, symbolizing life and growth'),
('Water', 'Represents water, with a soft and flowing nature'),
('Fire', 'Represents fire, symbolizing energy and passion'),
('Earth', 'Represents earth, known for its stability and durability');

-- Insert data into the KoiFish table
INSERT INTO KoiFish (KoiFishName, KoiFishColor, KoiFishSize, KoiFishAge, FengShuiElementID, SymbolicMeaning, EnergyType, FavorableNumber, Origin, Price) VALUES
('Koi Sanke', 'Red and White', 50.5, 3, 1, 'Symbolizes love and courage', 'Positive', 8, 'Japan', 1500.00),
('Koi Showa', 'Black, Red, and White', 45.0, 2, 3, 'Represents perseverance and strength', 'Dynamic', 5, 'Japan', 1800.00),
('Koi Kohaku', 'White and Red', 60.0, 4, 4, 'Brings harmony and balance', 'Energetic', 7, 'Japan', 2000.00);

-- Insert data into the Advertisement table
INSERT INTO Advertisement (Title, Description, KoiFishID, PostedBy, Verified) VALUES
('Koi Sanke for Sale', 'Beautiful and healthy Koi Sanke, ideal for large ponds.', 1, 1, 0),
('Koi Showa at a Great Price', 'Beautifully colored Koi Showa, perfect for ornamental purposes.', 2, 2, 0),
('Koi Kohaku for Sale', 'Large Koi Kohaku, strong and healthy, available at a discounted price.', 3, 1, 0);

