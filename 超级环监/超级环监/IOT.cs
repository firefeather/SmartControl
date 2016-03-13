using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace 超级环监
{
    public class IOT
    {
        //导入函数↓****************************************************************************************************************************
        [DllImport("libiot.dll", EntryPoint = "CM_Init")]
        private static extern int CM_Init(int nVer = 1);
        //初始化

        [DllImport("libiot.dll", EntryPoint = "CM_SetNVSXmlPath")]
        private static extern int CM_SetNVSXmlPath(int _CM_HANDLE, string pszNVSxmlPath);
        //设置xml目录

        [DllImport("libiot.dll", EntryPoint = "CM_SetNotifyWindow")]
        private static extern int CM_SetNotifyWindow(int _CM_HANDLE, int _WINDOWS_HANDLE);
        //设置窗口消息提醒

        [DllImport("libiot.dll", EntryPoint = "CM_Login")]
        private static extern int CM_Login(int _CM_HANDLE, string pszHost, string pszUsername, string pszPassword);
        //登陆

        [DllImport("libiot.dll", EntryPoint = "CM_Free")]
        private static extern int CM_Free(int _CM_HANDLE);
        //释放模块

        [DllImport("libiot.dll", EntryPoint = "CM_QueryNodesStatusOfNVS")]
        private static extern int CM_QueryNodesStatusOfNVS(int _CM_HANDLE, int nvsid);
        //请求结点信息

        [DllImport("libiot.dll", EntryPoint = "CM_SetIOTCallBack")]
        private static extern int CM_SetIOTCallBack(int _CM_HANDLE, short usPort);
        //设置数据改变回调函数

        [DllImport("libiot.dll", EntryPoint = "CM_IOT_LAMP_Ctrl")]
        private static extern int CM_IOT_LAMP_Ctrl(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int nOpCode);
        //控制灯泡
        //*********************************************************************************************************************************温度↓
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_TDC_SetLimit")]
        private static extern int CM_IOT_TDC_SetLimit(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, float low, float high);
        //设置温度报警范围
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_TDC_QueryLimit")]
        private static extern int CM_IOT_TDC_QueryLimit(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //查询结点温度报警范围
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_TDC_Sampling")]
        private static extern int CM_IOT_TDC_Sampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //温度结点单次采集

        [DllImport("libiot.dll", EntryPoint = "CM_IOT_TDC_StartContinuousSampling")]
        private static extern int CM_IOT_TDC_StartContinuousSampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int time, int count);
        //温度信息采集开启
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_TDC_StopContinuousSampling")]
        private static extern int CM_IOT_TDC_StopContinuousSampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //温度信息采集关闭*******************************************************************************************************************温度↑


        //**********************************************************************************************************************************温湿度↓
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_THDC_SetLimit")]
        private static extern int CM_IOT_THDC_SetLimit(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, float low, float high, float low2, float high2);
        //设置温湿度报警范围
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_THDC_QueryLimit")]
        private static extern int CM_IOT_THDC_QueryLimit(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //查询温湿度报警范围
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_THDC_Sampling")]
        private static extern int CM_IOT_THDC_Sampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //温湿度结点单次采集

        [DllImport("libiot.dll", EntryPoint = "CM_IOT_THDC_StartContinuousSampling")]
        private static extern int CM_IOT_THDC_StartContinuousSampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int time, int count);
        //温湿度信息采集开启
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_THDC_StopContinuousSampling")]
        private static extern int CM_IOT_THDC_StopContinuousSampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //温湿度信息采集关闭****************************************************************************************************************温湿度↑


        //**********************************************************************************************************************************光照度↓
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_IDC_SetLimit")]
        private static extern int CM_IOT_IDC_SetLimit(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, float low, float high);
        //设置光照度报警范围
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_IDC_QueryLimit")]
        private static extern int CM_IOT_IDC_QueryLimit(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //查询光照度报警范围
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_IDC_Sampling")]
        private static extern int CM_IOT_IDC_Sampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //光照度结点单次采集

        [DllImport("libiot.dll", EntryPoint = "CM_IOT_IDC_StartContinuousSampling")]
        private static extern int CM_IOT_IDC_StartContinuousSampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int time, int count);
        //光照度信息采集开启
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_IDC_StopContinuousSampling")]
        private static extern int CM_IOT_IDC_StopContinuousSampling(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID);
        //光照信息采集关闭****************************************************************************************************************光照度↑
        //*******************************************************************************************************************************门禁↓
        [DllImport("libiot.dll", EntryPoint = "CM_IOT_DAC_SetTime")]
        private static extern int CM_IOT_DAC_SetTime(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, string lpszTime);


        [DllImport(@"libiot.dll", EntryPoint = "CM_IOT_EC_Ctrl")]
        private static extern long CM_IOT_EC_Ctrl(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int nOpcode);


        [DllImport(@"libiot.dll", EntryPoint = "CM_IOT_CONTROLTC_Ctrl")]
        private static extern long CM_IOT_CONTROLTC_Ctrl(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int nOpcode);


        [DllImport(@"libiot.dll", EntryPoint = "CM_IOT_POWER_Ctrl")]
        private static extern long CM_IOT_POWER_Ctrl(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int nOpcode);


        [DllImport(@"libiot.dll", EntryPoint = "CM_IOT_WCAW_Ctrl")]
        private static extern long CM_IOT_WCAW_Ctrl(int _CM_HANDLE, int ulNvsID, int ulNetID, int ulNodID, int mSecound);

          [DllImport(@"libiot.dll", EntryPoint = "CM_SetNotifyUDPPort")]
        private static extern int CM_SetNotifyUDPPort(int _CM_HANDLE, int port);

        





        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        private static extern int FindWindow(string lpClassName, string lpWindowName);
        //获取窗口句柄
        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(int Hwnd, int msg, int wParam, int Iparam);
        //导入函数↑****************************************************************************************************************************
        private IOT()
        { }
        private static IOT Instance = null;
        public static IOT getInstance()
        {
            if (Instance == null) Instance = new IOT();
            return Instance;

        }
       
        private static int _CM_HANDLE = 0;
        private static int CM_HANDLE
        {
            get
            {
                if (_CM_HANDLE == 0)
                    MessageBox.Show("模块句柄为0！");
                return _CM_HANDLE;
            }
            set
            {
                _CM_HANDLE = value;
            }

        }

        

        private static XmlDocument doc = new XmlDocument();
        public class NodeInfo
        {

            public int netid = 0;
            public int nodeaddr = 0;
        }

        public void 模块初始化()
        {
            CM_HANDLE = CM_Init();

        }
        public int 登录()
        {
            ViewModel vm = ViewModel.getInstance();
            return CM_Login(CM_HANDLE, vm.model.IP, vm.model.用户名, vm.model.密码);

        }
        public int 设置UDP通知()
        {
            return CM_SetNotifyUDPPort(CM_HANDLE, 10000);
        }

       

        public void 开灯(int index)
        {
            ViewModel vm = ViewModel.getInstance();
            if (index != 1 && index != 2 && index != 3)
            {
                MessageBox.Show("获取灯节点信息失败" + index.ToString());
            }
            string temp = "灯";
            temp += index.ToString();
            NodeInfo TheNode = XML_获取设备节点信息(temp);
            CM_IOT_LAMP_Ctrl(CM_HANDLE, int.Parse( vm.model.nvsid), TheNode.netid, TheNode.nodeaddr, 1);

        }
        public void 关灯(int index)
        {
            if (index != 1 && index != 2 && index != 3)
            {
                MessageBox.Show("获取灯节点信息失败" + index.ToString());
            }
            string temp = "灯";
            temp += index.ToString();
            NodeInfo TheNode = XML_获取设备节点信息(temp);
            CM_IOT_LAMP_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 0);

        }
        //**********************************************************************************************************温度↓
        public void 设置温度报警范围()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线温度采集");
            CM_IOT_TDC_SetLimit(CM_HANDLE, int.Parse(vm.model.nvsid), TheNode.netid, TheNode.nodeaddr, float.Parse(vm.gauge.温度_下限), float.Parse(vm.gauge.温度_上限));
        }
        public void 查询温度报警范围()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线温度采集");
            CM_IOT_TDC_QueryLimit(CM_HANDLE, int.Parse(vm.model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }


        public void 开启温度连续取样()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线温度采集");
            CM_IOT_TDC_StartContinuousSampling(CM_HANDLE, int.Parse(vm.model.nvsid), TheNode.netid, TheNode.nodeaddr, 1000, 1);

        }
        public void 关闭温度连续取样()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线温度采集");
            CM_IOT_TDC_StopContinuousSampling(CM_HANDLE, int.Parse(vm.model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        public void 温度单次取样()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线温度采集");
            CM_IOT_TDC_Sampling(CM_HANDLE, int.Parse(vm.model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        //*********************************************************************************************************温度↑
        //*********************************************************************************************************温湿度↓
        public void 设置温湿度报警范围()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线温湿度采集");
            CM_IOT_THDC_SetLimit(CM_HANDLE, int.Parse(vm.model.nvsid), TheNode.netid, TheNode.nodeaddr, float.Parse(vm.gauge.温湿度_温度_下限), float.Parse(vm.gauge.温湿度_温度_上限), float.Parse(vm.gauge.温湿度_湿度_下限), float.Parse(vm.gauge.温湿度_湿度_上限));
            
        
        }
        public void 查询温湿度报警范围()
        {
            
            NodeInfo TheNode = XML_获取设备节点信息("无线温湿度采集");
            CM_IOT_THDC_QueryLimit(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        public void 开启温湿度连续取样()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线温湿度采集");
            CM_IOT_THDC_StartContinuousSampling(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 1000, 1);

        }
        public void 关闭温湿度连续取样()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线温湿度采集");
            CM_IOT_THDC_StopContinuousSampling(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        public void 温湿度单次取样()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线温湿度采集");
            CM_IOT_THDC_Sampling(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        //*********************************************************************************************************温湿度↑
        //*********************************************************************************************************光照↓
        public void 设置光照报警范围()
        {
            ViewModel vm = ViewModel.getInstance();
            NodeInfo TheNode = XML_获取设备节点信息("无线光照度采集");
            CM_IOT_IDC_SetLimit(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, float.Parse(vm.gauge.光照度_下限), float.Parse(vm.gauge.光照度_上限));
        }
        public void 查询光照报警范围()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线光照度采集");
            CM_IOT_IDC_QueryLimit(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }


        public void 开启光照连续取样()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线光照度采集");
            CM_IOT_IDC_StartContinuousSampling(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 1000, 1);

        }
        public void 关闭光照连续取样()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线光照度采集");
            CM_IOT_IDC_StopContinuousSampling(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        public void 光照单次取样()
        {
            NodeInfo TheNode = XML_获取设备节点信息("无线光照度采集");
            CM_IOT_IDC_Sampling(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr);
        }
        //*********************************************************************************************************光照↑
        public void 打开窗帘()
        {
            NodeInfo TheNode = XML_获取设备节点信息("窗帘");
            CM_IOT_EC_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 1);
        }
        public void 关闭窗帘()
        {
            NodeInfo TheNode = XML_获取设备节点信息("窗帘");
            CM_IOT_EC_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 2);
        }

        public void 暂停窗帘()
        {
            NodeInfo TheNode = XML_获取设备节点信息("窗帘");
            CM_IOT_EC_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 0);
        }
        public void 实验箱开启()
        {
            NodeInfo TheNode = XML_获取设备节点信息("实验箱取电");
            CM_IOT_CONTROLTC_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 1);
        }
        public void 实验箱关闭()
        {
            NodeInfo TheNode = XML_获取设备节点信息("实验箱取电");
            CM_IOT_CONTROLTC_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 0);
        }
        public void 电源开启()
        {
            NodeInfo TheNode = XML_获取设备节点信息("电源控制");
            CM_IOT_POWER_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 1);
        }
        public void 电源关闭()
        {
            NodeInfo TheNode = XML_获取设备节点信息("电源控制");
            CM_IOT_POWER_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, 0);
        }
        public void 警笛(int seconds)
        {
            NodeInfo TheNode = XML_获取设备节点信息("警笛");
            CM_IOT_WCAW_Ctrl(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid), TheNode.netid, TheNode.nodeaddr, seconds);
        }

        public string Json_取数值(string msg, string name)//name为"temperature"或者其他
        {
            JObject obj = JObject.Parse(msg);
            string temp = Json_取数值类型(msg);
            if (temp == "multidata")
            {
                temp = obj["data"][name]["value"].ToString();
                string a = temp;

                int L = -1, R = -1;
                for (int i = 0; i <= a.Length - 1; i++)
                {
                    if (L == -1 && '0' <= a[i] && a[i] <= '9')//a[i]是数字且 L没有被赋值过
                    {
                        L = i;
                    }
                    if (R == -1 && ((a[i] > '9' || a[i] < '0') && a[i] != '.') && L != -1)//a[i]不是数字 且L被赋值过 且R没有被赋值过 可以是点
                    {
                        R = i - 1;
                        break;
                    }

                }
                string substring = a.Substring(L, R - L + 1);
                if (substring.Length >= 6) return substring.Substring(0, 5);
                return substring;
            }
            else if (temp == "singledata")
            {
                temp = obj["data"][name]["value"].ToString();
                string a = temp;


                string substring = temp;
                if (substring.Length >= 6) return substring.Substring(0, 5);
                return substring;
            }
            else
            {

            }
            return null;
        }
        public string Json_取报警界限(string msg, string name)//以,分割
        {
            JObject obj = JObject.Parse(msg);
            string temp = Json_取数值类型(msg);
            if (temp == "querylimit")
            {
                temp = obj["data"][name]["value"].ToString();
                string a = temp;
                string value1;
                string value2;
                int L = -1, R = -1;
                for (int i = 0; i <= a.Length - 1; i++)
                {
                    if (L == -1 && (a[i] == '-' || ('0' <= a[i] && a[i] <= '9')))//a[i]是有效的
                    {
                        L = i;
                    }
                    if (L != -1 && !(a[i] == '-' || ('0' <= a[i] && a[i] <= '9') || a[i] == '.') && R == -1)//a[i]刚刚无效
                    {
                        R = i - 1; break;
                    }

                }

                string substring = a.Substring(L, R - L + 1);
                value1 = a.Substring(L, R - L + 1);
                int L2 = -1, R2 = -1;
                for (int i = R + 1; i <= a.Length - 1; i++)
                {
                    if (L2 == -1 && (a[i] == '-' || ('0' <= a[i] && a[i] <= '9')))//a[i]刚刚有效
                    {
                        L2 = i;
                    }
                    if (L2 != -1 && !(a[i] == '-' || ('0' <= a[i] && a[i] <= '9') || a[i] == '.') && R2 == -1)//a[i]刚刚无效
                    {
                        R2 = i - 1; break;
                    }

                }
                value2 = a.Substring(L2, R2 - L2 + 1);
                substring = value1 + "," + value2;
                return substring;
            }
            return null;
        }
        public string Json_取数值类型(string msg)
        {
            JObject obj = JObject.Parse(msg);
            string temp = obj["msg"].ToString();
            return temp;
        }
        public int Json_取节点地址(string msg)
        {
            if (Json_取数据包类型(msg) == "data")
            {

                JObject obj = JObject.Parse(msg);

                return int.Parse(obj["nodid"].ToString());
            }
            return 0;
        }
        public string Json_取数据包类型(string msg)
        {
            if (msg == null) return null;
            int L = -1, R = -1;
            for (int i = 0; i <= msg.Length - 1; i++)
            {
                if (L == -1 && msg[i] == '\"')
                {
                    L = i;
                }
                if (L != -1 && msg[i] == '\"' && L != i && R == -1)
                {
                    R = i;
                }

            }
            return msg.Substring(L + 1, R - 2);

        }
        public void XML_设置目录()
        {
            CM_SetNVSXmlPath(CM_HANDLE, @".\xml");
        }
        public int XML_请求更新文件()
        {

            int result = CM_QueryNodesStatusOfNVS(CM_HANDLE, int.Parse(ViewModel.getInstance().model.nvsid));
            return result;
        }
        public void XML_载入文件()
        {

            doc.Load(@".\xml\nvs_5526.xml");
        }
        public NodeInfo XML_获取设备节点信息(string 设备名)
        {
            XML_载入文件();
            NodeInfo TheNode = new NodeInfo();
            string SelectString = @"/viworld/nvs/nodes/node[name='" + 设备名 + @"']";

            XmlNodeList nodelist = doc.SelectNodes(SelectString);
            TheNode.netid = int.Parse(getNodeValue(nodelist.Item(0), "netid"));
            TheNode.nodeaddr = int.Parse(getNodeValue(nodelist.Item(0), "nodeaddr"));
            return TheNode;
        }

        private static string getNodeValue(XmlNode node, string name)//获取xml结点中名为name的结点的InnerText
        {
            foreach (XmlNode xm in node.ChildNodes)
            {
                if (xm.Name == name)
                {
                    return xm.InnerText;
                }
            }
            return null;
        }






    }
}
