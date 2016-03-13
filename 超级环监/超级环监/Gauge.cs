using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace 超级环监
{
    public class Gauge: INotifyPropertyChanged
    {
        private string _温度_下限 = "0";
        private string _温度_上限 = "40";
        private string _温湿度_温度_下限 = "-10";
        private string _温湿度_温度_上限 = "40";
        private string _温湿度_湿度_下限 = "0";
        private string _温湿度_湿度_上限 = "100";
        private string _光照度_下限 = "0";
        private string _光照度_上限 = "400";
        private double _当前温度=20;
        
        public double 当前温度
        {
            get { return _当前温度; }
            set
            {
                _当前温度 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("当前温度"));
                }
            }
        }
        private double _当前光照度=100;
        public double 当前光照度
        {
            get { return _当前光照度; }
            set
            {
                _当前光照度 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("当前光照度"));
                }
            }
        }

        public string 温度_下限
        {
            get { return _温度_下限; }
            set
            {
                _温度_下限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("温度_下限"));
                }
            }
        }

        public string 温度_上限
        {
            get { return _温度_上限; }
            set
            {
                _温度_上限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("温度_上限"));
                }
            }
        }
        public string 光照度_下限
        {
            get { return _光照度_下限; }
            set
            {
                _光照度_上限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("光照度_下限"));
                }
            }
        }
        public string 光照度_上限
        {
            get { return _光照度_上限; }
            set
            {
                _光照度_上限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("光照度_上限"));
                }
            }
        }

        public string 温湿度_温度_下限
        {
            get { return _温湿度_温度_下限; }
            set
            {
                _温湿度_温度_下限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("温湿度_温度_下限"));
                }
            }
        }

        public string 温湿度_温度_上限
        {
            get { return _温湿度_温度_上限; }
            set
            {
                _温湿度_温度_上限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("温湿度_温度_上限"));
                }
            }
        }
        public string 温湿度_湿度_下限
        {
            get { return _温湿度_湿度_下限; }
            set
            {
                _温湿度_湿度_下限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("温湿度_湿度_下限"));
                }
            }
        }

        public string 温湿度_湿度_上限
        {
            get { return _温湿度_湿度_上限; }
            set
            {
                _温湿度_湿度_上限 = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("温湿度_湿度_上限"));
                }
            }
        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
