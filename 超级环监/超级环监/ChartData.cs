using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visifire.Charts;
namespace 超级环监
{
    class ChartData
    {
        public static List<LightDataPoint> List_datapoint_温度 = new List<LightDataPoint>();
        public static List<LightDataPoint> List_datapoint_光照 = new List<LightDataPoint>();
        public static List<LightDataPoint> List_datapoint_温湿度_温度 = new List<LightDataPoint>();
        public static List<LightDataPoint> List_datapoint_温湿度_湿度 = new List<LightDataPoint>();
        public ChartData()
        {
            LightDataPoint temp = new LightDataPoint();
            temp.YValue = 25;
            temp.AxisXLabel = "0";

            for (int i = 0; i <= 9; i++)
                List_datapoint_温度.Add(temp);    //初始化加十个25





            LightDataPoint temp2 = new LightDataPoint();
            temp2.YValue = 200;
            temp2.AxisXLabel = "0";

            for (int i = 0; i <= 9; i++)
                List_datapoint_光照.Add(temp2);    //初始化加十个200

            LightDataPoint temp3 = new LightDataPoint();
            temp.YValue = 25;
            temp.AxisXLabel = "0";

            for (int i = 0; i <= 9; i++)
                List_datapoint_温湿度_温度.Add(temp);    //初始化加十个25

            LightDataPoint temp4 = new LightDataPoint();
            temp.YValue = 50;
            temp.AxisXLabel = "0";

            for (int i = 0; i <= 9; i++)
                List_datapoint_温湿度_湿度.Add(temp);    //初始化加十个50


        }

        public DataPointCollection getDataPoints_温度()
        {
            DataPointCollection datapoints = new DataPointCollection();
            foreach (LightDataPoint x in List_datapoint_温度)
            {
                datapoints.Add(x);
            }
            return datapoints;
        }
        public DataPointCollection getDataPoints_光照()
        {
            DataPointCollection datapoints = new DataPointCollection();
            foreach (LightDataPoint x in List_datapoint_光照)
            {
                datapoints.Add(x);
            }
            return datapoints;
        }
        public DataPointCollection getDataPoints_温湿度_温度()
        {
            DataPointCollection datapoints = new DataPointCollection();
            foreach (LightDataPoint x in List_datapoint_温湿度_温度)
            {
                datapoints.Add(x);
            }
            return datapoints;
        }
        public DataPointCollection getDataPoints_温湿度_湿度()
        {
            DataPointCollection datapoints = new DataPointCollection();
            foreach (LightDataPoint x in List_datapoint_温湿度_湿度)
            {
                datapoints.Add(x);
            }
            return datapoints;
        }

        public DataPointCollection addPoint_温度(double temperature, int index)
        {
            List_datapoint_温度.RemoveAt(0);
            LightDataPoint datapoint = new LightDataPoint();
            datapoint.YValue = temperature;
            datapoint.AxisXLabel = index.ToString();
            List_datapoint_温度.Add(datapoint);
            return getDataPoints_温度();
        }
        public DataPointCollection addPoint_光照(double temperature, int index)
        {
            List_datapoint_光照.RemoveAt(0);
            LightDataPoint datapoint = new LightDataPoint();
            datapoint.YValue = temperature;
            datapoint.AxisXLabel = index.ToString();
            List_datapoint_光照.Add(datapoint);
            return getDataPoints_光照();
        }
        public DataPointCollection addPoint_温湿度_温度(double temperature, int index)
        {
            List_datapoint_温湿度_温度.RemoveAt(0);
            LightDataPoint datapoint = new LightDataPoint();
            datapoint.YValue = temperature;
            datapoint.AxisXLabel = index.ToString();
            List_datapoint_温湿度_温度.Add(datapoint);
            return getDataPoints_温湿度_温度();
        }
        public DataPointCollection addPoint_温湿度_湿度(double temperature, int index)
        {
            List_datapoint_温湿度_湿度.RemoveAt(0);
            LightDataPoint datapoint = new LightDataPoint();
            datapoint.YValue = temperature;
            datapoint.AxisXLabel = index.ToString();
            List_datapoint_温湿度_湿度.Add(datapoint);
            return getDataPoints_温湿度_湿度();
        }
    }
}
