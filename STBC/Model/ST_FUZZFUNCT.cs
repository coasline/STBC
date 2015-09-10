using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_FUZZFUNCT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_FUZZFUNCT
	{
		public ST_FUZZFUNCT()
		{}
		#region Model
		private decimal _id;
		private decimal? _factid;
		private string _unit;
		private string _inflexion;
		private string _functtype;
		private string _measname;
		private decimal? _userid;
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
		public decimal? FACTID
		{
			set{ _factid=value;}
			get{return _factid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UNIT
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string INFLEXION
		{
			set{ _inflexion=value;}
			get{return _inflexion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FUNCTTYPE
		{
			set{ _functtype=value;}
			get{return _functtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MEASNAME
		{
			set{ _measname=value;}
			get{return _measname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		#endregion Model

	}
}

