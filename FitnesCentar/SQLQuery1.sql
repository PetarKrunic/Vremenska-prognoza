--CREATE TABLE [dbo].[Korisnici]
--(
--	[JMBG] Int NOT NULL IDENTITY(1,1) PRIMARY KEY,
--	[Ime] VarChar(20) NOT NULL,
--	[Prezime] VarChar(20) NOT NULL,
--	[TipKorisnika] VarChar(20) NOT NULL,
--	[Email] VarChar(20) NOT NULL,
--	[Aktivan] BIT NOT NULL,
--	[Pol] VarChar(20) NOT NULL,
--	[Adresa] VarChar(20) NOT NULL,
--	[Lozinka] VarChar(20) NOT NULL
--)
--CREATE TABLE [dbo].[Instruktori]
--(
--	[Id] INT NOT NULL PRIMARY KEY,
--			CONSTRAINT FK_Korisnik_Instruktor_Id
--			FOREIGN KEY (ID) REFERENCES dbo.Korisnici(ID)
--)

--CREATE TABLE [dbo].[Polaznici]
--(
--	[Id] INT NOT NULL PRIMARY KEY,
--			CONSTRAINT FK_Korisnik_Polaznik_Id
--			FOREIGN KEY (ID) REFERENCES dbo.Korisnici(ID)
--)

--CREATE TABLE [dbo].[Trening]
--(
--	[Id] Int NOT NULL IDENTITY(1,1) PRIMARY KEY,
--	[Datum] VarChar(20) NOT NULL,
--	[VremeTreninga] VarChar(20) NOT NULL,
--	[TrajanjeTreninga] Int NOT NULL,
--	[Status] VarChar(40) NOT NULL,
--	[Instruktor] VarChar(20) NOT NULL, 
--	[Polaznik] Int, 
--	[Aktivan] BIT NOT NULL,
		
--)

