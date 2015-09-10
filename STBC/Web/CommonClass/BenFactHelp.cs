using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.CommonClass
{
    public class BenFactHelp
    {
        /// <summary>
        /// 获取效益性矩阵的权重,并根据对应矩阵的要求进行计算
        /// </summary>
        /// <param name="weight"></param>
        /// <param name="mearsureName"></param>
        /// <returns></returns>
        public static double GetBenWeight(List<string> weight, string mearsureName)
        {
            /*
             特此备注weight为效益权重 :土壤肥力增加值、土地产出增加值、减流效益、减沙效益
             */
            double weight1 = 0.0;
            if (mearsureName == "经济林果")
            {
                weight1 = 0.442 * double.Parse(weight[0].ToString().Trim()) + 1 * double.Parse(weight[1].ToString().Trim()) + 0.333 * double.Parse(weight[2].ToString().Trim()) + 0.642 * double.Parse(weight[3].ToString().Trim());
            }
            else if (mearsureName == "低效林改造")
            {
                weight1 = 0.301 * double.Parse(weight[0].ToString().Trim()) + 0.2 * double.Parse(weight[1].ToString().Trim()) + 0.437 * double.Parse(weight[2].ToString().Trim()) + 0.718 * double.Parse(weight[3].ToString().Trim());
            }
            else if (mearsureName == "封禁")
            {
                weight1 = 0.396 * double.Parse(weight[0].ToString().Trim()) + 0 * double.Parse(weight[1].ToString().Trim()) + 0.421 * double.Parse(weight[2].ToString().Trim()) + 0.724 * double.Parse(weight[3].ToString().Trim());
            }
            //生态林草
            else
            {
                weight1 = 0.303 * double.Parse(weight[0].ToString().Trim()) + 0.4 * double.Parse(weight[1].ToString().Trim()) + 0.620 * double.Parse(weight[2].ToString().Trim()) + 0.860 * double.Parse(weight[3].ToString().Trim());
            }
            return weight1;
        }
    }
}