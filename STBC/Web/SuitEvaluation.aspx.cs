using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web
{
    public partial class SuitEvaluation : System.Web.UI.Page, ICallbackEventHandler
    {
        //存放全局的目录、权重、限制条件的三张表的拼接表
        private static DataTable dtw;

        //获得效益权重值
        private static List<string> lsBenWeight = new List<string>();

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        //用来存执行状态
        private string CallBackValue = string.Empty;
        string ICallbackEventHandler.GetCallbackResult()
        {
            return CallBackValue;
        }
        /// <summary>
        /// javascript传入后台调用的方法
        /// </summary>
        /// <param name="eventArgument">js传进来的选择值</param>
        void ICallbackEventHandler.RaiseCallbackEvent(string eventArgument)
        {
            //this.CallBackValue = eventArgument;
            getBenWeigtList();
            getFactWeight(eventArgument);
            calcuFanallyWeight(eventArgument);

        }
        //获得效益权重列表
        public void getBenWeigtList()
        {
            //获得用户id
            int userid = CommonClass.OperateUsers.getUserID();
            STBC.BLL.ST_FACTEVALWEIG factevalweigB = new STBC.BLL.ST_FACTEVALWEIG();
            DataSet ds = factevalweigB.GetWeightList(userid);
            DataTable dt = ds.Tables[0];
            lsBenWeight.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lsBenWeight.Add(dr["weight"].ToString());
            }
        }
        //拼接对应的目录、权重、限制条件的三张表,strMeasure为措施字符串
        protected void getFactWeight(string strMeasure)
        {
            //获得用户id
            int userid = CommonClass.OperateUsers.getUserID();
            STBC.BLL.EVALUATEDATA evaluatedataB = new STBC.BLL.EVALUATEDATA();
            //根据措施名字和用户id查询目录、权重、限制条件的三张表中数据并进行拼接
            DataSet ds = evaluatedataB.GetConnect(strMeasure, userid);
            dtw = ds.Tables[0];
        }
        /// <summary>
        /// 计算权重，并插入到evaluatedata这张表里面
        /// </summary>
        /// <param name="strMeasure">传入的措施</param>
        protected void calcuFanallyWeight(string strMeasure)
        {
            STBC.BLL.EVALUATEDATA evaluatedataB = new STBC.BLL.EVALUATEDATA();
            STBC.Model.EVALUATEDATA evaluatedataM = new STBC.Model.EVALUATEDATA();
            DataSet ds = evaluatedataB.GetList("");
            DataTable dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                //处理相关数据
                double laoli = double.Parse(dr["劳力密度"].ToString().Trim());
                string zhenfu = dr["政府决策"].ToString().Trim();
                double zhengfud = 0.0;
                double touzi = double.Parse(dr["可供投资"].ToString().Trim());
                double judao = double.Parse(dr["距道路"].ToString().Trim());
                double juJu = double.Parse(dr["距居民地"].ToString().Trim());
                string liushi = dr["流失强度"].ToString().Trim();
                double liushid = 0.0;
                double kyin = double.Parse(dr["K"].ToString().Trim());
                double podu = double.Parse(dr["坡度"].ToString().Trim());
                double fugai = double.Parse(dr["覆盖度"].ToString().Trim());
                string tudiliyong = dr["土地利用"].ToString().Trim();
                double tudiliyongd = 0.0;

                //首先处理坡度
                foreach (DataRow dr2 in dtw.Rows)
                {
                    #region 计算过程
                    //存放因子名字
                    string factName = dr2["NAME"].ToString();
                    //存放因子权重
                    double WEIGHT = double.Parse(dr2["WEIGHT"].ToString());

                    //存放因子拐点设置
                    string INFLEXION = dr2["INFLEXION"].ToString();
                    //存放因子拐点函数类型
                    string FUNCTTYPE = dr2["FUNCTTYPE"].ToString();
                    string[] strarr = INFLEXION.Split('|');
                    if (factName == "农村劳动力密度")
                    {

                        //if (FUNCTTYPE=="特征函数")
                        //{
                        //    laoli=CommonClass.SingEvalMethod.EigenFunct(strarr,lao
                        //}
                        if (FUNCTTYPE == "升半梯形")
                        {
                            laoli = CommonClass.SingEvalMethod.RiseTrap(strarr, laoli);
                            laoli = laoli * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            laoli = CommonClass.SingEvalMethod.DropTrap(strarr, laoli);
                            laoli = laoli * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            laoli = CommonClass.SingEvalMethod.Parabola(strarr, laoli);
                            laoli = laoli * WEIGHT;
                        }
                    }
                    else if (factName == "政府决策因素")
                    {
                        //不用选择，这个坑定是特征函数
                        zhengfud = CommonClass.SingEvalMethod.EigenFunct(strarr, zhenfu);
                        zhengfud = zhengfud * WEIGHT;
                    }
                    else if (factName == "建设需求投资")
                    {
                        if (FUNCTTYPE == "升半梯形")
                        {

                            touzi = CommonClass.SingEvalMethod.RiseTrap(strarr, touzi);
                            touzi = touzi * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            touzi = CommonClass.SingEvalMethod.DropTrap(strarr, touzi);
                            touzi = touzi * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            touzi = CommonClass.SingEvalMethod.Parabola(strarr, touzi);
                            touzi = touzi * WEIGHT;
                        }
                    }
                    else if (factName == "距道路距离")
                    {
                        //dr["距道路"].ToString();
                        if (FUNCTTYPE == "升半梯形")
                        {

                            judao = CommonClass.SingEvalMethod.RiseTrap(strarr, judao);
                            judao = judao * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            judao = CommonClass.SingEvalMethod.DropTrap(strarr, judao);
                            judao = judao * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            judao = CommonClass.SingEvalMethod.Parabola(strarr, judao);
                            judao = judao * WEIGHT;
                        }
                    }
                    else if (factName == "距居民点距离")
                    {
                        //dr["距居民地"].ToString();

                        if (FUNCTTYPE == "升半梯形")
                        {

                            juJu = CommonClass.SingEvalMethod.RiseTrap(strarr, juJu);
                            juJu = juJu * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            juJu = CommonClass.SingEvalMethod.DropTrap(strarr, juJu);
                            juJu = juJu * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            juJu = CommonClass.SingEvalMethod.Parabola(strarr, juJu);
                            juJu = juJu * WEIGHT;
                        }
                    }
                    else if (factName == "水土流失强度")
                    {
                        //dr["流失强度"].ToString();
                        liushid = CommonClass.SingEvalMethod.EigenFunct(strarr, liushi);
                        liushid = liushid * WEIGHT;
                    }
                    else if (factName == "土壤可蚀因子")
                    {
                        //dr["K"].ToString();
                        if (FUNCTTYPE == "升半梯形")
                        {

                            kyin = CommonClass.SingEvalMethod.RiseTrap(strarr, kyin);
                            kyin = kyin * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            kyin = CommonClass.SingEvalMethod.DropTrap(strarr, kyin);
                            kyin = kyin * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            kyin = CommonClass.SingEvalMethod.Parabola(strarr, kyin);
                            kyin = kyin * WEIGHT;
                        }
                    }
                    else if (factName == "坡度")
                    {
                        //dr["坡度"].ToString();
                        if (FUNCTTYPE == "升半梯形")
                        {

                            podu = CommonClass.SingEvalMethod.RiseTrap(strarr, podu);
                            podu = podu * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            podu = CommonClass.SingEvalMethod.DropTrap(strarr, podu);
                            podu = podu * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            podu = CommonClass.SingEvalMethod.Parabola(strarr, podu);
                            podu = podu * WEIGHT;
                        }
                    }
                    else if (factName == "植被覆盖")
                    {
                        //dr["覆盖度"].ToString();
                        if (FUNCTTYPE == "升半梯形")
                        {

                            fugai = CommonClass.SingEvalMethod.RiseTrap(strarr, fugai);
                            fugai = fugai * WEIGHT;
                        }
                        else if (FUNCTTYPE == "降半梯形")
                        {
                            fugai = CommonClass.SingEvalMethod.DropTrap(strarr, fugai);
                            fugai = fugai * WEIGHT;
                        }
                        //抛物线型
                        else
                        {
                            fugai = CommonClass.SingEvalMethod.Parabola(strarr, fugai);
                            fugai = fugai * WEIGHT;
                        }
                    }
                    //土地利用现状
                    else
                    {
                        tudiliyongd = CommonClass.SingEvalMethod.EigenFunct(strarr, tudiliyong);
                        tudiliyongd = tudiliyongd * WEIGHT;
                    }
                    #endregion
                }
                //zong1为适宜性评价的综合
                double zong1 = laoli + zhengfud + touzi + judao + juJu + liushid + kyin + podu + fugai + tudiliyongd;
                //zong2为效益型评价的综合
                double zong2 = CommonClass.BenFactHelp.GetBenWeight(lsBenWeight, strMeasure);
                //总的适宜性评价
                double zong = Math.Sqrt(zong1 * zong2);
                //evaluatedataM.经济林果 = (decimal)zong1;
                evaluatedataM.OBJECTID = (decimal)double.Parse(dr["OBJECTID"].ToString().Trim());
                evaluatedataB.UpdateSummary(evaluatedataM, strMeasure, zong);


            }

            CallBackValue = "单项措施计算成功";
            //this.GridView1.DataSource = ds.Tables[0].DefaultView;
            //this.GridView1.DataBind();
        }
    }
}