--����
Use master
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
		CHAR(10)
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
	Email
		VARCHAR(50)
		NOT NULL,
	Photo
		VARCHAR(200)
		NULL,
	Balance
		DECIMAL(18,0)
		DEFAULT '0'
		NOT NULL,
	ViolationRecord
		bit,
		Betitled
		DATETIME,
	Addres
		TEXT,
	FailCount
	INT
)

INSERT tb_User
(No,Password,Name,Gender,Phone,Email,Birthday,Addres,ViolationRecord,FailCount)
VALUES
(   '3210707001',   -- ID - char(18)
    HASHBYTES('MD5','1'), -- Password - varbinary(128)
    '��ܺ�',   -- Name - varchar(10)
    'Ů',   -- Gender - char(2)
    '18120795092',    -- Phone - varchar(20)
	'319665159@qq.com',
    '2002-06-29'
	,'����ʡ�������������Ͻ�������·һ�Ÿ�����ҽҩ��ѧ',0,0),
('3210707015',HASHBYTES('MD5','1'),'�����','��','18120795092','319665159@qq.com','2002-11-29','����ʡ�������������Ͻ�������·һ�Ÿ�����ҽҩ��ѧ',0,0),
('3210707002',HASHBYTES('MD5','1'),'����' , 'Ů','18120795092','319665159@qq.com','2003-6-28','����ʡ�������������Ͻ�������·һ�Ÿ�����ҽҩ��ѧ',0,0),
('3210707003',HASHBYTES('MD5','1'),'������','��','18120795092','319665159@qq.com','2004-1-23','����ʡ�������������Ͻ�������·һ�Ÿ�����ҽҩ��ѧ',0,0),
('3210707004',HASHBYTES('MD5','1'),'������','Ů','18120795092','319665159@qq.com','2002-7-14','����ʡ�������������Ͻ�������·һ�Ÿ�����ҽҩ��ѧ',0,0),
('3210707005',HASHBYTES('MD5','1'),'������','Ů','18120795092','319665159@qq.com','2002-8-25','����ʡ�������������Ͻ�������·һ�Ÿ�����ҽҩ��ѧ',0,0)

--����
IF OBJECT_ID('tb_Keshi') IS NOT NULL
	DROP TABLE tb_Keshi;
	GO
	CREATE TABLE tb_Keshi
	(
		No 
		CHAR(4)
			NOT NULL
				PRIMARY KEY,
	Name 
		VARCHAR(100)
			NOT NULL,

	)
--�����������
INSERT INTO tb_Keshi
	(No,Name)VALUES
	('1001','��ҽ��'),
	('1002','�Բ���'),
	('1003','�β���'),
	('1004','��Ѫ�ܿ�'),
	('1005','Ƣθ����'),
	('1006','������(��Ѫ͸��)'),
	('1007','�ڷ��ڿ�'),
	('1008','������'),
	('1009','ѪҺ��'),
	('1010','�����'),
	('1011','��֢ҽѧ��'),
	('1012','��һ�ƣ�����ƣ�'),
	('1013','����ƣ�������ƣ�'),
	('1014','�س���'),
	('1015','�����ʺ��'),
	('1016','����һ��'),
	('1017','�ۿ�'),
	('1018','��ǻ��'),
	('1019','Ƥ����'),
	('1020','����һ��'),
	('1021','��Ŀ�'),
	('1022','��ҽ������'),
	('1023','����'),
	('1024','����'),
	('1025','����')

--ְ�Ʊ�
IF OBJECT_ID('tb_Pro_title') IS NOT NULL
	DROP TABLE tb_Pro_title;
	GO
	CREATE TABLE tb_Pro_title
	(	No 
		VARCHAR(3)
			NOT NULL
				PRIMARY KEY,
	Name 
		VARCHAR(100)
			NOT NULL,

	)
--ְ���������
INSERT INTO tb_Pro_title(No,Name)VALUES
	('1','ҽʿ '),
	('2','ҽʦ  '),
	('3','����ҽʦ  '),
	('4','������ҽʦ '),
	('5','����ҽʦ ')
