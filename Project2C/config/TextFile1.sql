string strCreateImgTB = "CREATE TABLE picInfo(pId INTEGER PRIMARY KEY AUTOINCREMENT,
cId INTEGER,shootTime INTEGER,poleNum INTEGER,GPS INTEGER,sId INTEGER,imgContent BLOG);";



 create table FaultRecode
(
	rid INTEGER primary key AUTOINCREMENT,
	pid INTEGER, --图像id
	uid INTEGER, --部件id
	fid INTEGER, --缺陷ID
	levelId  INTEGER, --等级ID
	analyzeDate DATETIME,--分析时间
	comfirmDate DATETIME,--确认时间
	OffsetX INTEGER NOT NULL,--标注X坐标
	OffsetY INTEGER NOT NULL,--标注Y坐标
	width INTEGER NOT NULL,
	height INTEGER NOT NULL
)
CREATE TABLE pictureInfo
(
	pId INTEGER PRIMARY KEY AUTOINCREMENT, 
	shootTime INTEGER,
	poleNum INTEGER,
	KMValue INTEGER ,
	sId INTEGER, 
	areaType INTEGER,
	imgContent BLOG
);
CREATE TABLE stationInfo(
	sId INTEGER PRIMARY KEY AUTOINCREMENT, 
	sName varchar(50),
	sType tinyint,
	taskDate DATETIME NOT NULL
);

CREATE TABLE LoginTable(loginId INTEGER PRIMARY KEY AUTOINCREMENT, userName varchar(50),userPwd varchar(50));

Create table poleIndex(
	id INTEGER PRIMARY KEY AUTOINCREMENT, --记录索引号	
	pId INTEGER, -- 图像索引号 外码
	cId INTEGER, -- 相机索引号 
	frameNo INTEGER, -- 帧号
	poleNum varchar(50),--支柱号
	sName  varchar(50)--线路名称
)