
-- 创建站区信息表
CREATE TABLE stationInfo(
	sId INTEGER PRIMARY KEY AUTOINCREMENT,
	sName varchar(50),
	sType tinyint,   -- 1 上行 2下行
	taskDate DATETIME NOT NULL
);



-- //创建 线路信息表 pID ，shootTime拍摄时间
CREATE TABLE stationInfo(sId INTEGER PRIMARY KEY,sLineName varchar(255),[sStartStation] VARCHAR(255),sEndStation VARCHAR(255),sType tinyint,taskDate DATE);


CREATE TABLE indexTB(
  [timestamp] INT64 PRIMARY KEY,  
  [poleNum] VARCHAR(50), 
  [KMValue] INTEGER, 
  [timestampA] INT64 NOT NULL, 
  [dbIndexA] VARCHAR(255) NOT NULL, 
  [timestampB] INT64 NOT NULL, 
  [dbIndexB] VARCHAR(255)NOT NULL
  ) ;
