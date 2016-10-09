using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GZXPartyMembershipDues.Reference.Base
{
    public class Columns_YIJDF_ZZ_Excel
    {
        public Dictionary<string, string> dir;

        public Columns_YIJDF_ZZ_Excel()
        {
            dir = new Dictionary<string, string>();
            dir.Add("姓名", "NAME");
            dir.Add("岗位工资", "GWGZ");
            dir.Add("薪级", "XJGZ");
            dir.Add("职务补贴", "ZWBT");
            dir.Add("绩效工资", "JXGZ");
            dir.Add("0.1", "TENPERCENT");
            dir.Add("小计", "XJ");
            dir.Add("计税金额", "JSJE");
            dir.Add("应扣税金", "YKSJ");
            dir.Add("党费基数", "DFJS");
            dir.Add("月缴党费", "YJDF");
            dir.Add("保留整数", "YJDFQZ");
            dir.Add("缴费起止月份", "JFQZYF");
            dir.Add("缴费月数", "JFYS");
            dir.Add("缴费总额", "JFZE");
        }
    }
}
