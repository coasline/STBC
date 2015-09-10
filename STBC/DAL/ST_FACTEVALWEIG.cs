using System;
using System.Data;
using System.Text;
using Oracle.DataAccess.Client;
using Maticsoft.DBUtility;//Please add references
namespace STBC.DAL
{
	/// <summary>
	/// 数据访问类:ST_FACTEVALWEIG
	/// </summary>
	public partial class ST_FACTEVALWEIG
	{
		public ST_FACTEVALWEIG()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(decimal OWNER, decimal SUITAINDICATOR, string MEASNAME)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ST_FACTEVALWEIG");
            strSql.Append(" where OWNER=:OWNER and  SUITAINDICATOR=:SUITAINDICATOR and MEASNAME=:MEASNAME");
			OracleParameter[] parameters = {
					new OracleParameter(":OWNER", OracleDbType.Int32,22)	,
                                           new OracleParameter(":SUITAINDICATOR", OracleDbType.Int32,22),
                                            new OracleParameter(":SUITAINDICATOR", OracleDbType.Varchar2,22)};
            parameters[0].Value = OWNER;
            parameters[1].Value = SUITAINDICATOR;
            parameters[2].Value = MEASNAME;
			return DbHelperOra.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.ST_FACTEVALWEIG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ST_FACTEVALWEIG(");
			strSql.Append("ID,SUITAINDICATOR,WEIGHT,OWNER,MEASNAME)");
			strSql.Append(" values (");
			strSql.Append(":ID,:SUITAINDICATOR,:WEIGHT,:OWNER,:MEASNAME)");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,7),
					new OracleParameter(":SUITAINDICATOR", OracleDbType.Int32,2),
					new OracleParameter(":WEIGHT", OracleDbType.Decimal,7),
					new OracleParameter(":OWNER", OracleDbType.Int32,7),
					new OracleParameter(":MEASNAME", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.ID;
			parameters[1].Value = model.SUITAINDICATOR;
			parameters[2].Value = model.WEIGHT;
			parameters[3].Value = model.OWNER;
			parameters[4].Value = model.MEASNAME;

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
		public bool Update(STBC.Model.ST_FACTEVALWEIG model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ST_FACTEVALWEIG set ");
            //strSql.Append("SUITAINDICATOR=:SUITAINDICATOR,");
			strSql.Append("WEIGHT=:WEIGHT");
            //strSql.Append("OWNER=:OWNER,");
            //strSql.Append("MEASNAME=:MEASNAME");
            strSql.Append(" where OWNER=:OWNER and SUITAINDICATOR=:SUITAINDICATOR and MEASNAME=:MEASNAME");
			OracleParameter[] parameters = {
					new OracleParameter(":WEIGHT", OracleDbType.Decimal,7),
					new OracleParameter(":OWNER", OracleDbType.Int32,7),
                    new OracleParameter(":SUITAINDICATOR", OracleDbType.Int32,2),
					new OracleParameter(":MEASNAME", OracleDbType.Varchar2,100)};
			parameters[0].Value = model.WEIGHT;
			parameters[1].Value = model.OWNER;
			parameters[2].Value = model.SUITAINDICATOR;
			parameters[3].Value = model.MEASNAME;

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
			strSql.Append("delete from ST_FACTEVALWEIG ");
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
			strSql.Append("delete from ST_FACTEVALWEIG ");
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
		public STBC.Model.ST_FACTEVALWEIG GetModel(decimal ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,SUITAINDICATOR,WEIGHT,OWNER,MEASNAME from ST_FACTEVALWEIG ");
			strSql.Append(" where ID=:ID ");
			OracleParameter[] parameters = {
					new OracleParameter(":ID", OracleDbType.Int32,22)			};
			parameters[0].Value = ID;

			STBC.Model.ST_FACTEVALWEIG model=new STBC.Model.ST_FACTEVALWEIG();
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
		public STBC.Model.ST_FACTEVALWEIG DataRowToModel(DataRow row)
		{
			STBC.Model.ST_FACTEVALWEIG model=new STBC.Model.ST_FACTEVALWEIG();
			if (row != null)
			{
				if(row["ID"]!=null && row["ID"].ToString()!="")
				{
					model.ID=decimal.Parse(row["ID"].ToString());
				}
				if(row["SUITAINDICATOR"]!=null && row["SUITAINDICATOR"].ToString()!="")
				{
					model.SUITAINDICATOR=decimal.Parse(row["SUITAINDICATOR"].ToString());
				}
				if(row["WEIGHT"]!=null && row["WEIGHT"].ToString()!="")
				{
					model.WEIGHT=decimal.Parse(row["WEIGHT"].ToString());
				}
				if(row["OWNER"]!=null && row["OWNER"].ToString()!="")
				{
					model.OWNER=decimal.Parse(row["OWNER"].ToString());
				}
				if(row["MEASNAME"]!=null)
				{
					model.MEASNAME=row["MEASNAME"].ToString();
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
			strSql.Append("select ID,SUITAINDICATOR,WEIGHT,OWNER,MEASNAME ");
			strSql.Append(" FROM ST_FACTEVALWEIG ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOra.Query(strSql.ToString());
		}
        /// <summary>
        /// 获得权重的列表
        /// </summary>
        public DataSet GetWeightList(int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ST_FACTEVALWEIG.weight ");
            strSql.Append(" from ST_FACTDIR,ST_FACTEVALWEIG ");
            //因为效益权重不分措施，不用修改下面字符串 -ST_FACTEVALWEIG.MEASNAME='经济林果'
            strSql.Append(" where ST_FACTDIR.id=ST_FACTEVALWEIG.SUITAINDICATOR and  ST_FACTDIR.Parent=13 and ST_FACTEVALWEIG.MEASNAME='经济林果' and ST_FACTEVALWEIG.OWNER=" + userid);
            return DbHelperOra.Query(strSql.ToString());
        }

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ST_FACTEVALWEIG ");
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
			strSql.Append(")AS Row, T.*  from ST_FACTEVALWEIG T ");
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
			parameters[0].Value = "ST_FACTEVALWEIG";
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

