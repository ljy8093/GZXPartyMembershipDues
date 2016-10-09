using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GZXPartyMembershipDues.Reference.Base
{
    public class Obj_YINGJDF
    {
        private DateTime _Date;
        private string _Name;
        private double _DFJS;
        private double _DFJSQZ;
        private double _YINGJDF;
        private double _YINGJDFQZ;

        //缴费月份
        public DateTime Date
        {
            get
            {
                return _Date;
            }

            set
            {
                _Date = value;
            }
        }

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

        //党费基数取整
        public double DFJSQZ
        {
            get
            {
                return _DFJSQZ;
            }

            set
            {
                _DFJSQZ = value;
            }
        }

        //应交党费
        public double YINGJDF
        {
            get
            {
                return _YINGJDF;
            }

            set
            {
                _YINGJDF = value;
            }
        }

        //应交党费取整
        public double YINGJDFQZ
        {
            get
            {
                return _YINGJDFQZ;
            }

            set
            {
                _YINGJDFQZ = value;
            }
        }
    }
}
