CREATE DATABASE LabWork5;
GO

USE LabWork5;
GO

CREATE TABLE DataRab(
    ID_DataRab INT PRIMARY KEY IDENTITY(1,1),
    LoginRab VARCHAR(25) UNIQUE NOT NULL,
    PasswordRab VARCHAR(15) NOT NULL
);
GO

INSERT INTO DataRab(LoginRab, PasswordRab)
VALUES
	('admin','admin'),
	('cassir','cassir'),
	('zxcVoin','zxcVoin'),
	('Ghoul','Ghoul228'),
	('DOKVA','Ggwp1337')
GO

SELECT DataRab.LoginRab, DataRab.PasswordRab FROM DataRab;

CREATE TABLE Dolznosti(
    ID_Dolznosti INT PRIMARY KEY IDENTITY(1,1),
    NameDolznosti VARCHAR(20) UNIQUE NOT NULL,
    ScheduleWork VARCHAR(3) NOT NULL,
	ZP DECIMAL(10,2) NOT NULL
);
GO

INSERT INTO Dolznosti(NameDolznosti, ScheduleWork, ZP)
VALUES
	('Администратор','5/2', 75000.00),
	('Сортировщик','2/2', 50000.00),
	('Уборщик','5/2', 45000.00),
	('Консультант','5/2', 40000.50),
	('Витринист','3/4', 42000.20)
GO

CREATE TABLE Rabotniki(
    ID_Rabotnik INT PRIMARY KEY IDENTITY(1,1),
    SurnameRab VARCHAR(20) NOT NULL,
	NameRab VARCHAR(20) NOT NULL,
	MiddleNameRab VARCHAR(20),
	Dolznosti_ID INT NOT NULL,
	DataRab_ID INT UNIQUE NOT NULL,
	FOREIGN KEY (Dolznosti_ID) REFERENCES Dolznosti(ID_Dolznosti),
	FOREIGN KEY (DataRab_ID) REFERENCES DataRab(ID_DataRab)
);
GO

INSERT INTO Rabotniki(SurnameRab, NameRab, MiddleNameRab, Dolznosti_ID, DataRab_ID)
VALUES
	('Соколов','Владислав', 'Сергеевич', 1, 5),
	('Парамонова', 'Елизавета', 'Михайловна', 4, 1),
	('Воробьёв', 'Михаил', 'Олегович', 2, 2),
	('Артамонова', 'Татьяна', 'Дмитриевна', 3, 4),
	('Скорогудаева', 'София', 'Алексеевна', 5, 3)
GO

CREATE TABLE DateC(
    ID_DateC INT PRIMARY KEY IDENTITY(1,1),
    LoginC VARCHAR(25) UNIQUE NOT NULL,
    PasswordC VARCHAR(15) NOT NULL
);
GO

INSERT INTO DateC(LoginC, PasswordC)
VALUES
	('Seryak','Seryak228'),
	('Arthas','Velichaishi'),
	('Sollist','Sollist1'),
	('Bebrou','Bebrou123'),
	('VoinZ','Z14ET')
GO

CREATE TABLE Clients(
    ID_Client INT PRIMARY KEY IDENTITY(1,1),
    SurnameC VARCHAR(20) NOT NULL,
	NameC VARCHAR(20) NOT NULL,
	MiddleNameC VARCHAR(20),
	MailC VARCHAR(35) NOT NULL,
	DateC_ID INT UNIQUE NOT NULL,
	FOREIGN KEY (DateC_ID) REFERENCES DateC(ID_DateC)
);
GO

INSERT INTO Clients(SurnameC, NameC, MiddleNameC, MailC, DateC_ID)
VALUES
	('Серяк','Даниил', 'Владимирович', 'seryak@mail.ru', 1),
	('Самарский', 'Александр', 'Владленович', 'samara@gmail.com', 4),
	('Цаль', 'Виталий', NULL, 'VIKA@gmail.com', 2),
	('Путин', 'Владимир', 'Владимирович', 'VVP@gmail.com', 5),
	('Гацкан', 'Максим', 'Николаевич', 'Gachkan@mail.ru', 3)
GO

CREATE TABLE Cheques(
    ID_Cheque INT PRIMARY KEY IDENTITY(1,1),
    PriceCheq DECIMAL(6,2) NOT NULL,
	DateCheq VARCHAR(12) NOT NULL
);
GO

INSERT INTO Cheques(PriceCheq, DateCheq)
VALUES
	(3000.00, '25.02.2024'),
	(1500.00, '21.03.2024'),
	(500.00, '11.01.2024'),
	(1000.00, '25.02.2024'),
	(1250.00, '27.04.2024')
GO

CREATE TABLE Zhanres(
    ID_Zhanre INT PRIMARY KEY IDENTITY(1,1),
    NameZhanre VARCHAR(45) UNIQUE NOT NULL,
	DescriptionZhanre TEXT
);
GO

