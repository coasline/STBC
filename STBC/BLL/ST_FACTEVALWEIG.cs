using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using STBC.Model;
namespace STBC.BLL
{
	/// <summary>
	/// ST_FACTEVALWEIG
	/// </summary>
	public partial class ST_FACTEVALWEIG
	{
		private readonly STBC.DAL.ST_FACTEVALWEIG dal=new STBC.DAL.ST_FACTEVALWEIG();
		public ST_FACTEVALWEIG()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(decimal OWNER, decimal SUITAINDICATOR, string MEASNAME)
		{
            return dal.Exists(OWNER, SUITAINDICATOR, MEASNAME);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(STBC.Model.ST_FACTEVALWEIG model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(STBC.Model.ST_FACTEVALWEIG model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(decimal ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public STBC.Model.ST_FACTEVALWEIG GetModel(decimal ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public STBC.Model.ST_FACTEVALWEIG GetModelByCache(decimal ID)
		{
			
			string CacheKey = "ST_FACTEVALWEIGModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (STBC.Model.ST_FACTEVALWEIG)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}

        /// <summary>
        /// 获得权重列表
        /// </summary>
        public DataSet GetWeightList(int userid)
        {
            return dal.GetWeightList(userid);
        }

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<STBC.Model.ST_FACTEVALWEIG> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<STBC.Model.ST_FACTEVALWEIG> DataTableToList(DataTable dt)
		{
			List<STBC.Model.ST_FACTEVALWEIG> modelList = new List<STBC.Model.ST_FACTEVALWEIG>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				STBC.Model.ST_FACTEVALWEIG model;
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

