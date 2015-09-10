using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_FACTDIR:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_FACTDIR
	{
		public ST_FACTDIR()
		{}
		#region Model
		private decimal _id;
		private string _name;
		private decimal? _parent;
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
		/// <summary>
		/// 
		/// </summary>
		public decimal? PARENT
		{
			set{ _parent=value;}
			get{return _parent;}
		}
		#endregion Model

	}
}

