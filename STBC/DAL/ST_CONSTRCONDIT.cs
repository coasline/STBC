using System;
using System.Data;
using System.Text;
using Oracle.DataAccess.Client;
using Maticsoft.DBUtility;//Please add references
namespace STBC.DAL
{
	/// <summary>
	/// 数据访问类:ST_CONSTRCONDIT
	/// </summary>
	public partial class ST_CONSTRCONDIT
	{
		public ST_CONSTRCONDIT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ST_CONSTRCONDIT");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal USERID, decimal FACTID, string MEASNAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ST_CONSTRCONDIT");
            strSql.Append(" where USERID=:USERID and FACTID=:FACTID and  MEASNAME=:MEASNAME");
            OracleParameter[] parameters = {
					new OracleParameter(":USERID", OracleDbType.Int32,22),
                                           new OracleParameter(":FACTID", OracleDbType.Int32,22),
	                                       new OracleParameter(":MEASNAME", OracleDbType.Varchar2,22)	
                                           };
            parameters[0].Value = USERID;
            parameters[1].Value = FACTID;
            parameters[2].Value = MEASNAME;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.ST_CONSTRCONDIT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ST_CONSTRCONDIT(");
			strSql.Append("ID,FACTID,UNIT,SYMBOLTYPE,LIMCONDIT,FACTTYPE,MEASNAME,USERID)");
			strSql.Append(" values (");
			strSql.Append(":ID,:FACTID,:UNIT,:SYMBOLTYPE,:LIMCONDIT,:FACTTYPE,:MEASNAME,:USERID)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,7),
					new OracleParameter(":FACTID", OracleDbType.Int32,7),
					new OracleParameter(":UNIT", OracleDbType.Varchar2,20),
					new OracleParameter(":SYMBOLTYPE", OracleDbType.Varchar2,20),
					new OracleParameter(":LIMCONDIT", OracleDbType.Varchar2,200),
					new OracleParameter(":FACTTYPE", OracleDbType.Varchar2,20),
					new OracleParameter(":MEASNAME", OracleDbType.Varchar2,100),
					new OracleParameter(":USERID", OracleDbType.Int32,7)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FACTID;
			parameters[2].Value = model.UNIT;
			parameters[3].Value = model.SYMBOLTYPE;
			parameters[4].Value = model.LIMCONDIT;
			parameters[5].Value = model.FACTTYPE;
			parameters[6].Value = model.MEASNAME;
			parameters[7].Value = model.USERID;

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
		public bool Update(STBC.Model.ST_CONSTRCONDIT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ST_CONSTRCONDIT set ");
            //strSql.Append("FACTID=:FACTID,");
			strSql.Append("UNIT=:UNIT,");
			strSql.Append("SYMBOLTYPE=:SYMBOLTYPE,");
			strSql.Append("LIMCONDIT=:LIMCONDIT,");
			strSql.Append("FACTTYPE=:FACTTYPE,");
            //strSql.Append("MEASNAME=:MEASNAME,");
            //strSql.Append("USERID=:USERID");
            strSql.Append(" where FACTID=:FACTID and USERID=:USERID and  MEASNAME=:MEASNAME");
			OracleParameter[] parameters = {
                    //new OracleParameter(":FACTID", OracleDbType.Int32,7),
					new OracleParameter(":UNIT", OracleDbType.Varchar2,20),
					new OracleParameter(":SYMBOLTYPE", OracleDbType.Varchar2,20),
					new OracleParameter(":LIMCONDIT", OracleDbType.Varchar2,200),
					new OracleParameter(":FACTTYPE", OracleDbType.Varchar2,20),
                    new OracleParameter(":FACTID", OracleDbType.Int32,7),
                    new OracleParameter(":USERID", OracleDbType.Int32,7),
					new OracleParameter(":MEASNAME", OracleDbType.Varchar2,100)
					}; 
			
			parameters[0].Value = model.UNIT;
			parameters[1].Value = model.SYMBOLTYPE;
			parameters[2].Value = model.LIMCONDIT;
			parameters[3].Value = model.FACTTYPE;
            parameters[4].Value = model.FACTID;
            parameters[5].Value = model.USERID;
            //parameters[6].Value = model.ID;
			parameters[6].Value = model.MEASNAME;
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
			strSql.Append("delete from ST_CONSTRCONDIT ");
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
			strSql.Append("delete from ST_CONSTRCONDIT ");
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
		public STBC.Model.ST_CONSTRCONDIT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FACTID,UNIT,SYMBOLTYPE,LIMCONDIT,FACTTYPE,MEASNAME,USERID from ST_CONSTRCONDIT ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

			STBC.Model.ST_CONSTRCONDIT model=new STBC.Model.ST_CONSTRCONDIT();
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
		public STBC.Model.ST_CONSTRCONDIT DataRowToModel(DataRow row)
		{
			STBC.Model.ST_CONSTRCONDIT model=new STBC.Model.ST_CONSTRCONDIT();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["FACTID"]!=null && row["FACTID"].ToString()!="")
				{
					model.FACTID=decimal.Parse(row["FACTID"].ToString());
				}
				if(row["UNIT"]!=null)
				{
					model.UNIT=row["UNIT"].ToString();
				}
				if(row["SYMBOLTYPE"]!=null)
				{
					model.SYMBOLTYPE=row["SYMBOLTYPE"].ToString();
				}
				if(row["LIMCONDIT"]!=null)
				{
					model.LIMCONDIT=row["LIMCONDIT"].ToString();
				}
				if(row["FACTTYPE"]!=null)
				{
					model.FACTTYPE=row["FACTTYPE"].ToString();
				}
				if(row["MEASNAME"]!=null)
				{
					model.MEASNAME=row["MEASNAME"].ToString();
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
			strSql.Append("select ID,FACTID,UNIT,SYMBOLTYPE,LIMCONDIT,FACTTYPE,MEASNAME,USERID ");
			strSql.Append(" FROM ST_CONSTRCONDIT ");
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
			strSql.Append("select count(1) FROM ST_CONSTRCONDIT ");
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
			strSql.Append(")AS Row, T.*  from ST_CONSTRCONDIT T ");
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
			parameters[0].Value = "ST_CONSTRCONDIT";
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

