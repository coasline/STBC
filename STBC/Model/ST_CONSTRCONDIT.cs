using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_CONSTRCONDIT:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_CONSTRCONDIT
	{
		public ST_CONSTRCONDIT()
		{}
		#region Model
		private decimal _id;
		private decimal? _factid;
		private string _unit;
		private string _symboltype;
		private string _limcondit;
		private string _facttype;
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
		public string SYMBOLTYPE
		{
			set{ _symboltype=value;}
			get{return _symboltype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LIMCONDIT
		{
			set{ _limcondit=value;}
			get{return _limcondit;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FACTTYPE
		{
			set{ _facttype=value;}
			get{return _facttype;}
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

