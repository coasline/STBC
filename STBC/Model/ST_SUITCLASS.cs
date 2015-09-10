using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_SUITCLASS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_SUITCLASS
	{
		public ST_SUITCLASS()
		{}
		#region Model
		private decimal _id;
		private string _name;
		private string _code;
		private decimal? _ceiling;
		private decimal? _floor;
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
		public string NAME
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CODE
		{
			set{ _code=value;}
			get{return _code;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? CEILING
		{
			set{ _ceiling=value;}
			get{return _ceiling;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FLOOR
		{
			set{ _floor=value;}
			get{return _floor;}
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

