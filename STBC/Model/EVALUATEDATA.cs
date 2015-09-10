using System;
namespace STBC.Model
{
	/// <summary>
	/// EVALUATEDATA:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EVALUATEDATA
	{
		public EVALUATEDATA()
		{}
		#region Model
        private decimal _objectid;
        //private decimal _gridfid;
		private decimal _坡度;
		private string _流失强度;
		private decimal _覆盖度;
		private decimal _可供投资;
		private decimal _距道路;
		private decimal _距居民地;
		private string _土地利用;
		private decimal _劳力密度;
		private string _政府决策;
        //private decimal _适宜性得分;
        //private string _适宜性级别;
		private decimal _k;
        //private decimal _经济林果;
        //private decimal _封禁;
        //private decimal _低效林改造;
        //private decimal _生态林草;
		private decimal _综经济林果;
		private decimal _综封禁;
		private decimal _综低效林改;
		private decimal _综生态林;
		private string _适宜性选择;
        //private st_geometry _shape;
	
		/// <summary>
		/// 
		/// </summary>
        public decimal OBJECTID
        {
            set { _objectid = value; }
            get { return _objectid; }
        }
		/// <summary>
		/// 
		/// </summary>
        //public decimal GRIDFID
        //{
        //    set{ _gridfid=value;}
        //    get{return _gridfid;}
        //}
		/// <summary>
		/// 
		/// </summary>
		public decimal 坡度
		{
			set{ _坡度=value;}
			get{return _坡度;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 流失强度
		{
			set{ _流失强度=value;}
			get{return _流失强度;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 覆盖度
		{
			set{ _覆盖度=value;}
			get{return _覆盖度;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 可供投资
		{
			set{ _可供投资=value;}
			get{return _可供投资;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 距道路
		{
			set{ _距道路=value;}
			get{return _距道路;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 距居民地
		{
			set{ _距居民地=value;}
			get{return _距居民地;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 土地利用
		{
			set{ _土地利用=value;}
			get{return _土地利用;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 劳力密度
		{
			set{ _劳力密度=value;}
			get{return _劳力密度;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 政府决策
		{
			set{ _政府决策=value;}
			get{return _政府决策;}
		}
		/// <summary>
		/// 
		/// </summary>
        //public decimal 适宜性得分
        //{
        //    set{ _适宜性得分=value;}
        //    get{return _适宜性得分;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public string 适宜性级别
        //{
        //    set{ _适宜性级别=value;}
        //    get{return _适宜性级别;}
        //}
		/// <summary>
		/// 
		/// </summary>
		public decimal K
		{
			set{ _k=value;}
			get{return _k;}
		}
        ///// <summary>
        ///// 
        ///// </summary>
        //public decimal 经济林果
        //{
        //    set{ _经济林果=value;}
        //    get{return _经济林果;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public decimal 封禁
        //{
        //    set{ _封禁=value;}
        //    get{return _封禁;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public decimal 低效林改造
        //{
        //    set{ _低效林改造=value;}
        //    get{return _低效林改造;}
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        //public decimal 生态林草
        //{
        //    set{ _生态林草=value;}
        //    get{return _生态林草;}
        //}
		/// <summary>
		/// 
		/// </summary>
		public decimal 综经济林果
		{
			set{ _综经济林果=value;}
			get{return _综经济林果;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 综封禁
		{
			set{ _综封禁=value;}
			get{return _综封禁;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 综低效林改
		{
			set{ _综低效林改=value;}
			get{return _综低效林改;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal 综生态林
		{
			set{ _综生态林=value;}
			get{return _综生态林;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string 适宜性选择
		{
			set{ _适宜性选择=value;}
			get{return _适宜性选择;}
		}
		/// <summary>
		/// 
		/// </summary>
        //public st_geometry SHAPE
        //{
        //    set{ _shape=value;}
        //    get{return _shape;}
        //}
	
		#endregion Model

	}
}

