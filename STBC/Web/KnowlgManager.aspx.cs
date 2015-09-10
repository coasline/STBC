using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Web
{
    public partial class KnowlgManager : System.Web.UI.Page
    {
        //存放效益矩阵字段名字数据
        private static List<string> lsBenName = new List<string>();

        //存放适宜性 中社会因子和 自然条件 对应的因子名字
        private static List<string> lsSuitName = new List<string>();
        private static List<string> lsSuitName2 = new List<string>();
        private static List<string> lsSuitName3 = new List<string>();

        //存放模糊函数的列名
        private static List<string> lsFuzzName = new List<string>();
        //存放模糊函数的列名
        private static List<string> lsLimitName = new List<string>();

        //存放效益矩阵，效益矩阵是4*4
        protected Double[,] benData = new Double[4, 4];

        //存放适宜性矩阵，适宜性矩阵是2*2
        protected Double[,] suitData = new Double[2, 2];

        //存放适宜性矩阵社会因子，矩阵大小为5*5
        protected Double[,] suitData2 = new Double[5, 5];

        //存放适宜性矩阵自然因子，矩阵大小为5*5
        protected Double[,] suitData3 = new Double[5, 5];

        //效益权重的存储
        private static double[,] resultBenefit = null;
        //适宜性权重的存储1
        private static double[,] resultSuit1 = null;
        private static double[,] resultSuit2 = null;
        private static double[,] resultSuit3 = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetBenName();
                GetSuitName();
                getFuzzfuntionName();
                getLimcondName();

            }

        }
        //获取效益矩阵字段名字数据，并将对应gridview中的第一列数据进行赋值
        protected void GetBenName()
        {
            STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
            DataSet ds = factdirB.GetList("parent=13");
            DataTable dt = ds.Tables[0];
            lsBenName.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                lsBenName.Add(dr["Name"].ToString());

            }
            this.BenefitGrid.DataSource = dt.DefaultView;
            this.BenefitGrid.DataBind();
        }

        //获取适宜性字段名数据，并将对应相关gridview中的第一列数据
        protected void GetSuitName()
        {
            #region 获取适宜性字段名数据，并将对应相关gridview中的第一列数据
            STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
            DataSet ds = factdirB.GetList("ID!=0 and ID!=13 and parent=0");
            DataTable dt = ds.Tables[0];
            //清空lsSuitName
            lsSuitName.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                lsSuitName.Add(dr["Name"].ToString());

            }
            //将表中的Name显示到SuitfactGrid中
            this.SuitfactGrid.DataSource = dt.DefaultView;
            this.SuitfactGrid.DataBind();

            //社会因子 设置
            DataSet ds2 = factdirB.GetList("ID!=0 and parent=1");
            DataTable dt2 = ds2.Tables[0];
            lsSuitName2.Clear();
            foreach (DataRow dr in dt2.Rows)
            {

                lsSuitName2.Add(dr["Name"].ToString());


            }
            this.SuitfactGrid2.DataSource = dt2.DefaultView;
            this.SuitfactGrid2.DataBind();


            //自然因子设置
            DataSet ds3 = factdirB.GetList("ID!=0 and parent=2");
            DataTable dt3 = ds3.Tables[0];
            lsSuitName3.Clear();
            foreach (DataRow dr in dt3.Rows)
            {

                lsSuitName3.Add(dr["Name"].ToString());


            }
            this.SuitfactGrid3.DataSource = dt3.DefaultView;
            this.SuitfactGrid3.DataBind();
            #endregion

        }

        //获取模糊函数第一列的名字：
        protected void getFuzzfuntionName()
        {
            //STBC.BLL.SUITAINDICATOR benefitindicatorB = new STBC.BLL.SUITAINDICATOR();
            STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
            DataSet ds = factdirB.GetList("parent=1 or parent =2");
            DataTable dt = ds.Tables[0];
            lsFuzzName.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                lsFuzzName.Add(dr["Name"].ToString());

            }
            this.FuzzfunctGrid.DataSource = ds.Tables[0].DefaultView;
            this.FuzzfunctGrid.DataBind();

        }

        //获取限制条件第一列的名字
        protected void getLimcondName()
        {
            #region 获取限制条件第一列的名字,并赋值给lsLimitName存储
            STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
            DataSet ds = factdirB.GetList("parent=1 or parent =2");
            DataTable dt = ds.Tables[0];
            lsLimitName.Clear();
            foreach (DataRow dr in dt.Rows)
            {

                lsLimitName.Add(dr["Name"].ToString());

            }
            this.LimcondGrid.DataSource = ds.Tables[0].DefaultView;
            this.LimcondGrid.DataBind();
            #endregion
        }

        // 效益型性目标矩阵表头设置
        protected void BenefitGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            #region 给效益矩阵表头赋值
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    //总表头
                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();
                    //给表头命名
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Text = "";
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[1].Text = lsBenName[0];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[2].Text = lsBenName[1];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[3].Text = lsBenName[2];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[4].Text = lsBenName[3];
                    break;
            }
            #endregion
        }

        //效益评价指标权重计算
        protected void benefitFactorsComp_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < lsBenName.Count; i++)
            {
                #region 将用户输入的效益矩阵值存到二维数组benData中
                TextBox txt1 = (TextBox)BenefitGrid.Rows[i].FindControl("first");
                TextBox txt2 = (TextBox)BenefitGrid.Rows[i].FindControl("second");
                TextBox txt3 = (TextBox)BenefitGrid.Rows[i].FindControl("three");
                TextBox txt4 = (TextBox)BenefitGrid.Rows[i].FindControl("four");

                //设置当文本框的值不为空的时候才进行下面的操作
                if (txt1.Text != string.Empty && txt2.Text != string.Empty && txt3.Text != string.Empty && txt4.Text != string.Empty)
                {

                    benData[i, 0] = Double.Parse(txt1.Text);
                    benData[i, 1] = Double.Parse(txt2.Text);
                    benData[i, 2] = Double.Parse(txt3.Text);
                    benData[i, 3] = Double.Parse(txt4.Text);
                }
                else
                {
                    //处理为空的情况


                }
                #endregion
            }
            //计算权重，判断是否计算成功
            bool isok = false;
            resultBenefit = CommonClass.Matrix.CalcWeight(benData, ref isok);
            if (isok)
            {
                #region 将计算的权重结果显示到前台中
                benefitFactors.Text = "1";
                delta_fertility.Text = resultBenefit[0, 0].ToString();
                delta_landout.Text = resultBenefit[1, 0].ToString();
                delta_runoff.Text = resultBenefit[2, 0].ToString();
                delta_soilErosion.Text = resultBenefit[3, 0].ToString();
                #endregion

            }
        }

        // 适宜性目标矩阵表头设置
        protected void SuitfactGrid_RowCreated(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    //总表头
                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();
                    //给表头命名
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Text = "";
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[1].Text = lsSuitName[0];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[2].Text = lsSuitName[1];
                    break;
            }

        }
        // 适宜性准则矩阵1表头设置
        protected void SuitfactGrid2_RowCreated(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    //总表头
                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();
                    //给表头命名
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Text = "";
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[1].Text = lsSuitName2[0];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[2].Text = lsSuitName2[1];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[3].Text = lsSuitName2[2];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[4].Text = lsSuitName2[3];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[5].Text = lsSuitName2[4];
                    break;
            }
        }
        // 适宜性准则矩阵2表头设置
        protected void SuitfactGrid3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            switch (e.Row.RowType)
            {
                case DataControlRowType.Header:

                    //总表头
                    TableCellCollection tcHeader = e.Row.Cells;
                    tcHeader.Clear();
                    //给表头命名
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[0].Text = "";
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[1].Text = lsSuitName3[0];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[2].Text = lsSuitName3[1];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[3].Text = lsSuitName3[2];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[4].Text = lsSuitName3[3];
                    tcHeader.Add(new TableHeaderCell());
                    tcHeader[5].Text = lsSuitName3[4];
                    break;
            }
        }

        //适宜性评价指标权重计算
        protected void suitabilityFactorsComp_Click(object sender, EventArgs e)
        {


            #region 获取处理自然和社会矩阵，存到suitData中
            for (int i = 0; i < lsSuitName.Count; i++)
            {
                TextBox txt1 = (TextBox)SuitfactGrid.Rows[i].FindControl("first2");
                TextBox txt2 = (TextBox)SuitfactGrid.Rows[i].FindControl("second2");

                //设置当文本框的值不为空的时候才进行下面的操作
                if (txt1.Text != string.Empty && txt2.Text != string.Empty)
                {
                    suitData[i, 0] = Double.Parse(txt1.Text);
                    suitData[i, 1] = Double.Parse(txt2.Text);
                }
                else
                {
                    //处理为空的情况


                }
            }
            #endregion
            #region 获取处理社会因子的矩阵，存到suitData2中
            for (int i = 0; i < lsSuitName2.Count; i++)
            {
                TextBox txt1 = (TextBox)SuitfactGrid2.Rows[i].FindControl("first3");
                TextBox txt2 = (TextBox)SuitfactGrid2.Rows[i].FindControl("second3");
                TextBox txt3 = (TextBox)SuitfactGrid2.Rows[i].FindControl("three3");
                TextBox txt4 = (TextBox)SuitfactGrid2.Rows[i].FindControl("four3");
                TextBox txt5 = (TextBox)SuitfactGrid2.Rows[i].FindControl("five3");
                //设置当文本框的值不为空的时候才进行下面的操作
                if (txt1.Text != string.Empty && txt2.Text != string.Empty && txt3.Text != string.Empty && txt4.Text != string.Empty && txt5.Text != string.Empty)
                {

                    suitData2[i, 0] = Double.Parse(txt1.Text);
                    suitData2[i, 1] = Double.Parse(txt2.Text);
                    suitData2[i, 2] = Double.Parse(txt3.Text);
                    suitData2[i, 3] = Double.Parse(txt4.Text);
                    suitData2[i, 4] = Double.Parse(txt5.Text);
                }
                else
                {
                    //处理为空的情况


                }
            }
            #endregion
            #region 获取处理自然因子的矩阵，存到suitData3中
            for (int i = 0; i < lsSuitName3.Count; i++)
            {
                TextBox txt1 = (TextBox)SuitfactGrid3.Rows[i].FindControl("first4");
                TextBox txt2 = (TextBox)SuitfactGrid3.Rows[i].FindControl("second4");
                TextBox txt3 = (TextBox)SuitfactGrid3.Rows[i].FindControl("three4");
                TextBox txt4 = (TextBox)SuitfactGrid3.Rows[i].FindControl("four4");
                TextBox txt5 = (TextBox)SuitfactGrid3.Rows[i].FindControl("five4");
                //设置当文本框的值不为空的时候才进行下面的操作
                if (txt1.Text != string.Empty && txt2.Text != string.Empty && txt3.Text != string.Empty && txt4.Text != string.Empty && txt5.Text != string.Empty)
                {

                    suitData3[i, 0] = Double.Parse(txt1.Text);
                    suitData3[i, 1] = Double.Parse(txt2.Text);
                    suitData3[i, 2] = Double.Parse(txt3.Text);
                    suitData3[i, 3] = Double.Parse(txt4.Text);
                    suitData3[i, 4] = Double.Parse(txt5.Text);
                }
                else
                {
                    //处理为空的情况


                }
            }
            #endregion

            //计算权重
            bool isok = false;
            bool isok2 = false;
            bool isok3 = false;
            resultSuit1 = CommonClass.Matrix.CalcWeight(suitData, ref isok);
            resultSuit2 = CommonClass.Matrix.CalcWeight(suitData2, ref isok2);
            resultSuit3 = CommonClass.Matrix.CalcWeight(suitData3, ref isok3);

            if (isok && isok2 && isok3)
            {
                /*
                 * 说明：假设适宜性由自然因子和社会因子组成
                 *resultSuit1存放的是  自然因子、社会因子 占适宜性因子的比重，设值为,0.5与0.5
                 *resultSuit2存放的是 
                 */
                double x1 = resultSuit1[0, 0];
                for (int i = 0; i < resultSuit2.Length; i++)
                {
                    resultSuit2[i, 0] = x1 * resultSuit2[i, 0];
                }
                double x2 = resultSuit1[1, 0];
                for (int j = 0; j < resultSuit3.Length; j++)
                {
                    resultSuit3[j, 0] = x2 * resultSuit3[j, 0];

                }
                #region 将适宜性权重计算结果显示到界面上面
                this.txtsuitabilityFactors.Text = "1.0";

                this.txtsocioeconomicFactors.Text = resultSuit1[0, 0].ToString();
                this.txtnatureFactors.Text = resultSuit1[1, 0].ToString();

                this.txtrural_labor_intensity.Text = resultSuit2[0, 0].ToString();
                this.txtgov_policy.Text = resultSuit2[1, 0].ToString();
                this.txtbuildInput.Text = resultSuit2[2, 0].ToString();
                this.txtRoad.Text = resultSuit2[3, 0].ToString();
                this.txtJMD.Text = resultSuit2[4, 0].ToString();

                this.txtsoilErosionIntensity.Text = resultSuit3[0, 0].ToString();
                this.txtsoilErodibility.Text = resultSuit3[1, 0].ToString();
                this.txtslope.Text = resultSuit3[2, 0].ToString();
                this.txtplantcoverage.Text = resultSuit3[3, 0].ToString();
                this.txtcurrentLandUse.Text = resultSuit3[4, 0].ToString();
                #endregion

            }
            else
            {
                //层次分析法计算失败的写法

            }


        }

        //创建效益评价因子规则（对计算的结果插入到数据库里面）
        protected void benefitFactorscreateRule_Click(object sender, EventArgs e)
        {
            //1获得用户的id
            int userID = CommonClass.OperateUsers.getUserID();

            //、获取措施。因为因为所有的措施中适宜性权重值都相同，这里只是象征性的给它赋值经济林果。其实没什么用的。
            string measurename = "经济林果";

            for (int i = 0; i < lsBenName.Count; i++)
            {
                //3、获取到效益权重的因子名对应的ID
                STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
                DataSet ds2 = factdirB.GetList("Name='" + lsBenName[i].ToString() + "'");
                DataTable dt2 = ds2.Tables[0];
                int factid = int.Parse(dt2.Rows[0]["ID"].ToString());

                STBC.BLL.ST_FACTEVALWEIG factevalweigB = new STBC.BLL.ST_FACTEVALWEIG();
                STBC.Model.ST_FACTEVALWEIG factevalweigM = new STBC.Model.ST_FACTEVALWEIG();
                factevalweigM.OWNER = userID;
                factevalweigM.SUITAINDICATOR = factid;
                factevalweigM.MEASNAME = measurename;
                factevalweigM.WEIGHT = (decimal)Math.Round(resultBenefit[i, 0], 4);
                //判断数据是否已经存在，如果不存在则插入数据库里面
                if (!factevalweigB.Exists(userID, factid, measurename))
                {
                    factevalweigB.Add(factevalweigM);
                    //提醒用户已经插入数据库
                    if (i == lsBenName.Count - 1)
                    {
                        Response.Write("<script>alert('权重已经插入数据库！');</script>");
                    }
                }
                else
                {
                    //更新数据
                    factevalweigB.Update(factevalweigM);
                    //提醒数据已经被更新了
                    if (i == lsBenName.Count - 1)
                    {
                        Response.Write("<script>alert('权重已经被更新！');</script>");

                    }
                }

            }
        }
        //创建适宜性规则
        protected void suitabilityFactorscreateRule_Click(object sender, EventArgs e)
        {

            //1获得用户的id
            int userID = CommonClass.OperateUsers.getUserID();
            //2、获取措施
            string measurename = measureSuit.SelectedItem.Text;

            //效益型权重插入1
            bool isok1 = insertSuitWeigth(lsSuitName, resultSuit1, userID, measurename);
            //效益型权重插入2
            bool isok2 = insertSuitWeigth(lsSuitName2, resultSuit2, userID, measurename);
            //效益型权重插入3
            bool isok3 = insertSuitWeigth(lsSuitName3, resultSuit3, userID, measurename);
            if (isok1 && isok2 && isok3)
            {
                //提醒用户数据进行了覆盖
                Response.Write("<script>alert('数据插入成功！');</script>");
            }
            else
            {
                //提醒用户插入成功
                Response.Write("<script>alert('修改数据成功！');</script>");
            }

        }
        protected bool insertSuitWeigth(List<string> lsSuitNameList, double[,] resultSuit, int userID, string measurename)
        {
            bool isok = false;
            //效益型权重插入2
            for (int i = 0; i < lsSuitNameList.Count; i++)
            {
                //3、获取到效益权重的因子名对应的ID
                //STBC.BLL.SUITAINDICATOR suitaindicatorB = new STBC.BLL.SUITAINDICATOR();
                STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
                DataSet ds2 = factdirB.GetList("Name='" + lsSuitNameList[i].ToString() + "'");
                DataTable dt2 = ds2.Tables[0];
                int factID = int.Parse(dt2.Rows[0]["ID"].ToString());

               
                STBC.BLL.ST_FACTEVALWEIG factevalweigB = new STBC.BLL.ST_FACTEVALWEIG();
                STBC.Model.ST_FACTEVALWEIG factevalweigM = new STBC.Model.ST_FACTEVALWEIG();

                factevalweigM.SUITAINDICATOR = factID;
                factevalweigM.OWNER = userID;
                double weight1 = resultSuit[i, 0];
                factevalweigM.WEIGHT = (decimal)Math.Round(weight1, 4);
                factevalweigM.MEASNAME = measurename;

                //判断数据是否已经存在，如果不存在则插入数据库里面

                if (!factevalweigB.Exists(userID, factID, measurename))
                {
                    factevalweigB.Add(factevalweigM);
                }
                else
                {
                    //如果数据库已经存在则更新
                    factevalweigB.Update(factevalweigM);
                    isok = true;

                }

            }
            return isok;


        }
        //模糊函数创建规则构建，创建规则并提交到数据库中
        protected void btn_modelCreated_Click(object sender, EventArgs e)
        {
            
            //获得用户的id
            int userID = CommonClass.OperateUsers.getUserID();

            string measurename = measureFuzzfunct.SelectedItem.Text;
            STBC.BLL.ST_FUZZFUNCT fuzzfunctB = new STBC.BLL.ST_FUZZFUNCT();
            STBC.Model.ST_FUZZFUNCT fuzzfunctM = new STBC.Model.ST_FUZZFUNCT();
            for (int i = 0; i < lsFuzzName.Count; i++)
            {

                DropDownList ddlFunct = (DropDownList)FuzzfunctGrid.Rows[i].FindControl("ddlFunctSelect");
                string functtype = ddlFunct.SelectedItem.Text;
                //查找到每行因子对应的因子id
                STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
                DataSet ds2 = factdirB.GetList("Name='" + lsFuzzName[i].ToString() + "'");
                DataTable dt2 = ds2.Tables[0];
                int factid = int.Parse(dt2.Rows[0]["ID"].ToString());
                //找到对应的单位
                TextBox txtUn = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtUnit1");
                #region 取得拐点值的设置，并把它插入数据库里面
                if (functtype == "抛物线型")
                {


                    //拼接拐点设置条件
                    TextBox txtPa11 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtPa1");
                    TextBox txtPb11 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtPb1");
                    TextBox txtPb21 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtPb2");
                    TextBox txtPa21 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtPa2");
                    string inflexion = txtPa11.Text + "|" + txtPb11.Text + "|" + txtPb21.Text + "|" + txtPa21.Text;
                    fuzzfunctM.FACTID = factid;
                    fuzzfunctM.FUNCTTYPE = functtype;
                    fuzzfunctM.MEASNAME = measurename;
                    fuzzfunctM.UNIT = txtUn.Text;
                    fuzzfunctM.USERID = userID;
                    fuzzfunctM.INFLEXION = inflexion;
                    //判断数据是否已经存在，如果不存在则插入数据
                    if (!fuzzfunctB.Exists(factid, userID, measurename))
                    {
                        fuzzfunctB.Add(fuzzfunctM);
                    }
                    //如果存在，则更新数据
                    else
                    {
                        fuzzfunctB.Update(fuzzfunctM);
                    }

                }
                else if (functtype == "升半梯形")
                {

                    //拼接拐点设置条件
                    TextBox txtSa1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtSa");
                    TextBox txtSb1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtSb");
                    string inflexion = txtSa1.Text + "|" + txtSb1.Text;
                    fuzzfunctM.FACTID = factid;
                    fuzzfunctM.FUNCTTYPE = functtype;
                    fuzzfunctM.MEASNAME = measurename;
                    fuzzfunctM.UNIT = txtUn.Text;
                    fuzzfunctM.USERID = userID;
                    fuzzfunctM.INFLEXION = inflexion;
                    //判断数据是否已经存在，如果不存在则插入数据
                    if (!fuzzfunctB.Exists(factid, userID, measurename))
                    {
                        fuzzfunctB.Add(fuzzfunctM);
                    }
                    //如果存在，则更新数据
                    else
                    {
                        fuzzfunctB.Update(fuzzfunctM);
                    }

                }
                else if (functtype == "降半梯形")
                {
                    //拼接拐点设置条件
                    TextBox txtJa1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtJa");
                    TextBox txtJb1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtJb");
                    string inflexion = txtJa1.Text + "|" + txtJb1.Text;
                    fuzzfunctM.FACTID = factid;
                    fuzzfunctM.FUNCTTYPE = functtype;
                    fuzzfunctM.MEASNAME = measurename;
                    fuzzfunctM.UNIT = txtUn.Text;
                    fuzzfunctM.USERID = userID;
                    fuzzfunctM.INFLEXION = inflexion;
                    //判断数据是否已经存在，如果不存在则插入数据
                    if (!fuzzfunctB.Exists(factid, userID, measurename))
                    {
                        fuzzfunctB.Add(fuzzfunctM);
                    }
                    //如果存在，则更新数据
                    else
                    {
                        fuzzfunctB.Update(fuzzfunctM);
                    }

                }
                //特征函数
                else
                {
                    //拼接拐点设置条件
                    TextBox txtGsuit1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtGsuit");
                    TextBox txtBJsuit1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtBJsuit");
                    TextBox txtYsuit1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtYsuit");
                    TextBox txtBsuit1 = (TextBox)FuzzfunctGrid.Rows[i].FindControl("txtBsuit");
                    string inflexion = txtGsuit1.Text + "|" + txtBJsuit1.Text + "|" + txtYsuit1.Text + "|" + txtBsuit1.Text;
                    fuzzfunctM.FACTID = factid;
                    fuzzfunctM.FUNCTTYPE = functtype;
                    fuzzfunctM.MEASNAME = measurename;
                    fuzzfunctM.UNIT = txtUn.Text;
                    fuzzfunctM.USERID = userID;
                    fuzzfunctM.INFLEXION = inflexion;
                    //判断数据是否已经存在，如果不存在则插入数据
                    if (!fuzzfunctB.Exists(factid, userID, measurename))
                    {
                        fuzzfunctB.Add(fuzzfunctM);
                    }
                    //如果存在，则更新数据
                    else
                    {
                        fuzzfunctB.Update(fuzzfunctM);
                    }

                }
                if (i == lsFuzzName.Count - 1)
                {
                    Response.Write("<script>alert('模糊函数已经创建了！');</script>");
                }
                #endregion 

            }


        }
        //重建限制性条件
        protected void btn_limitativeRule_Click(object sender, EventArgs e)
        {

            //获得用户的id
            int userID = CommonClass.OperateUsers.getUserID();
            //措施的名字
            string measurename = measureLimit.SelectedItem.Text;

            STBC.BLL.ST_CONSTRCONDIT constrconditB = new STBC.BLL.ST_CONSTRCONDIT();
            STBC.Model.ST_CONSTRCONDIT constrconditM = new STBC.Model.ST_CONSTRCONDIT();

            for (int i = 0; i < lsLimitName.Count; i++)
            {
                //查找到每行因子对应的因子id
                STBC.BLL.ST_FACTDIR factdirB = new STBC.BLL.ST_FACTDIR();
                DataSet ds2 = factdirB.GetList("Name='" + lsLimitName[i].ToString() + "'");
                DataTable dt2 = ds2.Tables[0];
                int factid = int.Parse(dt2.Rows[0]["ID"].ToString());

                //获取到单位，比如平方米等等
                TextBox txtUnit21 = (TextBox)LimcondGrid.Rows[i].FindControl("txtUnit2");
                DropDownList ddlFactType1 = (DropDownList)LimcondGrid.Rows[i].FindControl("ddlFactType");
                //如果是数值类型
                if (ddlFactType1.SelectedItem.Text == "数值类型")
                {
                    //获取到底是>,<,=类型
                    DropDownList ddlContType1 = (DropDownList)LimcondGrid.Rows[i].FindControl("ddlContType");
                    //获取限制条件的文本
                    TextBox txtLimitC1 = (TextBox)LimcondGrid.Rows[i].FindControl("txtLimitC");

                    constrconditM.FACTID = factid;
                    constrconditM.FACTTYPE = ddlFactType1.SelectedItem.Text;
                    constrconditM.MEASNAME = measurename;
                    constrconditM.SYMBOLTYPE = ddlContType1.SelectedItem.Text;
                    constrconditM.USERID = userID;
                    constrconditM.UNIT = txtUnit21.Text.ToString().Trim();
                    constrconditM.LIMCONDIT = txtLimitC1.Text.ToString().Trim();
                    //插入到数据库里面
                    if (!constrconditB.Exists(userID, factid, measurename))
                    {
                        constrconditB.Add(constrconditM);
                    }
                    else
                    {
                        constrconditB.Update(constrconditM);
                    }
                }
                //否则
                else
                {
                    //获取in类型
                    DropDownList ddlIntype1 = (DropDownList)LimcondGrid.Rows[i].FindControl("ddlIntype");
                    TextBox txtLimitC1 = (TextBox)LimcondGrid.Rows[i].FindControl("txtLimitC");

                    constrconditM.FACTID = factid;
                    constrconditM.FACTTYPE = ddlFactType1.SelectedItem.Text;
                    constrconditM.MEASNAME = measurename;
                    constrconditM.SYMBOLTYPE = ddlIntype1.SelectedItem.Text;
                    constrconditM.USERID = userID;
                    constrconditM.UNIT = txtUnit21.Text.ToString().Trim();
                    constrconditM.LIMCONDIT = txtLimitC1.Text.ToString().Trim();
                    //插入到数据库里面
                    if (!constrconditB.Exists(userID, factid, measurename))
                    {
                        constrconditB.Add(constrconditM);
                    }
                    else
                    {
                        constrconditB.Update(constrconditM);
                    }
                }
                if (i == lsLimitName.Count - 1)
                {
                    Response.Write("<script>alert('限制条件已经创建了！');</script>");
                }

            }

        }
        //创建适宜性级别规则
        protected void btnCreateRule_Click(object sender, EventArgs e)
        {
            //获得用户的id
            int userID = CommonClass.OperateUsers.getUserID();
            STBC.BLL.ST_SUITCLASS suitclassB = new STBC.BLL.ST_SUITCLASS();

            STBC.Model.ST_SUITCLASS suitclassM = new STBC.Model.ST_SUITCLASS();
            suitclassM.NAME = levelLabel1.Text.ToString().Trim();
            suitclassM.CODE = levelName1.Text.ToString().Trim();
            suitclassM.CEILING = (decimal)Math.Round(double.Parse(levelLeft1.Text.ToString().Trim()), 3);
            suitclassM.FLOOR = (decimal)Math.Round(double.Parse(levelRight1.Text.ToString().Trim()), 3);
            suitclassM.USERID = userID;

            STBC.Model.ST_SUITCLASS suitclassM2 = new STBC.Model.ST_SUITCLASS();
            suitclassM2.NAME = levelLabel2.Text.ToString().Trim();
            suitclassM2.CODE = levelName2.Text.ToString().Trim();
            suitclassM2.CEILING = (decimal)Math.Round(double.Parse(levelLeft2.Text.ToString().Trim()), 3);
            suitclassM2.FLOOR = (decimal)Math.Round(double.Parse(levelRight2.Text.ToString().Trim()), 3);
            suitclassM2.USERID = userID;

            STBC.Model.ST_SUITCLASS suitclassM3 = new STBC.Model.ST_SUITCLASS();
            suitclassM3.NAME = levelLabel3.Text.ToString().Trim();
            suitclassM3.CODE = levelName3.Text.ToString().Trim();
            suitclassM3.CEILING = (decimal)Math.Round(double.Parse(levelLeft3.Text.ToString().Trim()), 3);
            suitclassM3.FLOOR = (decimal)Math.Round(double.Parse(levelRight3.Text.ToString().Trim()), 3);
            suitclassM3.USERID = userID;

            STBC.Model.ST_SUITCLASS suitclassM4 = new STBC.Model.ST_SUITCLASS();
            suitclassM4.NAME = levelLabel4.Text.ToString().Trim();
            suitclassM4.CODE = levelName4.Text.ToString().Trim();
            suitclassM4.CEILING = (decimal)Math.Round(double.Parse(levelLeft4.Text.ToString().Trim()), 3);
            suitclassM4.FLOOR = (decimal)Math.Round(double.Parse(levelRight4.Text.ToString().Trim()), 3);
            suitclassM4.USERID = userID;

            if (!suitclassB.Exists(userID, suitclassM.NAME))
            {
                suitclassB.Add(suitclassM);
            }
            else
            {
                suitclassB.Update(suitclassM);
            }
            if (!suitclassB.Exists(userID, suitclassM2.NAME))
            {
                suitclassB.Add(suitclassM2);
            }
            else
            {
                suitclassB.Update(suitclassM2);
            }
            if (!suitclassB.Exists(userID, suitclassM3.NAME))
            {
                suitclassB.Add(suitclassM3);
            }
            else
            {
                suitclassB.Update(suitclassM3);
            }
            if (!suitclassB.Exists(userID, suitclassM4.NAME))
            {
                suitclassB.Add(suitclassM4);
            }
            else
            {
                suitclassB.Update(suitclassM4);
            }
            //提醒用户插入成功
            Response.Write("<script>alert('规则创建成功！');</script>");
        }

    }
}