using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_MEASURE:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_MEASURE
	{
		public ST_MEASURE()
		{}
		#region Model
		private decimal _id;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

