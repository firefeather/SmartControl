using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 超级环监
{
    public class Model : NotificationObject
    {
        public static int 序号_温度 = 0;
        public static int 序号_温度报警 = 0;
        public static int 序号_温湿度 = 0;
        public static int 序号_温湿度报警 = 0;
        public static int 序号_光照度 = 0;
        public static int 序号_光照度报警 = 0;
        

 
        private string _theme = "ExpressionDark";
        private string _IP = "192.168.1.11";

        public string IP
        {
            get { return _IP; }
            set { _IP = value; this.RaisePropertyChanged("IP"); }
        }
        private string _用户名 = "123456";
        public string 用户名
        {
            get { return _用户名; }
            set { _用户名 = value; this.RaisePropertyChanged("用户名"); }
        }
        private string _密码 = "123456";
        public string 密码
        {
            get { return _密码; }
            set { _密码 = value; this.RaisePropertyChanged("密码"); }
        }
        private string _nvsid = "5526";
        public string nvsid
        {
            get { return _nvsid; }
            set { _nvsid = value; this.RaisePropertyChanged("nvsid"); }
        }

        public class 温度表
        {
            public int 序号 {get;set;}
            public DateTime 时间 { get; set; }
            public string 温度 { get; set; }
            public    温度表(string _温度)
            {
                序号 = ++序号_温度;
                时间 = DateTime.Now;
                温度 = _温度+"°C";
            }
        }
        public class 温度报警表
        {
            public int 序号 { get; set; }
            public DateTime 时间 { get; set; }
            public string 温度 { get; set; }
            public string 类型 { get; set; }
            public 温度报警表(string _温度,string _类型)
            {
                序号 = ++序号_温度报警;
                时间 = DateTime.Now;
                温度 = _温度 + "°C";
                类型 = _类型;
            }
        }
        public class 温湿度表
        {
            public int 序号 { get; set; }
            public DateTime 时间 { get; set; }
            public string 温度 { get; set; }
            public string 湿度 { get; set; }

            public 温湿度表(string _温度,string _湿度)
            {
                序号 = ++序号_温湿度;
                时间 = DateTime.Now;
                温度 = _温度 + "°C";
                湿度 = _湿度 + "%";

            }
        }
        public class 温湿度报警表
        {
            public int 序号 { get; set; }
            public DateTime 时间 { get; set; }
            public string 数值 { get; set; }
            public string 类型 { get; set; }
            public 温湿度报警表(string _数值, string _类型)
            {
                序号 = ++序号_温度报警;
                时间 = DateTime.Now;
                数值 = _数值 + "°C";
                类型 = _类型;
            }
        }
        public class 光照度表
        {
            public int 序号 { get; set; }
            public DateTime 时间 { get; set; }
            public string 光照度 { get; set; }
            public 光照度表(string _光照度)
            {
                序号 = ++序号_光照度;
                时间 = DateTime.Now;
                光照度 = _光照度 + "lux";
            }
        }
        public class 光照度报警表
        {
            public int 序号 { get; set; }
            public DateTime 时间 { get; set; }
            public string 光照度 { get; set; }
            public string 类型 { get; set; }
            public 光照度报警表(string _光照度, string _类型)
            {
                序号 = ++序号_温度报警;
                时间 = DateTime.Now;
                光照度 = _光照度 + "°C";
                类型 = _类型;
            }
        }
        public string theme
        {
            get { return _theme; }
            set { _theme = value; this.RaisePropertyChanged("theme"); }
        }
  

     
    }
}