--ҽ����
IF OBJECT_ID('tb_Doctor')IS NOT NULL	
	DROP TABLE tb_Doctor;
	GO
	CREATE TABLE tb_Doctor
(
    No
		CHAR(10)
		NOT NULL
			CONSTRAINT pk_Doctor_No
				PRIMARY KEY(No),
			CONSTRAINT ck_Doctor_No
			CHECK(No LIKE'[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	Password 
		VARBINARY(128) 
		NOT NULL,
	Pinyin
		VARCHAR(509)
		NOT NULL,
	Name 
		VARCHAR(10)
		NOT NULL,

	Gender 
		Bit
		NOT NULL,
	Introduction
		TEXT
		NULL,
	Phone 
		VARCHAR(20)
		NOT NULL,
	Birthday
		DATE
		NULL,
	Email
		VARCHAR(50)
		NOT NULL,
	Photo
		VARCHAR(200)
		NULL,
	KeshiNo
		CHAR(4)
			NOT NULL
				--CONSTRAINT fk_Doctor_KeshiNo 
					FOREIGN KEY(KeshiNo) 
				REFERENCES tb_Keshi(No)
				--CONSTRAINT ck_Doctor_KeshiNo 
				--	CHECK(KeshiNo LIKE'[0-9][0-9][0-9][0-9]'),
	,ProtitleNo
		VARCHAR(3)
			NOT NULL
				CONSTRAINT fk_Doctor_ProtitleNo
					FOREIGN KEY(ProtitleNo) 
				REFERENCES tb_Pro_title(No),
	FailCount
	int
			
				
)

INSERT INTO tb_Doctor(No,Name,Pinyin,Introduction,Password,Gender,Phone,Birthday,Email,Photo,KeshiNo,ProtitleNo)VALUES
	('2230105001','�Ž�','dj','������ҽ�ڿƸ������Ѳ�����������ҩ��������,�����겡�о�����ж��ص����ƾ���....', HASHBYTES('MD5','1'), 0,'18000000001','1975-8-8','12345678@qq.com','images/1590397067132.jpg','1001','5'),
	('2230105002','������','cld','��Ҫ���������к���֪��֫���˶������ϰ������о�...',HASHBYTES('MD5','1'),0,'18000000002','1974-9-28','12345678@qq.com','images/1589965009089.jpg','1001','5'),
	('2230105003','��Ӷ�','lcd','�ó��ڷ��ڴ�л����������θ�����������Ӳ�����ҽ����...',HASHBYTES('MD5','1'),0,'18000000003','1976-8-18','12345678@qq.com','images/1589965200973.png','1001','5'),
	('2230105004','������','whm','���ι��ˡ����ˡ��ǲ�����׵����ͻ��֢������������...',HASHBYTES('MD5','1'),0,'18000000004','1978-3-18','12345678@qq.com','','1001','5'),
	('2230105005','��ϲ��','zxk','�ó�ʧ�ߡ�������ͷʹ��ͷ�Ρ���˥���������ڡ����������ԡ�θ�����ູ���������ڿơ��пơ����ơ�Ƥ������ҽ��...',HASHBYTES('MD5','1'),0,'18000000005','1974-2-23','12345678@qq.com','images/1590397559307.jpg','1001','5'),
	('2230105006','�ƿ�ɽ','hjs','�ó����������������������鷿�������¾��������󲡣���֭�ٻ�����֭ȱ�١��ǽ���������֢�������ٰ�������ҽҩ����...',HASHBYTES('MD5','1'),0,'18000000006','1975-3-24','12345678@qq.com','images/1586853295666.png','1001','5'),
	('2230105007','��ƻ','wp','���򲡡���Ѫѹ����֬��ճѪ֢��ʹ�硢��״�ټ������׼�������Ǵ���ӲƤ���ȼ������Ρ�...',HASHBYTES('MD5','1'),  1,'18003450007','1964-8-8','12345678@qq.com','','1001','5'),
	('2230105008','ʩ��','sh','�ó�����ҽ�ڿơ����ơ����Ƽ����ı�֤ʩ�Σ������ڸ�ð���ȡ����ԡ������ס�������θ���ס��������͸��ס�����ϵͳ...',HASHBYTES('MD5','1'),  1,'18004530006','1979-8-8','12345678@qq.com','','1001','5'),
	('2230105009','�½���','cjf','�ó�������������ҽҩ���������Լ�����ϵͳ������ή����θ�ס����Ը��׵Ȱ�ǰ������ת�������Ա��ס�ݡ���С����...',HASHBYTES('MD5','1'),0,'18003450006','1969-8-8','12345678@qq.com','','1001','5'),
	('2230105010','��ˮ��','wss','�ó���ҩ���������з硢���򲡡�ʧ�ߡ�ͷʹ����������׵���������༲��������ʹ֤��ʹ�硢��ʪ�༲�������Ƥ�...',HASHBYTES('MD5','1'),0,'18340000006','1980-8-8','12345678@qq.com','','1001','5'),
	('2230105011','��ͯ','wt','�ó�������������·��Ⱦ����θ�����β���ˮ�ס��¾������������������ȡ�����Կ��ԡ�ͷʹ���ļ�ѣ�Ρ����ݡ����...',HASHBYTES('MD5','1'),  0,'18000000045','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105012','³���','lyh','�ó�������ҽ������ƣ���״�١��ε�����θ��������ҽ���Ƹ�ð�����ԡ�ϰ���Ա��ء�����֢��ʧ�ߣ���ƫͷʹ����Ѫѹ...',HASHBYTES('MD5','1'),0,'18000457006','1976-8-8','12345678@qq.com','','1001','5'),
	('2230105013','�¹���','cgm','�ó���׵��������ʹ�������ס����ʪ�Թؽ��ס�ǿֱ�Լ����ס�ʹ�����ҽ���˿Ƴ��������෢��������...',HASHBYTES('MD5','1'),0,'18078900006','1978-8-8','12345678@qq.com','','1001','5'),
	('2230105014','���','ln','�ó�ʧ�ߡ����Ρ���������������������θ�ס�θ���񡢳�Ԥ���ۺ���������ϵͳ��������ҽ���ƣ��Լ������ס��ε���...',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105015','����','jl','�ó������¾��������²������󲡡��������ۺ�֢������ǽ���״̬���ƺ͵���...',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105016','֣�¶�','zye','����θ���������¾����������²���ʧ�ߡ�ͷ�Ρ���ð���ȴ������ס����ʪ������ڼ����������������ǽ�������ҽ...',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105017','����','ym','�ó�����������������θ�������Ρ�����������ð�����ԣ������¾�������ʹ�������������������ҩ�������Ƶ�...',HASHBYTES('MD5','1'),  1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105018','�ܽ���','zjh','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105019','���ٷ�','csf','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105020','������','lwn','��ҽ������������ϵͳ���������Ƽ�������л�ڷ��ڼ�������������������ҽ����...',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105021','Ф�ܼ�','xsj','�������������Ѫ�ܲ���Ƣθ�������겡�����Բ�����ҽ���ʵ���...',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105022','������','lyn','��Ѫѹ�����򲡼�����ϵͳ���������ƣ������ó��ڸβ�������ҽ������ơ�...',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2231101002','����ҫ','cky','���ζ�ͯ�Բ�����̱�����ϡ��Ագ����з��ƫ̱���������ȼ������������...',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1011','1'),
	('2231202001','������','cky','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1012','2'),
	('2231302001','Фս','xz','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1013','2'),
	('2231401001','��һ��','wyb;','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1014','1'),
	('2231501001','���׵�','whd','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1015','1'),
	('2231601001','��һͩ','lyt','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1016','1'),
	('2231703001','����','zl','',HASHBYTES('MD5','1'),  1,'18000000006','1950-8-8','12345678@qq.com','','1017','3'),
	('2231803001','������','lxl','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1018','3'),
	('2231901001','Ф����','xdw','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1019','1'),
	('2230104001','������','cyp','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','4'),
	('2230703001','������','kyy','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1007','3'),
	('2230203001','Ҷ�s�s','ytt','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1002','3'),
	('2230305001','������','ztt','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1003','5'),
	('2230403001','��н�','lcj','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1004','3'),
	('2230503001','��ҫ��','wyq','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1005','3'),
	('2230603001','������','lww','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1006','3'),
	('2230703002','������','cmh','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1007','3'),
	('2230803001','����','zt','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1008','3'),
	('2230903001','�ֿ���','lkq','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1009','3'),
	('2231003001','��ܿ��','lyh','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1010','3'),
	('2231103001','֣��','zy','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1011','3'),
	('2231202002','�ų�','dc','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1012','2'),
	('2231302002','�','yh','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1013','2'),
	('2231402002','�����','ygq','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1014','2'),
	('2231502002','����','ll','',HASHBYTES('MD5','1'),  1,'18000000006','1950-8-8','12345678@qq.com','','1015','2'),
	('2231602002','������','cww','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1016','2'),
	('2231702002','����','wy','',HASHBYTES('MD5','1')  ,0,'18000000006','1950-8-8','12345678@qq.com','','1017','2')

--ҩ��
IF OBJECT_ID('tb_Pharmacy')IS NOT NULL
	DROP TABLE tb_Pharmacy;
	GO
	CREATE TABLE tb_Pharmacy
	(
	No 
		CHAR(3)
			NOT NULL
				PRIMARY KEY,
	Name
		VARCHAR(100)
			NOT NULL
	)
INSERT INTO tb_Pharmacy(No,Name)VALUES
	('101','һ�Ųֿ�'),
	('102','��ҩ�ֿ�'),
	('103','Σ��Ʒ�ֿ�')

--ҩƷ����
IF OBJECT_ID('tb_Type')IS NOT NULL
	DROP TABLE tb_Type;
	GO
	CREATE TABLE tb_Type
	(
		No
		CHAR(4)
		CONSTRAINT pk_Type_No
			PRIMARY KEY(No),
			--CONSTRAINT ck_Type_No
			--CHECK(No LIKE '[0-9]0-9][0-9][0-9]'),
	Name
		VARCHAR(200)
			NOT NULL,
	)
INSERT INTO tb_Type(No,Name)VALUES
	('1001','����Ѫ����ҩ'),
	('1002','������ҩ'),
	('1003','�п���ҩ'),
	('1004','������ҩ'),
	('1005','�ڷ�����ҩ'),
	('1006','����ϵͳ��ҩ'),
	('1007','�ǿ�'),
	('1008','�ۿ���ҩ'),
	('1009','Ƥ������ҩ'),
	('1010','θ������ҩ'),
	('1011','�س���ҩ'),
	('1012','��������ҩ'),
	('1013','��������ҩ'),
	('1014','�񾭿���ҩ'),
	('1015','�������'),
	('1016','�ε�����ҩ'),
	('1017','��ʪ������ҩ'),
	('1018','��ǻ��ҩ'),
	('1019','������ʹ��ҩ'),
	('1020','������ҩ'),
	('1021','Ӫ��ҩ'),
	('1022','����ҩ'),
	('1023','������Ѫҩ')
--ҩƷ
IF OBJECT_ID('tb_Drug')IS NOT NULL
	DROP TABLE tb_Drug;
	GO
	CREATE TABLE tb_Drug
	(
	No
		CHAR(6)
		CONSTRAINT pk_Drug_No
			PRIMARY KEY(No)
			CONSTRAINT ck_Drug_No
			CHECK(No LIKE'[A-Z][A-Z][A-Z][A-Z][0-9][0-9]'),
	Name
		VARCHAR(200)
			NOT NULL,
	pinyin
		VARCHAR(50)
			NOT NULL,
	Num
		float
			NOT NULL,
	UNIT
		VARCHAR(50)
			NOT NULL,
	PharmacyNo
		CHAR(3)
		NOT NULL
			CONSTRAINT fk_Drug_Pharmacy
				FOREIGN KEY(PharmacyNo)
			REFERENCES tb_Pharmacy(No)
			CONSTRAINT ck_Drug_PharmacyNo
			CHECK(PharmacyNo LIKE '[0-9][0-9][0-9]'),
	TypeNo
		CHAR(4)
		NOT NULL
			CONSTRAINT fk_Drug_TypeNo
				FOREIGN KEY(TypeNo)
			REFERENCES tb_Type(No)
			CONSTRAINT ck_Drug_TypeNo
			CHECK(TypeNo LIKE '[0-9][0-9][0-9][0-9]'),
	Content
		TEXT,
	Price
		float
	)
--ҩƷ����
INSERT INTO tb_Drug(No,Name,pinyin,Num,UNIT,TypeNo,Content,PharmacyNo,Price)VALUES
	('AAAA01','������ѪƽƬ','fflxpp','1000','ƿ','1001','���������ں����ڸ�Ѫѹ����','101',56.2),
	('AAAA02','��ʯ���������Ƭ','jssmtlep','1000','��','1001','�������Ƹ�Ѫѹ���Ľ�ʹ���ļ��������ʺ����ļ������������в㡢����ʧ������״�ٹ��ܿ����������񾭹���֢�ȡ�','101',67.3),
	('BAAA01','����Ƭ','srp','10000','��','1003','����Ѫ���������������������ӣ��ļ����̣���ϥ����','101',6.8),
	('BAAA02','������','srr','3000','��','1003','�����������澫��������������������������й�����Ż�����������ʹ��������������Ѫ������','101',3.12),
	('ABAA01','С��ֹ���ǽ�','xeztj','1000','ƿ','1004','��̵����ȡ�����С����ð����Ŀ��ԡ�','101',2.3),
	('ACAA01','������','dkd','7800','��','1002','�̲���Ѫ������������������Ѫ���顢����Ѫ�����µ��¾��������о���ʹ��','101',1.23),
	('AAAD01','����ѪƽƬ','flxpp','1000','ƿ','1001','���θ�Ѫѹ','101',6.5),
	('ACBA01','��ĸ�ݿ���','ymckl','1000','��','1002','��Ѫ����������Ѫ�����µ��¾�������֢����ˮ���١�','101',12),
	('AACA01','С�����ӻ�����Ƭ','xrafhnmp','1000','��','1004','�����ڻ����ͯ��ͨ��ð�������Ը�ð����ķ��ȡ�ͷʹ����֫��ʹ�������硢�����顢��������ʹ��֢״��','101',34.6),
	('AAAA03','��������Ƭ','ktplp','1000','��','1001','1.��Ѫѹ��2.����˥�ߡ�','101',9.8),
	('AAAA04','����������','jtnjn','1000','ƿ','1001','�����������������������������������ߡ�','101',8.6)
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
	--('AAAA01','������ѪƽƬ','1000','ƿ','1001','���θ�Ѫѹ','101'),
--������
IF OBJECT_ID('tb_Worksheet')IS NOT NULL
	DROP TABLE tb_Worksheet;
	GO
	CREATE TABLE tb_Worksheet
	(
	No 
		CHAR(3)
			NOT NULL
				PRIMARY KEY,
	DoctorNo
		CHAR(10)
		NOT NULL
			CONSTRAINT fk_Worksheet_DoctorNo
				FOREIGN KEY(DoctorNo)
			REFERENCES tb_Doctor(No)
			CONSTRAINT ck_Worksheet_DoctorNo
			CHECK(DoctorNo LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	Time
		DATETIME
		NOT NULL
	)
--������
INSERT INTO tb_Worksheet(No,DoctorNo,Time)VALUES
	('101','2230105001','2023-3-12 9:00'),
	('102','2230105002','2023-3-6 9:00'),
	('103','2230105003','2023-3-6 9:00'),
	('104','2230105004','2023-3-6 9:00'),
	('105','2231202001','2023-3-6 9:00'),
	('106','2231302001','2023-3-6 9:00'),
	('107','2231401001','2023-3-6 9:00'),
	('108','2231501001','2023-3-6 9:00'),
	('109','2231601001','2023-3-6 9:00'),
	('110','2231703001','2023-3-6 9:00'),
	('111','2230305001','2023-3-6 9:00'),
	('112','2231901001','2023-3-6 9:00'),
	('113','2230703001','2023-3-6 9:00'),
	('114','2230305001','2023-3-11 9:00'),
	('115','2230403001','2023-3-7 9:00'),
	('116','2230503001','2023-3-7 9:00'),
	('117','2230403001','2023-3-7 9:00'),
	('118','2230105001','2023-3-7 9:00'),
	('119','2230403001','2023-3-7 9:00'),
	('120','2231702002','2023-3-7 9:00'),
	('121','2230703002','2023-3-7 9:00'),
	('123','2230903001','2023-3-7 9:00'),
	('124','2231003001','2023-3-7 9:00'),
	('125','2231103001','2023-3-7 9:00'),
	('126','2231602002','2023-3-7 9:00'),
	('127','2231502002','2023-3-7 9:00'),
	('128','2230305001','2023-3-8 9:00'),
	('129','2230403001','2023-3-8 9:00'),
	('130','2230503001','2023-3-8 9:00'),
	('131','2231501001','2023-3-8 9:00'),
	('132','2230105001','2023-3-8 9:00'),
	('133','2230105003','2023-3-8 9:00'),
	('134','2231702002','2023-3-8 9:00'),
	('135','2230703002','2023-3-8 9:00'),
	('136','2230903001','2023-3-8 9:00'),
	('137','2230105019','2023-3-8 9:00'),
	('138','2230105012','2023-3-8 9:00'),
	('139','2231602002','2023-3-8 9:00'),
	('140','2230105015','2023-3-11 9:00'),
	('141','2230503001','2023-3-9 9:00'),
	('142','2231501001','2023-3-9 9:00'),
	('143','2230105001','2023-3-9 9:00'),
	('144','2230105003','2023-3-9 9:00'),
	('145','2231702002','2023-3-9 9:00'),
	('146','2230703002','2023-3-9 9:00'),
	('147','2230903001','2023-3-9 9:00'),
	('148','2230105019','2023-3-9 9:00'),
	('149','2230105012','2023-3-9 9:00'),
	('150','2231602002','2023-3-9 9:00'),
	('151','2230105015','2023-3-9 9:00'),
	('152','2230305001','2023-3-9 9:00'),
	('153','2231901001','2023-3-10 9:00'),
	('154','2230703001','2023-3-10 9:00'),
	('155','2230305001','2023-3-10 9:00'),
	('156','2230403001','2023-3-10 9:00'),
	('157','2230503001','2023-3-10 9:00'),
	('158','2230403001','2023-3-10 9:00'),
	('159','2230105001','2023-3-10 9:00'),
	('160','2230403001','2023-3-10 9:00'),
	('161','2231702002','2023-3-10 9:00'),
	('162','2230703002','2023-3-10 9:00'),
	('163','2230903001','2023-3-10 9:00'),
	('164','2231003001','2023-3-10 9:00'),
	('165','2230903001','2023-3-12 9:00')

--ԤԼ
IF OBJECT_ID('tb_Booking')IS NOT NULL
	DROP TABLE tb_Booking;
	GO
	CREATE TABLE tb_Booking
	(
	No 
		CHAR(3)
			NOT NULL
				PRIMARY KEY,
	UserNo
		CHAR(10)
		NOT NULL
			CONSTRAINT fk_Booking_UserNo
				FOREIGN KEY(UserNo)
			REFERENCES tb_User(No)
			CONSTRAINT ck_Booking_UserNo
			CHECK(UserNo LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]'),
	WorkNo
		CHAR(3)
			NOT NULL
			CONSTRAINT fk_Booking_WorkNo
				FOREIGN KEY(WorkNo)
			REFERENCES tb_Worksheet(No),
	Deal
		bit,

	)


--ԤԼ�����
	INSERT INTO tb_Booking(No,UserNo,WorkNo,Deal)VALUES
	('101','3210707001','101',0),
	('102','3210707001','102',0),
	('103','3210707001','103',0),
	('104','3210707001','104',0),
	('105','3210707001','105',0);


--���ﵥ
IF OBJECT_ID('tb_Diagnosticlist')IS NOT NULL
	DROP TABLE tb_Diagnosticlist;
	GO
	CREATE TABLE tb_Diagnosticlist
	(
	 No
		CHAR(3)
		NOT NULL
			CONSTRAINT pk_Diagnosticlist_No
				PRIMARY KEY(No),
			CONSTRAINT ck_Diagnosticlist_No
			CHECK(No LIKE'[0-9][0-9][0-9]'),
	BookingNo
		CHAR(3)
		NOT NULL
			CONSTRAINT fk_Diagnosticlist_BookingNo
				FOREIGN KEY(BookingNo)
			REFERENCES tb_Booking(No),
	Time
		DATE
		NOT NULL,
	Content
		TEXT
		NOT NULL,
	ZZ
		TEXT,
	PriceType
		VARCHAR(10),
	Prices
		float,
	Paid
	bit
	)
--���ﵥ���ݲ���
INSERT INTO tb_Diagnosticlist(No,BookingNo,Time,Content,ZZ,PriceType,Prices,Paid)VALUES('101','101','2023-3-27 ','','','�Է�',0,0)
--ԤԼ��ͼ
GO
IF OBJECT_ID('YYView')IS NOT NULL
DROP VIEW YYView
GO
CREATE VIEW YYView
AS SELECT B.No AS 'ԤԼ��', U.No AS  '���߱��',U.Name AS '��������',W.Time AS 'ԤԼʱ��',Do.Name AS 'ҽ������',W.DoctorNo AS 'ҽ�����', IIF(D.No IS NULL,'��','��') AS '�Ƿ����' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No;

--��������ͼ
GO
IF OBJECT_ID('WorksheetView')IS NOT NULL
DROP VIEW WorksheetView
GO
CREATE VIEW WorksheetView
AS SELECT W.*,IIF(B.NO is null,'��','��') AS '�Ƿ��ԤԼ' FROM tb_Worksheet AS W
LEFT JOIN tb_Booking AS B ON B.WorkNo=W.No;

--ҩƷ��ͼ
GO
IF OBJECT_ID('DrugView')IS NOT NULL
DROP VIEW DrugView
GO
CREATE VIEW DrugView
AS SELECT D.No AS '���', D.Name AS 'ҩ��',D.pinyin AS 'ƴ��',D.Num AS '����',D.UNIT AS '��λ',T.No AS '������',T.Name'ҩƷ����' FROM tb_Drug AS D

JOIN tb_Type AS T ON T.No=D.TypeNo

--�ﵥ��ͼ
GO
IF OBJECT_ID('ZDView')IS NOT NULL
DROP VIEW ZDView
GO
CREATE VIEW ZDView
AS SELECT B.No AS 'NO', U.No AS  'Pno',U.Name AS 'Pname',U.Addres AS 'Address',DATEDIFF(yy,U.Birthday,GETDATE()) AS 'Age',U.Gender AS 'Gender',DS.Time AS 'Time',DS.ZZ AS'ZZ',Do.Name AS 'DoctorName',K.Name AS 'KeSi',DS.PriceType AS 'PriceType',U.Phone AS 'Phone',DS.Prices AS 'Price' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
JOIN tb_Keshi AS K ON K.No=Do.KeshiNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No
LEFT JOIN tb_Diagnosticlist AS DS ON DS.BookingNo=B.No;

GO
BULK INSERT  tb_Drug
FROM 'D:\���ݿ�\Drug.csv'
	WITH
		(FIELDTERMINATOR=','
		,ROWTERMINATOR='\n'
		,FIRSTROW=2);

IF OBJECT_ID('tb_UseDrug')IS NOT NULL
	DROP TABLE tb_UseDrug
	GO
CREATE TABLE tb_UseDrug
	(
	 DrugNo
	 CHAR(6)
	 CONSTRAINT fk_UseDrug_DrugNo
	 FOREIGN KEY(DrugNo)
	 REFERENCES tb_Drug(No),
	 ZDNo
	 CHAR(3)
	 CONSTRAINT fk_UseDrug_ZDNo
	 FOREIGN KEY(ZDNo)
	 REFERENCES tb_Diagnosticlist(No),
	 Num
		float

	)
--�ﵥ��ҩ
GO
IF OBJECT_ID('ZDrugView')IS NOT NULL
DROP VIEW ZDrugView
GO
CREATE VIEW ZDrugView
AS SELECT D.Name AS 'Name',UD.Num AS 'Num',D.UNIT AS 'Unix',D.Price AS 'Price',UD.ZDNo AS 'No' FROM tb_UseDrug AS UD
JOIN tb_Drug AS D ON D.No=UD.DrugNo;


--��������ͼ
GO
IF OBJECT_ID('WkView')IS NOT NULL
DROP VIEW WkView
GO
CREATE VIEW WkView
AS SELECT W.No AS 'No',D.No AS 'DNo',D.Name AS 'Name',k.Name AS 'ks',P.Name AS 'zc',
IIF(DATEPART(WEEKDAY,W.Time)=1,'������',
IIF(DATEPART(WEEKDAY,W.Time)=2,'����һ',
IIF(DATEPART(WEEKDAY,W.Time)=3,'���ڶ�',
IIF(DATEPART(WEEKDAY,W.Time)=4,'������',
IIF(DATEPART(WEEKDAY,W.Time)=5,'������'
,IIF(DATEPART(WEEKDAY,W.Time)=6,'������',
'������') ) ) ) ) ) AS 'Time' FROM tb_Worksheet AS W
JOIN tb_Doctor AS D ON D.No=W.DoctorNo
JOIN tb_Keshi AS K ON K.No=D.KeshiNo
JOIN tb_Pro_title AS P ON P.No =D.ProtitleNo
--ΥԼ��ͼ
GO
IF OBJECT_ID('WYView')IS NOT NULL
DROP VIEW WYView
GO
CREATE VIEW WYView
AS SELECT B.No AS 'ԤԼ��', U.No AS  '���߱��',U.Name AS '��������',W.Time AS 'ԤԼʱ��',Do.Name AS 'ҽ������',W.DoctorNo AS 'ҽ�����', IIF(D.No IS NULL,'��','��') AS '�Ƿ����',IIF(B.Deal =0,'�Ѵ���','δ����') AS '����' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No
WHERE W.Time<GETDATE();
--�û�ΥԼ��¼��ͼ
GO
IF OBJECT_ID('UWYView')IS NOT NULL
DROP VIEW UWYView
GO
CREATE VIEW UWYView
AS SELECT U.No AS  '���߱��',U.Name AS '��������',COUNT(B.No) AS '����' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No
WHERE W.Time<GETDATE()AND D.No IS NULL AND B.Deal =0  AND  GETDATE()-W.Time<30
GROUP BY U.Name,U.No;
--ҽ����ͼ
GO
IF OBJECT_ID('DoctorView')IS NOT NULL
DROP VIEW DoctorView
GO
CREATE VIEW DoctorView
AS
SELECT D.No AS '���', D.Name AS '����',T.Name AS 'ְ��',D.Photo AS '��Ƭ',D.Introduction AS'����' FROM tb_Doctor AS D JOIN tb_Pro_title AS T ON T.No=D.ProtitleNo ;