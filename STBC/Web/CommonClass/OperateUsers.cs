using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Web.CommonClass
{
    /// <summary>
    /// 获取用户名字，通过Session获取
    /// </summary>
    public class OperateUsers
    {
        public static int getUserID()
        {
           //做好登录模块之后把“admin”换成对应的session就行
            string userName = "admin";
            STBC.BLL.ST_USERS usersB = new STBC.BLL.ST_USERS();
            DataSet ds1 = usersB.GetList("USERNAME='" + userName + "'");
            DataTable dt1 = ds1.Tables[0];
            //获得用户的id
            int userID = int.Parse(dt1.Rows[0]["USERID"].ToString());
            return userID;
        }
    }
}