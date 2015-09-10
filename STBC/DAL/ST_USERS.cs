using System;
using System.Data;
using System.Text;
using Oracle.DataAccess.Client;
using Maticsoft.DBUtility;//Please add references
namespace STBC.DAL
{
	/// <summary>
	/// 数据访问类:ST_USERS
	/// </summary>
	public partial class ST_USERS
	{
		public ST_USERS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal USERID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ST_USERS");
			strSql.Append(" where USERID=:USERID ");
			OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleDbType.Int32,22)			};
			parameters[0].Value = USERID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.ST_USERS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ST_USERS(");
			strSql.Append("USERID,USERNAME,USERSEX,LEVELNAME,USERTRADE,USERCOMPANY,USERPOSITION,USERRESEARCH_FIELDS,PSW,PHOTO)");
			strSql.Append(" values (");
			strSql.Append(":USERID,:USERNAME,:USERSEX,:LEVELNAME,:USERTRADE,:USERCOMPANY,:USERPOSITION,:USERRESEARCH_FIELDS,:PSW,:PHOTO)");
			OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleDbType.Int32,7),
					new OracleParameter(":USERNAME", OracleDbType.Varchar2,20),
					new OracleParameter(":USERSEX", OracleDbType.Varchar2,5),
					new OracleParameter(":LEVELNAME", OracleDbType.Varchar2,10),
					new OracleParameter(":USERTRADE", OracleDbType.Varchar2,20),
					new OracleParameter(":USERCOMPANY", OracleDbType.Varchar2,200),
					new OracleParameter(":USERPOSITION", OracleDbType.Varchar2,20),
					new OracleParameter(":USERRESEARCH_FIELDS", OracleDbType.Varchar2,200),
					new OracleParameter(":PSW", OracleDbType.Varchar2,20),
					new OracleParameter(":PHOTO", OracleDbType.Varchar2,7)};
			parameters[0].Value = model.USERID;
			parameters[1].Value = model.USERNAME;
			parameters[2].Value = model.USERSEX;
			parameters[3].Value = model.LEVELNAME;
			parameters[4].Value = model.USERTRADE;
			parameters[5].Value = model.USERCOMPANY;
			parameters[6].Value = model.USERPOSITION;
			parameters[7].Value = model.USERRESEARCH_FIELDS;
			parameters[8].Value = model.PSW;
			parameters[9].Value = model.PHOTO;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(STBC.Model.ST_USERS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ST_USERS set ");
			strSql.Append("USERNAME=:USERNAME,");
			strSql.Append("USERSEX=:USERSEX,");
			strSql.Append("LEVELNAME=:LEVELNAME,");
			strSql.Append("USERTRADE=:USERTRADE,");
			strSql.Append("USERCOMPANY=:USERCOMPANY,");
			strSql.Append("USERPOSITION=:USERPOSITION,");
			strSql.Append("USERRESEARCH_FIELDS=:USERRESEARCH_FIELDS,");
			strSql.Append("PSW=:PSW,");
			strSql.Append("PHOTO=:PHOTO");
			strSql.Append(" where USERID=:USERID ");
			OracleParameter[] parameters = {
					new OracleParameter(":USERNAME", OracleDbType.Varchar2,20),
					new OracleParameter(":USERSEX", OracleDbType.Varchar2,5),
					new OracleParameter(":LEVELNAME", OracleDbType.Varchar2,10),
					new OracleParameter(":USERTRADE", OracleDbType.Varchar2,20),
					new OracleParameter(":USERCOMPANY", OracleDbType.Varchar2,200),
					new OracleParameter(":USERPOSITION", OracleDbType.Varchar2,20),
					new OracleParameter(":USERRESEARCH_FIELDS", OracleDbType.Varchar2,200),
					new OracleParameter(":PSW", OracleDbType.Varchar2,20),
					new OracleParameter(":PHOTO", OracleDbType.Varchar2,7),
					new OracleParameter(":USERID", OracleDbType.Int32,7)};
			parameters[0].Value = model.USERNAME;
			parameters[1].Value = model.USERSEX;
			parameters[2].Value = model.LEVELNAME;
			parameters[3].Value = model.USERTRADE;
			parameters[4].Value = model.USERCOMPANY;
			parameters[5].Value = model.USERPOSITION;
			parameters[6].Value = model.USERRESEARCH_FIELDS;
			parameters[7].Value = model.PSW;
			parameters[8].Value = model.PHOTO;
			parameters[9].Value = model.USERID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal USERID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ST_USERS ");
			strSql.Append(" where USERID=:USERID ");
			OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleDbType.Int32,22)			};
			parameters[0].Value = USERID;

			int rows=DbHelperOra.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string USERIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ST_USERS ");
			strSql.Append(" where USERID in ("+USERIDlist + ")  ");
			int rows=DbHelperOra.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public STBC.Model.ST_USERS GetModel(decimal USERID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select USERID,USERNAME,USERSEX,LEVELNAME,USERTRADE,USERCOMPANY,USERPOSITION,USERRESEARCH_FIELDS,PSW,PHOTO from ST_USERS ");
			strSql.Append(" where USERID=:USERID ");
			OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleDbType.Int32,22)			};
			parameters[0].Value = USERID;

			STBC.Model.ST_USERS model=new STBC.Model.ST_USERS();
			DataSet ds=DbHelperOra.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public STBC.Model.ST_USERS DataRowToModel(DataRow row)
		{
			STBC.Model.ST_USERS model=new STBC.Model.ST_USERS();
			if (row != null)
			{
				if(row["USERID"]!=null && row["USERID"].ToString()!="")
				{
					model.USERID=decimal.Parse(row["USERID"].ToString());
				}
				if(row["USERNAME"]!=null)
				{
					model.USERNAME=row["USERNAME"].ToString();
				}
				if(row["USERSEX"]!=null)
				{
					model.USERSEX=row["USERSEX"].ToString();
				}
				if(row["LEVELNAME"]!=null)
				{
					model.LEVELNAME=row["LEVELNAME"].ToString();
				}
				if(row["USERTRADE"]!=null)
				{
					model.USERTRADE=row["USERTRADE"].ToString();
				}
				if(row["USERCOMPANY"]!=null)
				{
					model.USERCOMPANY=row["USERCOMPANY"].ToString();
				}
				if(row["USERPOSITION"]!=null)
				{
					model.USERPOSITION=row["USERPOSITION"].ToString();
				}
				if(row["USERRESEARCH_FIELDS"]!=null)
				{
					model.USERRESEARCH_FIELDS=row["USERRESEARCH_FIELDS"].ToString();
				}
				if(row["PSW"]!=null)
				{
					model.PSW=row["PSW"].ToString();
				}
				if(row["PHOTO"]!=null)
				{
					model.PHOTO=row["PHOTO"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select USERID,USERNAME,USERSEX,LEVELNAME,USERTRADE,USERCOMPANY,USERPOSITION,USERRESEARCH_FIELDS,PSW,PHOTO ");
			strSql.Append(" FROM ST_USERS ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ST_USERS ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.USERID desc");
			}
			strSql.Append(")AS Row, T.*  from ST_USERS T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperOra.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OracleParameter[] parameters = {
					new OracleParameter(":tblName", OracleDbType.Varchar2, 255),
					new OracleParameter(":fldName", OracleDbType.Varchar2, 255),
					new OracleParameter(":PageSize", OracleDbType.Int32),
					new OracleParameter(":PageIndex", OracleDbType.Int32),
					new OracleParameter(":IsReCount", OracleDbType.Clob),
					new OracleParameter(":OrderType", OracleDbType.Clob),
					new OracleParameter(":strWhere", OracleDbType.Varchar2,1000),
					};
			parameters[0].Value = "ST_USERS";
			parameters[1].Value = "USERID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOra.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

