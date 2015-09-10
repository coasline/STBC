using System;
namespace STBC.Model
{
	/// <summary>
	/// ST_USERS:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ST_USERS
	{
		public ST_USERS()
		{}
		#region Model
		private decimal _userid;
		private string _username;
		private string _usersex;
		private string _levelname;
		private string _usertrade;
		private string _usercompany;
		private string _userposition;
		private string _userresearch_fields;
		private string _psw;
		private string _photo;
		/// <summary>
		/// 
		/// </summary>
		public decimal USERID
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERNAME
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERSEX
		{
			set{ _usersex=value;}
			get{return _usersex;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LEVELNAME
		{
			set{ _levelname=value;}
			get{return _levelname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERTRADE
		{
			set{ _usertrade=value;}
			get{return _usertrade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERCOMPANY
		{
			set{ _usercompany=value;}
			get{return _usercompany;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERPOSITION
		{
			set{ _userposition=value;}
			get{return _userposition;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string USERRESEARCH_FIELDS
		{
			set{ _userresearch_fields=value;}
			get{return _userresearch_fields;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PSW
		{
			set{ _psw=value;}
			get{return _psw;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PHOTO
		{
			set{ _photo=value;}
			get{return _photo;}
		}
		#endregion Model

	}
}

