--建库
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
    '田杰红',   -- Name - varchar(10)
    '女',   -- Gender - char(2)
    '18120795092',    -- Phone - varchar(20)
	'319665159@qq.com',
    '2002-06-29'
	,'福建省福州市闽侯县上街镇邱阳路一号福建中医药大学',0,0),
('3210707015',HASHBYTES('MD5','1'),'官祥杰','男','18120795092','319665159@qq.com','2002-11-29','福建省福州市闽侯县上街镇邱阳路一号福建中医药大学',0,0),
('3210707002',HASHBYTES('MD5','1'),'刘兰' , '女','18120795092','319665159@qq.com','2003-6-28','福建省福州市闽侯县上街镇邱阳路一号福建中医药大学',0,0),
('3210707003',HASHBYTES('MD5','1'),'吴争宇','男','18120795092','319665159@qq.com','2004-1-23','福建省福州市闽侯县上街镇邱阳路一号福建中医药大学',0,0),
('3210707004',HASHBYTES('MD5','1'),'廖丽珍','女','18120795092','319665159@qq.com','2002-7-14','福建省福州市闽侯县上街镇邱阳路一号福建中医药大学',0,0),
('3210707005',HASHBYTES('MD5','1'),'罗清香','女','18120795092','319665159@qq.com','2002-8-25','福建省福州市闽侯县上街镇邱阳路一号福建中医药大学',0,0)

--科室
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
--科室添加数据
INSERT INTO tb_Keshi
	(No,Name)VALUES
	('1001','国医堂'),
	('1002','脑病科'),
	('1003','肺病科'),
	('1004','心血管科'),
	('1005','脾胃病科'),
	('1006','肾病科(含血透室)'),
	('1007','内分泌科'),
	('1008','肿瘤科'),
	('1009','血液科'),
	('1010','急诊科'),
	('1011','重症医学科'),
	('1012','外一科（普外科）'),
	('1013','外二科（泌尿外科）'),
	('1014','肛肠科'),
	('1015','耳鼻咽喉科'),
	('1016','骨伤一科'),
	('1017','眼科'),
	('1018','口腔科'),
	('1019','皮肤科'),
	('1020','康复一科'),
	('1021','针灸科'),
	('1022','国医堂针推'),
	('1023','妇科'),
	('1024','儿科'),
	('1025','体检科')

--职称表
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
--职称添加数据
INSERT INTO tb_Pro_title(No,Name)VALUES
	('1','医士 '),
	('2','医师  '),
	('3','主治医师  '),
	('4','副主任医师 '),
	('5','主任医师 ')
