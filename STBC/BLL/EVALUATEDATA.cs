using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using STBC.Model;
namespace STBC.BLL
{
	/// <summary>
	/// EVALUATEDATA
	/// </summary>
	public partial class EVALUATEDATA
	{
		private readonly STBC.DAL.EVALUATEDATA dal=new STBC.DAL.EVALUATEDATA();
		public EVALUATEDATA()
		{}
		#region  BasicMethod

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.EVALUATEDATA model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(STBC.Model.EVALUATEDATA model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 汇总计算单项措施适宜性评价
        /// </summary>
        /// <param name="model">模型</param>
        /// <param name="strMeasure">措施名字</param>
        /// <param name="zong">单项因子计算总结果</param>
        /// <returns></returns>
        public bool UpdateSummary(STBC.Model.EVALUATEDATA model, string strMeasure, double zong)
        {
            return dal.UpdateSummary(model, strMeasure, zong);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.Delete();
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public STBC.Model.EVALUATEDATA GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			return dal.GetModel();
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public STBC.Model.EVALUATEDATA GetModelByCache()
		{
			//该表无主键信息，请自定义主键/条件字段
			string CacheKey = "EVALUATEDATAModel-" ;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel();
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (STBC.Model.EVALUATEDATA)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得因子、权重、拐点条件三张表的拼接表
        /// </summary>
        public DataSet GetConnect(string strMeasure, int userid)
        {
            return dal.GetConnect(strMeasure, userid);
        }
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<STBC.Model.EVALUATEDATA> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<STBC.Model.EVALUATEDATA> DataTableToList(DataTable dt)
		{
			List<STBC.Model.EVALUATEDATA> modelList = new List<STBC.Model.EVALUATEDATA>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				STBC.Model.EVALUATEDATA model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

