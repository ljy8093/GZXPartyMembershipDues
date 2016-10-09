using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZXPartyMembershipDues.Reference.Base
{
    public class Obj_YIJDF_ZZ_2
    {
        private string _Name;
        private double _GWGZ;
        private double _XJGZ;
        private double _ZWBT;
        private double _JXGZ;
        private double _TENPERCENT;
        private double _XJ;
        private double _JSJE;
        private double _YKSJ;
        private double _DFJS;
        private double _YJDF;
        private double _YJDFQZ;
        private string _JFQZYF;
        private DateTime _DATE;

        //姓名
        public string Name
        {
            get
            {
                return _Name;
            }

            set
            {
                _Name = value;
            }
        }

        //岗位工资
        public double GWGZ
        {
            get
            {
                return _GWGZ;
            }

            set
            {
                _GWGZ = value;
            }
        }

        //薪级工资
        public double XJGZ
        {
            get
            {
                return _XJGZ;
            }

            set
            {
                _XJGZ = value;
            }
        }

        //职务补贴
        public double ZWBT
        {
            get
            {
                return _ZWBT;
            }

            set
            {
                _ZWBT = value;
            }
        }

        //绩效工资
        public double JXGZ
        {
            get
            {
                return _JXGZ;
            }

            set
            {
                _JXGZ = value;
            }
        }

        //10%
        public double TENPERCENT
        {
            get
            {
                return _TENPERCENT;
            }

            set
            {
                _TENPERCENT = value;
            }
        }

        //小计
        public double XJ
        {
            get
            {
                return _XJ;
            }

            set
            {
                _XJ = value;
            }
        }

        //计税金额
        public double JSJE
        {
            get
            {
                return _JSJE;
            }

            set
            {
                _JSJE = value;
            }
        }

        //应扣税金
        public double YKSJ
        {
            get
            {
                return _YKSJ;
            }

            set
            {
                _YKSJ = value;
            }
        }

        //党费基数
        public double DFJS
        {
            get
            {
                return _DFJS;
            }

            set
            {
                _DFJS = value;
            }
        }

        //月缴党费
        public double YJDF
        {
            get
            {
                return _YJDF;
            }

            set
            {
                _YJDF = value;
            }
        }

        //月缴党费取整
        public double YJDFQZ
        {
            get
            {
                return _YJDFQZ;
            }

            set
            {
                _YJDFQZ = value;
            }
        }

        //缴费起止月份
        public string JFQZYF
        {
            get
            {
                return _JFQZYF;
            }

            set
            {
                _JFQZYF = value;
            }
        }

        //日期
        public DateTime DATE
        {
            get
            {
                return _DATE;
            }

            set
            {
                _DATE = value;
            }
        }
    }
}
