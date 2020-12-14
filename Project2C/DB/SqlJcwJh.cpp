#include "stdafx.h"
#include "SqlJcwJh.h"


SqliteJcwJh::SqliteJcwJh()
{
}


SqliteJcwJh::~SqliteJcwJh()
{
	Close();
	return;
}

bool SqliteJcwJh::UpdateData(JCWJH& d, sqlite3_stmt* stmt)
{
	int t = 1;

	sqlite3_bind_int64(stmt, t++, (INT64)(d.dTimestamp * 1000000));	//us
	sqlite3_bind_int64(stmt, t++, d.uiFileTime);
	sqlite3_bind_int(stmt, t++, *((int*)d.ucDataDevSrc));
	sqlite3_bind_int64(stmt, t++, d.uiSyncID);
	sqlite3_bind_int(stmt, t++, d.uiLineNum);
	sqlite3_bind_int(stmt, t++, d.posi);
	sqlite3_bind_int(stmt, t++, d.lt);
	sqlite3_bind_int(stmt, t++, d.uiLineCompsateNum);
	sqlite3_bind_double(stmt, t++, d.pntCompLeft.x);
	sqlite3_bind_double(stmt, t++, d.pntCompLeft.y);
	sqlite3_bind_double(stmt, t++, d.pntCompRight.x);
	sqlite3_bind_double(stmt, t++, d.pntCompRight.y);

	for (int i = 0; i < JCWJH_MAX_LINE_NUM; i++)
	{
		sqlite3_bind_double(stmt, t++, d.jcx[i].pntLinePos.x);
		sqlite3_bind_double(stmt, t++, d.jcx[i].pntLinePos.y);
		sqlite3_bind_double(stmt, t++, d.jcx[i].mh.fMsH);
		sqlite3_bind_int(stmt, t++, d.jcx[i].lt);
		sqlite3_bind_int(stmt, t++, d.jcx[i].posi);
	}

	for (int i = 0; i < JCWJH_MAX_LINE_NUM; i++)
	{
		sqlite3_bind_double(stmt, t++, d.jcxComp[i].pntLinePos.x);
		sqlite3_bind_double(stmt, t++, d.jcxComp[i].pntLinePos.y);
	}

	return true;
}


std::vector<std::string> SqliteJcwJh::BuildInitSql()
{
	std::string strSql = "CREATE TABLE config (time_stamp int64, file_time int64, key TEXT, value BLOB)";
	std::string strTab = "CREATE TABLE JCWJH(time_stamp int64, file_time int64, ucDataDevSrc int, uiSyncID int64, uiLineNum int, posi int, lt int, uiLineCompsateNum int, CxLeft double, CyLeft double, CxRight double, CyRight double, jhx1 double, jhy1 double, mh1 double, lt1 int, posi1 int, jhx2 double, jhy2 double, mh2 double, lt2 int, posi2 int, jhx3 double, jhy3 double, mh3 double, lt3 int, posi3 int, jhx4 double, jhy4 double, mh4 double, lt4 int, posi4 int, jhcx1 double, jhcy1 double, jhcx2 double, jhcy2 double, jhcx3 double, jhcy3 double, jhcx4 double, jhcy4 double)";

	vector<string> vec;
	vec.push_back(strTab);
	vec.push_back(strSql);
	return vec;
}

std::string SqliteJcwJh::PrepareSql()
{
	return std::string("insert into JCWJH values(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)");
}

bool SqliteJcwJh::SetKeyValue(const char* strKey, const void* pDatas, UINT uiDataSize)
{
	bool bRet = false;
	double dTimeStamp = GetSysTimeStamp_s();
	INT64 ft;
	GetSystemTimeAsFileTime((FILETIME*)&ft);

	m_lockdb.Lock();
	sqlite3_exec(db, "begin;", 0, 0, 0);

	sqlite3_stmt* stmt = NULL;
	string sql = "insert into config values(?,?,?,?)";
	int res = sqlite3_prepare_v2(db, sql.data(), sql.length(), &stmt, 0);
	if (res == SQLITE_OK && stmt != NULL)
	{
		sqlite3_reset(stmt);

		int t = 1;
		sqlite3_bind_int64(stmt, t++, (INT64)(dTimeStamp * 1000000));	//us
		sqlite3_bind_int64(stmt, t++, ft);
		sqlite3_bind_text(stmt, t++, strKey, strlen(strKey), nullptr);
		sqlite3_bind_blob(stmt, t++, pDatas, uiDataSize, nullptr);

		sqlite3_step(stmt);

		sqlite3_finalize(stmt);
		int ires = sqlite3_exec(db, "commit;", 0, 0, 0);

		bRet = (SQLITE_OK == ires);
	}
	m_lockdb.Unlock();
	return bRet;
}
