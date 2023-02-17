--Ω®ø‚
IF DB_ID('OutpatientDemo')IS NOT NULL 
   DROP DATABASE OutpatientDemo;
CREATE DATABASE OutpatientDemo
ON	(NAME='DataFile_1',FILENAME='D:\EduJW\OutpatientDemoDataFile_1.mdf')
LOG ON	(NAME='LogFile_1',FILENAME='D:\EduJW\OutpatientDemoLogFile_1.ldf');

USE OutpatientDemo
IF OBJECT_ID('tb_User')IS NOT NULL	
	DROP TABLE tb_User;
	GO
	CREATE TABLE tb_User
(
    No
		VARCHAR(18)
		NOT NULL
		PRIMARY KEY,
	Password 
		VARBINARY(128) 
		NOT NULL,
	Name 
		VARCHAR(10)
		NOT NULL,
	Gender 
		CHAR(2)
		NOT NULL,
	Phone 
		VARCHAR(20)
		NOT NULL,
	Birthday
		DATE
		NULL,
	Photo
		VARBINARY(MAX)
		NULL,
	Balance
		DECIMAL(18,0)
		DEFAULT '0'
		NOT NULL
)

INSERT dbo.tb_User
(
    No,
    Password,
    Name,
    Gender,
    Phone,
	Birthday
)
VALUES
(   '3210707001',   -- ID - char(18)
    HASHBYTES('MD5','1'), -- Password - varbinary(128)
    'ÃÔΩ‹∫Ï',   -- Name - varchar(10)
    '≈Æ',   -- Gender - char(2)
    '18120795092',    -- Phone - varchar(20)
    '2002-06-29'
	),
('3190707015',HASHBYTES('MD5','1'),'πŸœÈΩ‹','ƒ–','18120795092','2002-11-29'),
('3190707002',HASHBYTES('MD5','1'),'¡ı¿º' , '≈Æ','18120795092','2000-4-28'),
('3190707003',HASHBYTES('MD5','1'),'Œ‚’˘”Ó','ƒ–','18120795092','2001-4-1'),
('3190707004',HASHBYTES('MD5','1'),'¡Œ¿ˆ’‰','≈Æ','18120795092','1999-8-25')