--医生表
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
	('2230105001','杜建','dj','擅治中医内科各种疑难病及肿瘤的中药辅助治疗,对老年病研究尤深，有独特的治疗经验....', HASHBYTES('MD5','1'), 0,'18000000001','1975-8-8','12345678@qq.com','images/1590397067132.jpg','1001','5'),
	('2230105002','陈立典','cld','主要从事脑卒中后认知和肢体运动功能障碍康复研究...',HASHBYTES('MD5','1'),0,'18000000002','1974-9-28','12345678@qq.com','images/1589965009089.jpg','1001','5'),
	('2230105003','李灿东','lcd','擅长内分泌代谢疾病、慢性胃病、肿瘤等杂病的中医诊治...',HASHBYTES('MD5','1'),0,'18000000003','1976-8-18','12345678@qq.com','images/1589965200973.png','1001','5'),
	('2230105004','王和鸣','whm','擅治骨伤、筋伤、骨病、腰椎间盘突出症、骨质增生等...',HASHBYTES('MD5','1'),0,'18000000004','1978-3-18','12345678@qq.com','','1001','5'),
	('2230105005','张喜奎','zxk','擅长失眠、抑郁、头痛、头晕、神经衰弱、更年期、肿瘤、咳嗽、胃病、多汗、身痒等内科、男科、妇科、皮肤科中医疑...',HASHBYTES('MD5','1'),0,'18000000005','1974-2-23','12345678@qq.com','images/1590397559307.jpg','1001','5'),
	('2230105006','黄俊山','hjs','擅长诊治乳腺增生病、炎性乳房疾病、月经病、产后病（乳汁淤积、乳汁缺少、亚健康、抑郁症）及乳腺癌术后中医药辨治...',HASHBYTES('MD5','1'),0,'18000000006','1975-3-24','12345678@qq.com','images/1586853295666.png','1001','5'),
	('2230105007','王苹','wp','糖尿病、高血压、高脂高粘血症、痛风、甲状腺疾病、甲减、红斑狼疮、硬皮病等疾病诊治。...',HASHBYTES('MD5','1'),  1,'18003450007','1964-8-8','12345678@qq.com','','1001','5'),
	('2230105008','施红','sh','擅长：中医内科、妇科、儿科疾病的辨证施治，尤其在感冒发热、咳嗽、鼻咽炎、急慢性胃肠炎、慢性乙型肝炎、泌尿系统...',HASHBYTES('MD5','1'),  1,'18004530006','1979-8-8','12345678@qq.com','','1001','5'),
	('2230105009','陈锦芳','cjf','擅长各类肿瘤的中医药辅助治疗以及消化系统疾病，萎缩性胃炎、慢性肝炎等癌前病变逆转，过敏性鼻炎、荨麻疹、小儿哮...',HASHBYTES('MD5','1'),0,'18003450006','1969-8-8','12345678@qq.com','','1001','5'),
	('2230105010','吴水生','wss','擅长针药并用治疗中风、糖尿病、失眠、头痛、耳鸣、颈椎病、脊柱类疾病、各类痛证、痛风、风湿类疾病、痤疮、皮疹、...',HASHBYTES('MD5','1'),0,'18340000006','1980-8-8','12345678@qq.com','','1001','5'),
	('2230105011','吴童','wt','擅长各种肾病、尿路感染、肠胃病、肝病、水肿、月经病、乳腺增生、发热、顽固性咳嗽、头痛、心悸眩晕、痤疮、荨麻疹...',HASHBYTES('MD5','1'),  0,'18000000045','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105012','鲁玉辉','lyh','擅长于中西医结合治疗：甲状腺、肝胆、肠胃疾病；中医治疗感冒、咳嗽、习惯性便秘、不寐症（失眠）、偏头痛、高血压...',HASHBYTES('MD5','1'),0,'18000457006','1976-8-8','12345678@qq.com','','1001','5'),
	('2230105013','陈桂铭','cgm','擅长颈椎病、腰腿痛、肩周炎、类风湿性关节炎、强直性脊柱炎、痛风等中医骨伤科常见病、多发病的诊治...',HASHBYTES('MD5','1'),0,'18078900006','1978-8-8','12345678@qq.com','','1001','5'),
	('2230105014','李楠','ln','擅长失眠、多梦、忧郁等心身疾病，急慢性胃炎、胃溃疡、肠预激综合征等消化系统疾病的中医治疗；以及胆囊炎、肝胆结...',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105015','金浪','jl','擅长治疗月经病、带下病、产后病、更年期综合症、痤疮和亚健康状态治疗和调理...',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105016','郑月娥','zye','擅治胃肠疾病、月经不调、带下病、失眠、头晕、感冒、咳喘、咽炎、痤疮、湿疹，更年期疾病及体质虚弱等亚健康的中医...',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105017','杨敏','ym','擅长于治疗消化疾病（胃、肠、肝、胆病），感冒、咳嗽，妇科月经不调、痛经、产后调理，肿瘤的中药辅助治疗等...',HASHBYTES('MD5','1'),  1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105018','周建衡','zjh','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105019','陈少芳','csf','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105020','梁文娜','lwn','中医健康管理，消化系统疾病、妇科疾病、代谢内分泌疾病及其他常见病的中医诊疗...',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105021','肖绍坚','xsj','中西结合治疗心血管病、脾胃病、老年病及慢性病的中医体质调理。...',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2230105022','林友宁','lyn','高血压、糖尿病及消化系统疾病的诊疗，尤其擅长于肝病的中西医结合治疗。...',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','5'),
	('2231101002','程琨耀','cky','诊治儿童脑病（脑瘫、智障、自闭）、中风后偏瘫、颈肩腰腿疾病及经络调理。...',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1011','1'),
	('2231202001','蔡徐琨','cky','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1012','2'),
	('2231302001','肖战','xz','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1013','2'),
	('2231401001','王一博','wyb;','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1014','1'),
	('2231501001','王鹤第','whd','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1015','1'),
	('2231601001','李一桐','lyt','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1016','1'),
	('2231703001','周丽','zl','',HASHBYTES('MD5','1'),  1,'18000000006','1950-8-8','12345678@qq.com','','1017','3'),
	('2231803001','林晓丽','lxl','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1018','3'),
	('2231901001','肖雯迪','xdw','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1019','1'),
	('2230104001','陈玉鹏','cyp','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1001','4'),
	('2230703001','柯媛媛','kyy','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1007','3'),
	('2230203001','叶渟渟','ytt','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1002','3'),
	('2230305001','张丽丽','ztt','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1003','5'),
	('2230403001','李承杰','lcj','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1004','3'),
	('2230503001','王耀芩','wyq','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1005','3'),
	('2230603001','李雯雯','lww','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1006','3'),
	('2230703002','陈铭辉','cmh','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1007','3'),
	('2230803001','张涛','zt','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1008','3'),
	('2230903001','林可钦','lkq','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1009','3'),
	('2231003001','林芸惠','lyh','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1010','3'),
	('2231103001','郑阳','zy','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1011','3'),
	('2231202002','杜城','dc','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1012','2'),
	('2231302002','杨海','yh','',HASHBYTES('MD5','1'),  0,'18000000006','1950-8-8','12345678@qq.com','','1013','2'),
	('2231402002','杨国庆','ygq','',HASHBYTES('MD5','1'),0,'18000000006','1950-8-8','12345678@qq.com','','1014','2'),
	('2231502002','李玲','ll','',HASHBYTES('MD5','1'),  1,'18000000006','1950-8-8','12345678@qq.com','','1015','2'),
	('2231602002','蔡雯雯','cww','',HASHBYTES('MD5','1'),1,'18000000006','1950-8-8','12345678@qq.com','','1016','2'),
	('2231702002','吴易','wy','',HASHBYTES('MD5','1')  ,0,'18000000006','1950-8-8','12345678@qq.com','','1017','2')

--药房
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
	('101','一号仓库'),
	('102','中药仓库'),
	('103','危险品仓库')

--药品分类
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
	('1001','心脑血管用药'),
	('1002','妇科用药'),
	('1003','男科用药'),
	('1004','儿科用药'),
	('1005','内分泌用药'),
	('1006','泌尿系统用药'),
	('1007','骨科'),
	('1008','眼科用药'),
	('1009','皮肤科用药'),
	('1010','胃肠道用药'),
	('1011','肛肠用药'),
	('1012','呼吸科用药'),
	('1013','抗肿瘤用药'),
	('1014','神经科用药'),
	('1015','神经心理科'),
	('1016','肝胆科用药'),
	('1017','风湿免疫用药'),
	('1018','口腔用药'),
	('1019','解热镇痛用药'),
	('1020','抗过敏药'),
	('1021','营养药'),
	('1022','清热药'),
	('1023','补气益血药')
--药品
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
--药品插入
INSERT INTO tb_Drug(No,Name,pinyin,Num,UNIT,TypeNo,Content,PharmacyNo,Price)VALUES
	('AAAA01','复方利血平片','fflxpp','1000','瓶','1001','适用于早期和中期高血压病。','101',56.2),
	('AAAA02','酒石酸美托洛尔片','jssmtlep','1000','盒','1001','用于治疗高血压、心绞痛、心肌梗死、肥厚型心肌病、主动脉夹层、心律失常、甲状腺功能亢进、心脏神经官能症等。','101',67.3),
	('BAAA01','参茸片','srp','10000','板','1003','补气血，益心肾。用于体虚神怯，心悸气短，腰膝酸软。','101',6.8),
	('BAAA02','参茸丸','srr','3000','丸','1003','滋阴补肾，益精助阳。用于肾虚肾寒，阳痿早泄，梦遗滑精、腰腿酸痛，形体瘦弱，气血两亏。','101',3.12),
	('ABAA01','小儿止咳糖浆','xeztj','1000','瓶','1004','祛痰，镇咳。用于小儿感冒引起的咳嗽。','101',2.3),
	('ACAA01','定坤丹','dkd','7800','丸','1002','滋补气血，调经舒郁。用于气血两虚、气滞血瘀所致的月经不调、行经腹痛。','101',1.23),
	('AAAD01','方利血平片','flxpp','1000','瓶','1001','主治高血压','101',6.5),
	('ACBA01','益母草颗粒','ymckl','1000','袋','1002','活血调经。用于血瘀所致的月经不调，症见经水量少。','101',12),
	('AACA01','小儿氨酚黄那敏片','xrafhnmp','1000','盒','1004','适用于缓解儿童普通感冒及流行性感冒引起的发热、头痛、四肢酸痛、打喷嚏、流鼻涕、鼻塞、咽痛等症状。','101',34.6),
	('AAAA03','卡托普利片','ktplp','1000','板','1001','1.高血压；2.心力衰竭。','101',9.8),
	('AAAA04','降糖宁胶囊','jtnjn','1000','瓶','1001','益气，养阴，生津。用于糖尿病属气阴两虚者。','101',8.6)
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
	--('AAAA01','复方利血平片','1000','瓶','1001','主治高血压','101'),
--工作表
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
--工作表
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

--预约
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


--预约插入表
	INSERT INTO tb_Booking(No,UserNo,WorkNo,Deal)VALUES
	('101','3210707001','101',0),
	('102','3210707001','102',0),
	('103','3210707001','103',0),
	('104','3210707001','104',0),
	('105','3210707001','105',0);


--就诊单
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
--就诊单数据插入
INSERT INTO tb_Diagnosticlist(No,BookingNo,Time,Content,ZZ,PriceType,Prices,Paid)VALUES('101','101','2023-3-27 ','','','自费',0,0)
--预约视图
GO
IF OBJECT_ID('YYView')IS NOT NULL
DROP VIEW YYView
GO
CREATE VIEW YYView
AS SELECT B.No AS '预约号', U.No AS  '患者编号',U.Name AS '患者姓名',W.Time AS '预约时间',Do.Name AS '医生名字',W.DoctorNo AS '医生编号', IIF(D.No IS NULL,'否','是') AS '是否就诊' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No;

--工作表视图
GO
IF OBJECT_ID('WorksheetView')IS NOT NULL
DROP VIEW WorksheetView
GO
CREATE VIEW WorksheetView
AS SELECT W.*,IIF(B.NO is null,'是','否') AS '是否可预约' FROM tb_Worksheet AS W
LEFT JOIN tb_Booking AS B ON B.WorkNo=W.No;

--药品视图
GO
IF OBJECT_ID('DrugView')IS NOT NULL
DROP VIEW DrugView
GO
CREATE VIEW DrugView
AS SELECT D.No AS '编号', D.Name AS '药名',D.pinyin AS '拼音',D.Num AS '数量',D.UNIT AS '单位',T.No AS '分类编号',T.Name'药品分类' FROM tb_Drug AS D

JOIN tb_Type AS T ON T.No=D.TypeNo

--诊单视图
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
FROM 'D:\数据库\Drug.csv'
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
--诊单用药
GO
IF OBJECT_ID('ZDrugView')IS NOT NULL
DROP VIEW ZDrugView
GO
CREATE VIEW ZDrugView
AS SELECT D.Name AS 'Name',UD.Num AS 'Num',D.UNIT AS 'Unix',D.Price AS 'Price',UD.ZDNo AS 'No' FROM tb_UseDrug AS UD
JOIN tb_Drug AS D ON D.No=UD.DrugNo;


--工作表视图
GO
IF OBJECT_ID('WkView')IS NOT NULL
DROP VIEW WkView
GO
CREATE VIEW WkView
AS SELECT W.No AS 'No',D.No AS 'DNo',D.Name AS 'Name',k.Name AS 'ks',P.Name AS 'zc',
IIF(DATEPART(WEEKDAY,W.Time)=1,'星期天',
IIF(DATEPART(WEEKDAY,W.Time)=2,'星期一',
IIF(DATEPART(WEEKDAY,W.Time)=3,'星期二',
IIF(DATEPART(WEEKDAY,W.Time)=4,'星期三',
IIF(DATEPART(WEEKDAY,W.Time)=5,'星期四'
,IIF(DATEPART(WEEKDAY,W.Time)=6,'星期六',
'星期天') ) ) ) ) ) AS 'Time' FROM tb_Worksheet AS W
JOIN tb_Doctor AS D ON D.No=W.DoctorNo
JOIN tb_Keshi AS K ON K.No=D.KeshiNo
JOIN tb_Pro_title AS P ON P.No =D.ProtitleNo
--违约视图
GO
IF OBJECT_ID('WYView')IS NOT NULL
DROP VIEW WYView
GO
CREATE VIEW WYView
AS SELECT B.No AS '预约号', U.No AS  '患者编号',U.Name AS '患者姓名',W.Time AS '预约时间',Do.Name AS '医生名字',W.DoctorNo AS '医生编号', IIF(D.No IS NULL,'否','是') AS '是否就诊',IIF(B.Deal =0,'已处理','未处理') AS '处理' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No
WHERE W.Time<GETDATE();
--用户违约记录视图
GO
IF OBJECT_ID('UWYView')IS NOT NULL
DROP VIEW UWYView
GO
CREATE VIEW UWYView
AS SELECT U.No AS  '患者编号',U.Name AS '患者姓名',COUNT(B.No) AS '数量' FROM tb_Booking AS B
JOIN tb_Worksheet AS W ON W.No=B.WorkNo 
JOIN tb_User AS U ON U.No=B.UserNo
JOIN tb_Doctor AS Do ON Do.No=W.DoctorNo
LEFT JOIN tb_Diagnosticlist AS D ON D.BookingNo=B.No
WHERE W.Time<GETDATE()AND D.No IS NULL AND B.Deal =0  AND  GETDATE()-W.Time<30
GROUP BY U.Name,U.No;
--医生视图
GO
IF OBJECT_ID('DoctorView')IS NOT NULL
DROP VIEW DoctorView
GO
CREATE VIEW DoctorView
AS
SELECT D.No AS '编号', D.Name AS '姓名',T.Name AS '职称',D.Photo AS '照片',D.Introduction AS'介绍' FROM tb_Doctor AS D JOIN tb_Pro_title AS T ON T.No=D.ProtitleNo ;