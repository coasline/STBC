using System;
using System.Data;
using System.Text;
//using System.Data.OracleClient;
using Oracle.DataAccess.Client;
using Maticsoft.DBUtility;//Please add references
namespace STBC.DAL
{
    /// <summary>
    /// 数据访问类:EVALUATEDATA
    /// </summary>
    public partial class EVALUATEDATA
    {
        public EVALUATEDATA()
        { }
        #region  BasicMethod



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(STBC.Model.EVALUATEDATA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EVALUATEDATA(");
            strSql.Append("坡度,流失强度,覆盖度,可供投资,距道路,距居民地,土地利用,劳力密度,政府决策,K,综经济林果,综封禁,综低效林改,综生态林,适宜性选择)");
            strSql.Append(" values (");
            strSql.Append(":坡度,:流失强度,:覆盖度,:可供投资,:距道路,:距居民地,:土地利用,:劳力密度,:政府决策,:K:综经济林果,:综封禁,:综低效林改,:综生态林,:适宜性选择)");
            OracleParameter[] parameters = {
					new OracleParameter(":坡度", OracleDbType.Decimal,38),
					new OracleParameter(":流失强度", OracleDbType.NVarchar2),
					new OracleParameter(":覆盖度", OracleDbType.Decimal,38),
					new OracleParameter(":可供投资", OracleDbType.Decimal,38),
					new OracleParameter(":距道路", OracleDbType.Decimal,38),
					new OracleParameter(":距居民地", OracleDbType.Decimal,38),
					new OracleParameter(":土地利用", OracleDbType.NVarchar2),
					new OracleParameter(":劳力密度", OracleDbType.Decimal,38),
					new OracleParameter(":政府决策", OracleDbType.NVarchar2),
					new OracleParameter(":K", OracleDbType.Decimal,15),
					new OracleParameter(":综经济林果", OracleDbType.Decimal,38),
					new OracleParameter(":综封禁", OracleDbType.Decimal,38),
					new OracleParameter(":综低效林改", OracleDbType.Decimal,38),
					new OracleParameter(":综生态林", OracleDbType.Decimal,38),
					new OracleParameter(":适宜性选择", OracleDbType.NVarchar2)};
            parameters[0].Value = model.坡度;
            parameters[1].Value = model.流失强度;
            parameters[2].Value = model.覆盖度;
            parameters[3].Value = model.可供投资;
            parameters[4].Value = model.距道路;
            parameters[5].Value = model.距居民地;
            parameters[6].Value = model.土地利用;
            parameters[7].Value = model.劳力密度;
            parameters[8].Value = model.政府决策;
            parameters[9].Value = model.K;
            parameters[10].Value = model.综经济林果;
            parameters[11].Value = model.综封禁;
            parameters[12].Value = model.综低效林改;
            parameters[13].Value = model.综生态林;
            parameters[14].Value = model.适宜性选择;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Update(STBC.Model.EVALUATEDATA model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EVALUATEDATA set ");
            strSql.Append("坡度=:坡度,");
            strSql.Append("流失强度=:流失强度,");
            strSql.Append("覆盖度=:覆盖度,");
            strSql.Append("可供投资=:可供投资,");
            strSql.Append("距道路=:距道路,");
            strSql.Append("距居民地=:距居民地,");
            strSql.Append("土地利用=:土地利用,");
            strSql.Append("劳力密度=:劳力密度,");
            strSql.Append("政府决策=:政府决策,");
            strSql.Append("K=:K,");
            strSql.Append("综经济林果=:综经济林果,");
            strSql.Append("综封禁=:综封禁,");
            strSql.Append("综低效林改=:综低效林改,");
            strSql.Append("综生态林=:综生态林,");
            strSql.Append("适宜性选择=:适宜性选择");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
					new OracleParameter(":坡度", OracleDbType.Decimal,38),
					new OracleParameter(":流失强度", OracleDbType.NVarchar2),
					new OracleParameter(":覆盖度", OracleDbType.Decimal,38),
					new OracleParameter(":可供投资", OracleDbType.Decimal,38),
					new OracleParameter(":距道路", OracleDbType.Decimal,38),
					new OracleParameter(":距居民地", OracleDbType.Decimal,38),
					new OracleParameter(":土地利用", OracleDbType.NVarchar2),
					new OracleParameter(":劳力密度", OracleDbType.Decimal,38),
					new OracleParameter(":政府决策", OracleDbType.NVarchar2),
					new OracleParameter(":K", OracleDbType.Decimal,15),
					new OracleParameter(":综经济林果", OracleDbType.Decimal,38),
					new OracleParameter(":综封禁", OracleDbType.Decimal,38),
					new OracleParameter(":综低效林改", OracleDbType.Decimal,38),
					new OracleParameter(":综生态林", OracleDbType.Decimal,38),
					new OracleParameter(":适宜性选择", OracleDbType.NVarchar2)};
            parameters[0].Value = model.坡度;
            parameters[1].Value = model.流失强度;
            parameters[2].Value = model.覆盖度;
            parameters[3].Value = model.可供投资;
            parameters[4].Value = model.距道路;
            parameters[5].Value = model.距居民地;
            parameters[6].Value = model.土地利用;
            parameters[7].Value = model.劳力密度;
            parameters[8].Value = model.政府决策;
            parameters[9].Value = model.K;
            parameters[10].Value = model.综经济林果;
            parameters[11].Value = model.综封禁;
            parameters[12].Value = model.综低效林改;
            parameters[13].Value = model.综生态林;
            parameters[14].Value = model.适宜性选择;
            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新经济林果适宜性评价值
        /// </summary>
        public bool UpdateSummary(STBC.Model.EVALUATEDATA model, string strMeasure, double zong)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EVALUATEDATA set ");
            int rows = 0;
            if (strMeasure == "经济林果")
            {
                strSql.Append("综经济林果=:综经济林果");
                strSql.Append(" where OBJECTID=:OBJECTID");
                OracleParameter[] parameters = {
					new OracleParameter(":综经济林果", OracleDbType.Decimal,38),
                    new OracleParameter(":OBJECTID", OracleDbType.Decimal,4),
                                           };
                parameters[0].Value = (decimal)zong;
                parameters[1].Value = model.OBJECTID;
                rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);

            }
            else if (strMeasure == "低效林改造")
            {
                strSql.Append("综低效林改=:综低效林改");
                strSql.Append(" where OBJECTID=:OBJECTID");
                OracleParameter[] parameters = {
					new OracleParameter(":综低效林改", OracleDbType.Decimal,38),
                    new OracleParameter(":OBJECTID", OracleDbType.Decimal,4),
                                           };
                parameters[0].Value = (decimal)zong;
                parameters[1].Value = model.OBJECTID;
                rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
            }
            else if (strMeasure == "封禁")
            {
                strSql.Append("综封禁=:综封禁");
                strSql.Append(" where OBJECTID=:OBJECTID");
                OracleParameter[] parameters = {
					new OracleParameter(":综封禁", OracleDbType.Decimal,38),
                    new OracleParameter(":OBJECTID", OracleDbType.Decimal,4),
                                           };
                parameters[0].Value = (decimal)zong;
                parameters[1].Value = model.OBJECTID;
                rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);

            }
            //生态林草
            else
            {
                strSql.Append("综生态林=:综生态林");
                strSql.Append(" where OBJECTID=:OBJECTID");
                OracleParameter[] parameters = {
					new OracleParameter(":综生态林", OracleDbType.Decimal,38),
                    new OracleParameter(":OBJECTID", OracleDbType.Decimal,4),
                                           };
                parameters[0].Value = (decimal)zong;
                parameters[1].Value = model.OBJECTID;
                rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);

            }
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
        public bool Delete()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EVALUATEDATA ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
			};

            int rows = DbHelperOra.ExecuteSql(strSql.ToString(), parameters);
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
        public STBC.Model.EVALUATEDATA GetModel()
        {
            //该表无主键信息，请自定义主键/条件字段
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OBJECTID,GRIDFID,坡度,流失强度,覆盖度,可供投资,距道路,距居民地,土地利用,劳力密度,政府决策,适宜性得分,适宜性级别,K,经济林果,封禁,低效林改造,生态林草,综经济林果,综封禁,综低效林改,综生态林,适宜性选择,SHAPE,经林等级,封禁等级,低林等级,生林等级 from EVALUATEDATA ");
            strSql.Append(" where ");
            OracleParameter[] parameters = {
			};

            STBC.Model.EVALUATEDATA model = new STBC.Model.EVALUATEDATA();
            DataSet ds = DbHelperOra.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
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
        public STBC.Model.EVALUATEDATA DataRowToModel(DataRow row)
        {
            STBC.Model.EVALUATEDATA model = new STBC.Model.EVALUATEDATA();
            if (row != null)
            {
                //if(row["OBJECTID"]!=null && row["OBJECTID"].ToString()!="")
                //{
                //    model.OBJECTID=decimal.Parse(row["OBJECTID"].ToString());
                //}
                //if(row["GRIDFID"]!=null && row["GRIDFID"].ToString()!="")
                //{
                //    model.GRIDFID=decimal.Parse(row["GRIDFID"].ToString());
                //}
                if (row["坡度"] != null && row["坡度"].ToString() != "")
                {
                    model.坡度 = decimal.Parse(row["坡度"].ToString());
                }
                if (row["流失强度"] != null)
                {
                    model.流失强度 = row["流失强度"].ToString();
                }
                if (row["覆盖度"] != null && row["覆盖度"].ToString() != "")
                {
                    model.覆盖度 = decimal.Parse(row["覆盖度"].ToString());
                }
                if (row["可供投资"] != null && row["可供投资"].ToString() != "")
                {
                    model.可供投资 = decimal.Parse(row["可供投资"].ToString());
                }
                if (row["距道路"] != null && row["距道路"].ToString() != "")
                {
                    model.距道路 = decimal.Parse(row["距道路"].ToString());
                }
                if (row["距居民地"] != null && row["距居民地"].ToString() != "")
                {
                    model.距居民地 = decimal.Parse(row["距居民地"].ToString());
                }
                if (row["土地利用"] != null)
                {
                    model.土地利用 = row["土地利用"].ToString();
                }
                if (row["劳力密度"] != null && row["劳力密度"].ToString() != "")
                {
                    model.劳力密度 = decimal.Parse(row["劳力密度"].ToString());
                }
                if (row["政府决策"] != null)
                {
                    model.政府决策 = row["政府决策"].ToString();
                }
                //if(row["适宜性得分"]!=null && row["适宜性得分"].ToString()!="")
                //{
                //    model.适宜性得分=decimal.Parse(row["适宜性得分"].ToString());
                //}
                //if(row["适宜性级别"]!=null)
                //{
                //    model.适宜性级别=row["适宜性级别"].ToString();
                //}
                if (row["K"] != null && row["K"].ToString() != "")
                {
                    model.K = decimal.Parse(row["K"].ToString());
                }
                //if (row["经济林果"] != null && row["经济林果"].ToString() != "")
                //{
                //    model.经济林果 = decimal.Parse(row["经济林果"].ToString());
                //}
                //if (row["封禁"] != null && row["封禁"].ToString() != "")
                //{
                //    model.封禁 = decimal.Parse(row["封禁"].ToString());
                //}
                //if (row["低效林改造"] != null && row["低效林改造"].ToString() != "")
                //{
                //    model.低效林改造 = decimal.Parse(row["低效林改造"].ToString());
                //}
                //if (row["生态林草"] != null && row["生态林草"].ToString() != "")
                //{
                //    model.生态林草 = decimal.Parse(row["生态林草"].ToString());
                //}
                if (row["综经济林果"] != null && row["综经济林果"].ToString() != "")
                {
                    model.综经济林果 = decimal.Parse(row["综经济林果"].ToString());
                }
                if (row["综封禁"] != null && row["综封禁"].ToString() != "")
                {
                    model.综封禁 = decimal.Parse(row["综封禁"].ToString());
                }
                if (row["综低效林改"] != null && row["综低效林改"].ToString() != "")
                {
                    model.综低效林改 = decimal.Parse(row["综低效林改"].ToString());
                }
                if (row["综生态林"] != null && row["综生态林"].ToString() != "")
                {
                    model.综生态林 = decimal.Parse(row["综生态林"].ToString());
                }
                if (row["适宜性选择"] != null)
                {
                    model.适宜性选择 = row["适宜性选择"].ToString();
                }
                //model.SHAPE=row["SHAPE"].ToString();
                //if (row["经林等级"] != null)
                //{
                //    model.经林等级 = row["经林等级"].ToString();
                //}
                //if (row["封禁等级"] != null)
                //{
                //    model.封禁等级 = row["封禁等级"].ToString();
                //}
                //if (row["低林等级"] != null)
                //{
                //    model.低林等级 = row["低林等级"].ToString();
                //}
                //if (row["生林等级"] != null)
                //{
                //    model.生林等级 = row["生林等级"].ToString();
                //}
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select OBJECTID,坡度,流失强度,覆盖度,可供投资,距道路,距居民地,土地利用,劳力密度,政府决策,K");
            strSql.Append(" FROM EVALUATEDATA ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperOra.Query(strSql.ToString());
        }

        /// <summary>
        ///  获得因子、权重、拐点条件三张表的拼接表
        /// </summary>
        public DataSet GetConnect(string strMeasure,int userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ST_FACTDIR.name,ST_FACTEVALWEIG.weight,ST_FUZZFUNCT.INFLEXION,ST_FUZZFUNCT.FUNCTTYPE from ST_FACTDIR,ST_FACTEVALWEIG,ST_FUZZFUNCT where ST_FACTDIR.id=ST_FACTEVALWEIG.SUITAINDICATOR and ST_FACTDIR.id=ST_FUZZFUNCT.factid and ST_FACTEVALWEIG.OWNER=" + userid + " and ST_FUZZFUNCT.USERID=" + userid );
            //strSql.Append(" FROM EVALUATEDATA ");
            if (strMeasure.Trim() != "")
            {
                //and ST_FACTEVALWEIG.MEASNAME='经济林果' and ST_FUZZFUNCT.MEASNAME='经济林果';
                strSql.Append(" and ST_FACTEVALWEIG.MEASNAME= '" + strMeasure + "'and ST_FUZZFUNCT.MEASNAME='" + strMeasure + "'");
            }
            return DbHelperOra.Query(strSql.ToString());
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM EVALUATEDATA ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T. desc");
            }
            strSql.Append(")AS Row, T.*  from EVALUATEDATA T ");
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
                    new OracleParameter(":tblName", OracleType.VarChar, 255),
                    new OracleParameter(":fldName", OracleType.VarChar, 255),
                    new OracleParameter(":PageSize", OracleDbType.Decimal),
                    new OracleParameter(":PageIndex", OracleDbType.Decimal),
                    new OracleParameter(":IsReCount", OracleType.Clob),
                    new OracleParameter(":OrderType", OracleType.Clob),
                    new OracleParameter(":strWhere", OracleType.VarChar,1000),
                    };
            parameters[0].Value = "EVALUATEDATA";
            parameters[1].Value = "";
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