INSERT INTO Zhanres(NameZhanre, DescriptionZhanre)
VALUES
	('Экшен', 'Они сосредоточены вокруг игрока, который контролирует большую часть действия'),
	('Шутеры', 'Игроки используют оружие дальнего боя для участия в боевых действиях'),
	('Платформеры', 'Игровой процесс в основном сосредоточен на прыжках и лазании'),
	('Файтинги', 'Сосредоточены на боях на ближней дистанции'),
	('Приключенческие', 'Игровой процесс без рефлекторных испытаний и экшена')
GO

CREATE TABLE Games(
    ID_Game INT PRIMARY KEY IDENTITY(1,1),
    NameGame VARCHAR(25) NOT NULL,
	PriceGame DECIMAL(5,2) NOT NULL,
	Zhanre_ID INT NOT NULL,
	FOREIGN KEY (Zhanre_ID) REFERENCES Zhanres(ID_Zhanre)
);
GO

INSERT INTO Games(NameGame, PriceGame, Zhanre_ID)
VALUES
	('Valorant', 500.00, 2),
	('Super Mario Bros.', 250.00, 3),
	('Mortal Kombat 11', 500.00, 4),
	('Uncharted 4', 500.00, 1),
	('Mafia 2', 250.00, 5)
GO

CREATE TABLE Stock(
    ID_Stock INT PRIMARY KEY IDENTITY(1,1),
    NameStock VARCHAR(50) UNIQUE NOT NULL,
	AddressStock VARCHAR(70) NOT NULL
);
GO

INSERT INTO Stock(NameStock, AddressStock)
VALUES
	('Вереск', 'Улица Пушкина, дом Колотушкина'),
	('Zancors Entertainment', 'Нахимовский проспект, д. 21'),
	('Riot Games', 'Нежинская улица, д. 228'),
	('Ubisoft', 'Москва, ул. Давыдовская, з. 15'),
	('Экесбокес сэрес экес', 'Одинцовский район, Школьный посёлок, з. 15')
GO

CREATE TABLE Shop(
    ID_Shop INT PRIMARY KEY IDENTITY(1,1),
    NameShop VARCHAR(50) UNIQUE NOT NULL
);
GO

INSERT INTO Shop(NameShop)
VALUES
	('GameStop Shop'),
	('IGM Shop'),
	('DOKVAs Shop '),
	('Tarkov Shop'),
	('BattleStateGames Shop')
GO

CREATE TABLE SootGS(
    ID_SootGS INT PRIMARY KEY IDENTITY(1,1),
	Game_ID INT NOT NULL,
	Stock_ID INT NOT NULL,
	Shop_ID INT NOT NULL,
	FOREIGN KEY (Game_ID) REFERENCES Games(ID_Game),
	FOREIGN KEY (Stock_ID) REFERENCES Stock(ID_Stock),
	FOREIGN KEY (Shop_ID) REFERENCES Shop(ID_Shop),
);
GO


INSERT INTO SootGS(Game_ID, Stock_ID, Shop_ID)
VALUES
	(1, 2, 3),
	(2, 1, 5),
	(3, 5, 4),
	(4, 3, 1),
	(5, 4, 2)
GO

CREATE TABLE Stat(
    ID_Status INT PRIMARY KEY IDENTITY(1,1),
	NameStatus VARCHAR(30) UNIQUE NOT NULL
);
GO

INSERT INTO Stat(NameStatus)
VALUES
	('Активный'),
	('Выполнен'),
	('Задерживается'),
	('Потерялся'),
	('Отменён')
GO

CREATE TABLE Orders(
    ID_Order INT PRIMARY KEY IDENTITY(1,1),
	DateO VARCHAR(12) NOT NULL,
	Client_ID INT NOT NULL,
	Cheque_ID INT NOT NULL,
	Status_ID INT NOT NULL,
	Rabotnik_ID INT NOT NULL,
	SootGS_ID INT NOT NULL,
	FOREIGN KEY (Client_ID) REFERENCES Clients(ID_Client),
	FOREIGN KEY (Cheque_ID) REFERENCES Cheques(ID_Cheque),
	FOREIGN KEY (Status_ID) REFERENCES Stat(ID_Status),
	FOREIGN KEY (Rabotnik_ID) REFERENCES Rabotniki(ID_Rabotnik),
	FOREIGN KEY (SootGS_ID) REFERENCES SootGS(ID_SootGS)
);
GO

INSERT INTO Orders(DateO, Client_ID, Cheque_ID, Status_ID, Rabotnik_ID, SootGS_ID)
VALUES
	('25.02.2024', 1, 2, 5, 1, 5),
	('27.02.2024', 2, 5, 1, 5, 3),
	('01.03.2024', 3, 3, 3, 2, 1),
	('30.01.2024', 4, 1, 2, 4, 2),
	('15.03.2024', 5, 4, 4, 3, 4)
GO

CREATE PROCEDURE Backup_Delat
AS
BEGIN
	DECLARE @BackupPath VARCHAR(500);
	SET @BackupPath = 'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\PW5' + '.bak';

	BACKUP DATABASE GamerShop TO DISK = @BackupPath;
END;
GO
