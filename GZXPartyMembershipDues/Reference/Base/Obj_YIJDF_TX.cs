using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZXPartyMembershipDues.Reference.Base
{
    public class Obj_YIJDF_TX
    {
        private string _Name;
        private double _DFJS;
        private double _YJDF;
        private double _YJDFQZ;
        private double _JFQZYF;
        private int _JFYS;
        private double _JFZE;

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
        public double JFQZYF
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

        //缴费月数
        public int JFYS
        {
            get
            {
                return _JFYS;
            }

            set
            {
                _JFYS = value;
            }
        }

        //缴费总额
        public double JFZE
        {
            get
            {
                return _JFZE;
            }

            set
            {
                _JFZE = value;
            }
        }
    }
}
