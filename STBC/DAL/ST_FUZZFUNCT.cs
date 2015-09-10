using System;
using System.Data;
using System.Text;
using Oracle.DataAccess.Client;

using Maticsoft.DBUtility;//Please add references
namespace STBC.DAL
{
	/// <summary>
	/// 数据访问类:ST_FUZZFUNCT
	/// </summary>
	public partial class ST_FUZZFUNCT
	{
		public ST_FUZZFUNCT()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ST_FUZZFUNCT");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal FACTID, decimal USERID, string MEASNAME)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ST_FUZZFUNCT");
            strSql.Append(" where FACTID=:FACTID and USERID=:USERID and MEASNAME=:MEASNAME");
            OracleParameter[] parameters = {
					new OracleParameter(":FACTID", OracleDbType.Int32,22),
                                          new OracleParameter(":USERID", OracleDbType.Int32,22) ,
                                            new OracleParameter(":MEASNAME", OracleDbType.Varchar2,22)};
            parameters[0].Value = FACTID;
            parameters[1].Value = USERID;
            parameters[2].Value = MEASNAME;
            return DbHelperOra.Exists(strSql.ToString(), parameters);
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.ST_FUZZFUNCT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ST_FUZZFUNCT(");
			strSql.Append("ID,FACTID,UNIT,INFLEXION,FUNCTTYPE,MEASNAME,USERID)");
			strSql.Append(" values (");
			strSql.Append(":ID,:FACTID,:UNIT,:INFLEXION,:FUNCTTYPE,:MEASNAME,:USERID)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,7),
					new OracleParameter(":FACTID", OracleDbType.Int32,7),
					new OracleParameter(":UNIT", OracleDbType.Varchar2,20),
					new OracleParameter(":INFLEXION", OracleDbType.Varchar2,200),
					new OracleParameter(":FUNCTTYPE", OracleDbType.Varchar2,20),
					new OracleParameter(":MEASNAME", OracleDbType.Varchar2,100),
					new OracleParameter(":USERID", OracleDbType.Int32,7)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.FACTID;
			parameters[2].Value = model.UNIT;
			parameters[3].Value = model.INFLEXION;
			parameters[4].Value = model.FUNCTTYPE;
			parameters[5].Value = model.MEASNAME;
			parameters[6].Value = model.USERID;

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
		public bool Update(STBC.Model.ST_FUZZFUNCT model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ST_FUZZFUNCT set ");
			strSql.Append("UNIT=:UNIT,");
			strSql.Append("INFLEXION=:INFLEXION,");
			strSql.Append("FUNCTTYPE=:FUNCTTYPE");
            strSql.Append(" where FACTID=:FACTID and  USERID=:USERID");
			OracleParameter[] parameters = {
					new OracleParameter(":UNIT", OracleDbType.Varchar2,20),
					new OracleParameter(":INFLEXION", OracleDbType.Varchar2,200),
					new OracleParameter(":FUNCTTYPE", OracleDbType.Varchar2,20),
					new OracleParameter(":FACTID", OracleDbType.Int32,7),
					new OracleParameter(":USERID", OracleDbType.Int32,7)};
			parameters[0].Value = model.UNIT;
			parameters[1].Value = model.INFLEXION;
			parameters[2].Value = model.FUNCTTYPE;
            parameters[3].Value = model.FACTID;
			parameters[4].Value = model.USERID;

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
			strSql.Append("delete from ST_FUZZFUNCT ");
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
			strSql.Append("delete from ST_FUZZFUNCT ");
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
		public STBC.Model.ST_FUZZFUNCT GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FACTID,UNIT,INFLEXION,FUNCTTYPE,MEASNAME,USERID from ST_FUZZFUNCT ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

			STBC.Model.ST_FUZZFUNCT model=new STBC.Model.ST_FUZZFUNCT();
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
		public STBC.Model.ST_FUZZFUNCT DataRowToModel(DataRow row)
		{
			STBC.Model.ST_FUZZFUNCT model=new STBC.Model.ST_FUZZFUNCT();
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
				if(row["INFLEXION"]!=null)
				{
					model.INFLEXION=row["INFLEXION"].ToString();
				}
				if(row["FUNCTTYPE"]!=null)
				{
					model.FUNCTTYPE=row["FUNCTTYPE"].ToString();
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
			strSql.Append("select ID,FACTID,UNIT,INFLEXION,FUNCTTYPE,MEASNAME,USERID ");
			strSql.Append(" FROM ST_FUZZFUNCT ");
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
			strSql.Append("select count(1) FROM ST_FUZZFUNCT ");
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
			strSql.Append(")AS Row, T.*  from ST_FUZZFUNCT T ");
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
			parameters[0].Value = "ST_FUZZFUNCT";
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

