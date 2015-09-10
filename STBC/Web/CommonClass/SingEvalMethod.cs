using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.CommonClass
{
    public class SingEvalMethod
    {
        /// <summary>
        /// 单项评价抛物线型
        /// </summary>
        /// <param name="strarr">传入的拐点字符串分割后的字符串数组</param>
        /// <param name="x">传入的数值</param>
        /// <returns></returns>
        public static double Parabola(string[] strarr, double x)
        {
            double a1=0.0, b1=0.0,b2=0.0, a2=0.0;
            
            double x1 = 0.0;
            if (strarr.Length==4)
            {
                a1=double.Parse(strarr[0]);
                b1 = double.Parse(strarr[1]);
                b2 = double.Parse(strarr[2]);
                a2 = double.Parse(strarr[3]);
            }
            else
            {
                return x1;
            }
            
            if (x>=b1&&x<=b2)
            {
                x1 = 1;
            }
            else if (x <= a1 || x >= a2)
            {
                x1 = 0;
            }
            else if (x > a1 && x < b1)
            {
                x1 = (x - a1) / (b1 - a1);
            }
            else
            {
                x1 = (a2 - x) / (a2 - b2);
            }
            return x1;
        }
        /// <summary>
        /// 升半梯形
        /// </summary>
        /// <param name="strarr">传入的字符串数组</param>
        /// <param name="x">传入的数值</param>
        /// <returns></returns>
        public static double RiseTrap(string[] strarr, double x)
        {
            double x1 = 0;
            double a=0, b=0;
            if (strarr.Length == 2)
            {
                a = double.Parse(strarr[0]);
                b= double.Parse(strarr[1]);
            }
            else
            {
                return x1;
            }
            if(x>=b)
            {
                x1 = 1;
            
            }
            else if (x > a && x < b)
            {
                x1 = (x - a) / (b - a);
            }
            else
            {
                x1 = 0;
            }
            return x1;
        }
        /// <summary>
        /// 降半梯形
        /// </summary>
        /// <param name="strarr">传入的字符串数组</param>
        /// <param name="x">传入的数值</param>
        /// <returns></returns>
        public static double DropTrap(string[] strarr, double x)
        {
            double x1 = 0;
            double a = 0, b = 0;
            if (strarr.Length == 2)
            {
                a = double.Parse(strarr[0]);
                b = double.Parse(strarr[1]);
            }
            else
            {
                return x1;
            }
            if (x <=a)
            {
                x1 = 1;

            }
            else if (x > a && x < b)
            {
                x1 = (b-x) / (b - a);
            }
            else
            {
                x1 = 0;
            }
            return x1;
        }
        /// <summary>
        /// 特征函数
        /// </summary>
        /// <param name="strarr">传入的字符串数组</param>
        /// <param name="x">传入的字符串数值</param>
        /// <returns></returns>
        public static double EigenFunct(string[] strarr, string x)
        {
            double x1 = 0;
            if (strarr.Length == 4)
            {
                if (strarr[0] == x)
                {
                    x1 = 1;
                }
                else if (strarr[1] == x)
                {
                    x1 = 0.7;
                }
                else if (strarr[2] == x)
                {
                    x1 = 0.3;
                }
                else
                    x1 = 0.0;

            }
            else
            {
                return x1;
            }
            return x1;
        }

    }
}