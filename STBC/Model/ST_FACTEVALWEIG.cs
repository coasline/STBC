using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_FACTEVALWEIG:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_FACTEVALWEIG
	{
		public ST_FACTEVALWEIG()
		{}
		#region Model
		private decimal _id;
		private decimal? _suitaindicator;
		private decimal? _weight;
		private decimal? _owner;
		private string _measname;
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
		public decimal? SUITAINDICATOR
		{
			set{ _suitaindicator=value;}
			get{return _suitaindicator;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? WEIGHT
		{
			set{ _weight=value;}
			get{return _weight;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? OWNER
		{
			set{ _owner=value;}
			get{return _owner;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MEASNAME
		{
			set{ _measname=value;}
			get{return _measname;}
		}
		#endregion Model

	}
}

