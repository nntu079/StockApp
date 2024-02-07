CREATE TABLE [dbo].[Users] (
    [UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Username] VARCHAR(50) UNIQUE NOT NULL,
    [Password] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(50) UNIQUE NOT NULL,
    [FirstName] VARCHAR(50) NOT NULL,
    [LastName] VARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME DEFAULT GETDATE() NOT NULL
);


CREATE TABLE [dbo].[Watchlists] (
    [WatchlistId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME DEFAULT GETDATE() NOT NULL,

    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users]([UserId])
);


CREATE TABLE [dbo].[Stocks] (
    [StockId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Symbol] VARCHAR(10) UNIQUE NOT NULL,
    [Name] VARCHAR(50) NOT NULL,
    [Price] DECIMAL(18, 2) NOT NULL,
    [Change] DECIMAL(18, 2) NOT NULL,
    [Volume] INT NOT NULL,
    [Sector] VARCHAR(50) NOT NULL,
    [Industry] VARCHAR(50) NOT NULL,
    [CreatedAt] DATETIME DEFAULT GETDATE() NOT NULL
);


CREATE TABLE [dbo].[Industries] (
    [IndustryId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT NEWID(),
    [Name] VARCHAR(50) UNIQUE NOT NULL,
    [Description] VARCHAR(255) NOT NULL
);

CREATE TABLE [dbo].[WatchlistStocks] (
    [WatchlistId] UNIQUEIDENTIFIER NOT NULL,
    [StockId] UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY ([WatchlistId]) REFERENCES [dbo].[Watchlists]([WatchlistId]),
    FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stocks]([StockId])
);

CREATE TABLE [dbo].[IndustryStocks] (
    [IndustryId] UNIQUEIDENTIFIER NOT NULL,
    [StockId] UNIQUEIDENTIFIER NOT NULL,

    FOREIGN KEY ([IndustryId]) REFERENCES [dbo].[Industries]([IndustryId]),
    FOREIGN KEY ([StockId]) REFERENCES [dbo].[Stocks]([StockId])
);

INSERT INTO [dbo].[Users] (Username, Password, Email, FirstName, LastName)
VALUES
    ('user1', 'password1', 'user1@example.com', 'John', 'Doe'),
    ('user2', 'password2', 'user2@example.com', 'Jane', 'Doe');


INSERT INTO [dbo].[Watchlists] (UserId, Name)
VALUES
    ('5C43C454-052E-48C6-87B0-8713F95A976D', 'My Watchlist'),
    ('2B36CE30-54F3-46D0-960B-9C1635EAE4F7', 'Favorites');


INSERT INTO [dbo].[Stocks] (Symbol, Name, Price, Change, Volume, Sector, Industry)
VALUES
    ('AAPL', 'Apple Inc.', 150.00, 1.00, 1000000, 'Technology', 'Information Technology'),
    ('MSFT', 'Microsoft Corporation', 200.00, 2.00, 2000000, 'Technology', 'Software'),
    ('GOOGL', 'Alphabet Inc.', 250.00, 3.00, 3000000, 'Technology', 'Internet Services'),
    ('AMZN', 'Amazon.com, Inc.', 300.00, 4.00, 4000000, 'Retail', 'E-commerce'),
    ('TSLA', 'Tesla, Inc.', 350.00, 5.00, 5000000, 'Automotive', 'Electric Vehicles');


INSERT INTO [dbo].[Industries] (Name, Description)
VALUES
    ('Technology', 'Ngành công nghệ'),
    ('Finance', 'Ngành tài chính'),
    ('Healthcare', 'Ngành chăm sóc sức khỏe'),
    ('Retail', 'Ngành bán lẻ'),
    ('Automotive', 'Ngành công nghiệp ô tô');

INSERT INTO [dbo].[WatchlistStocks] (WatchlistId, StockId)
VALUES
    ('21E25021-1CB6-469A-B382-CB75A6B85B73', '61466105-9A96-4736-B38F-1B78F146EE8C'),
    ('21E25021-1CB6-469A-B382-CB75A6B85B73', '68D5AC4F-0B8D-4DE3-8442-21784BDFF5CD'),
    ('8330AD40-6CC6-412C-9755-D05ABB09FC26', 'EE85AAED-355B-440A-8487-2A90D1AD528E'),
    ('8330AD40-6CC6-412C-9755-D05ABB09FC26', '108EA972-B706-4D76-8BBE-9BF08B529995');

INSERT INTO [dbo].[IndustryStocks] (IndustryId, StockId)
VALUES
    ('70526AB6-315D-4EFB-8364-118E921E4D92', 'stock1'),
    ('70526AB6-315D-4EFB-8364-118E921E4D92', 'stock2'),
    ('5D07A6F4-330D-42DC-81D8-59269E80DE46', 'stock3'),
    ('5D07A6F4-330D-42DC-81D8-59269E80DE46', 'stock4'),
    ('1229A144-889D-47C0-83AC-5F1570A68BAA', 'stock5');