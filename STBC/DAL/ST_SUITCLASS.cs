using System;
using System.Data;
using System.Text;
using Oracle.DataAccess.Client;
using Maticsoft.DBUtility;//Please add references
namespace STBC.DAL
{
	/// <summary>
	/// 数据访问类:ST_SUITCLASS
	/// </summary>
	public partial class ST_SUITCLASS
	{
		public ST_SUITCLASS()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(decimal userID, string NAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ST_SUITCLASS");
            strSql.Append(" where USERID=:USERID and NAME=:NAME");
			OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleDbType.Int32,22),
                                           new OracleParameter(":NAME", OracleDbType.Varchar2,22)	};
            parameters[0].Value = userID;
            parameters[1].Value = NAME;
			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.ST_SUITCLASS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ST_SUITCLASS(");
			strSql.Append("ID,NAME,CODE,CEILING,FLOOR,USERID)");
			strSql.Append(" values (");
			strSql.Append(":ID,:NAME,:CODE,:CEILING,:FLOOR,:USERID)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,7),
					new OracleParameter(":NAME", OracleDbType.Varchar2,100),
					new OracleParameter(":CODE", OracleDbType.Varchar2,100),
					new OracleParameter(":CEILING", OracleDbType.Decimal,7),
					new OracleParameter(":FLOOR", OracleDbType.Decimal,7),
					new OracleParameter(":USERID", OracleDbType.Int32,7)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.NAME;
			parameters[2].Value = model.CODE;
			parameters[3].Value = model.CEILING;
			parameters[4].Value = model.FLOOR;
			parameters[5].Value = model.USERID;

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
		public bool Update(STBC.Model.ST_SUITCLASS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ST_SUITCLASS set ");
            //strSql.Append("NAME=:NAME,");
			strSql.Append("CODE=:CODE,");
			strSql.Append("CEILING=:CEILING,");
			strSql.Append("FLOOR=:FLOOR");
            //strSql.Append("USERID=:USERID");
            strSql.Append(" where USERID=:USERID and NAME=:NAME");
			OracleParameter[] parameters = {
					new OracleParameter(":CODE", OracleDbType.Varchar2,100),
					new OracleParameter(":CEILING", OracleDbType.Decimal,7),
					new OracleParameter(":FLOOR", OracleDbType.Decimal,7),
					new OracleParameter(":USERID", OracleDbType.Int32,7),
                    new OracleParameter(":NAME", OracleDbType.Varchar2,100)};
		
			parameters[0].Value = model.CODE;
			parameters[1].Value = model.CEILING;
			parameters[2].Value = model.FLOOR;
			parameters[3].Value = model.USERID;	
            parameters[4].Value = model.NAME;
            //parameters[5].Value = model.ID;

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
		public bool Delete(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ST_SUITCLASS ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

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
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ST_SUITCLASS ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
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
		public STBC.Model.ST_SUITCLASS GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,NAME,CODE,CEILING,FLOOR,USERID from ST_SUITCLASS ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

			STBC.Model.ST_SUITCLASS model=new STBC.Model.ST_SUITCLASS();
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
		public STBC.Model.ST_SUITCLASS DataRowToModel(DataRow row)
		{
			STBC.Model.ST_SUITCLASS model=new STBC.Model.ST_SUITCLASS();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["NAME"]!=null)
				{
					model.NAME=row["NAME"].ToString();
				}
				if(row["CODE"]!=null)
				{
					model.CODE=row["CODE"].ToString();
				}
				if(row["CEILING"]!=null && row["CEILING"].ToString()!="")
				{
					model.CEILING=decimal.Parse(row["CEILING"].ToString());
				}
				if(row["FLOOR"]!=null && row["FLOOR"].ToString()!="")
				{
					model.FLOOR=decimal.Parse(row["FLOOR"].ToString());
				}
				if(row["USERID"]!=null && row["USERID"].ToString()!="")
				{
					model.USERID=decimal.Parse(row["USERID"].ToString());
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
			strSql.Append("select ID,NAME,CODE,CEILING,FLOOR,USERID ");
			strSql.Append(" FROM ST_SUITCLASS ");
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
			strSql.Append("select count(1) FROM ST_SUITCLASS ");
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
				strSql.Append("order by T.ID desc");
			}
			strSql.Append(")AS Row, T.*  from ST_SUITCLASS T ");
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
			parameters[0].Value = "ST_SUITCLASS";
			parameters[1].Value = "ID";
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

