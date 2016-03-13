using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;
using System.Net;
using System.Net.Sockets;
namespace 超级环监
{
    /// <summary>
    /// 登录.xaml 的交互逻辑
    /// </summary>
    public partial class 登录 : Window
    {
        ChartData chartdata = new ChartData();
        public 登录()
        {
            InitializeComponent();
            this.DataContext = ViewModel.getInstance();
        }
        private void PART_CLOSE_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void PART_MINIMIZE_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }
        private void PART_MAXIMIZE_RESTORE_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == System.Windows.WindowState.Normal)
            {
                this.WindowState = System.Windows.WindowState.Maximized;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
            }
        }
        private void PART_TITLEBAR_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void login(object sender, RoutedEventArgs e)
        {
            Button a = (Button)sender;
            a.IsEnabled = false;
            ViewModel vm = ViewModel.getInstance();
            IOT iot = IOT.getInstance();
            Thread t = new Thread(消息接收);
            

            iot.模块初始化();
            int result = iot.登录();
            if (result == 0) { MessageBox.Show("登陆失败"); return; }
            result = iot.设置UDP通知();
            if (result == 0) { MessageBox.Show("设置UDP通知失败"); return; }
            iot.XML_设置目录();
            result = iot.XML_请求更新文件();
            
            if (result == 0) { MessageBox.Show("请求更新文件失败"); return; }
            Thread.Sleep(500);
            
            t.Start();
            this.Close();
        }
        public void 消息接收()
        {
            int recv;
            byte[] data = new byte[1024];
            string msg;
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 10000);
            Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            newsock.Bind(ip);
            ViewModel vm = ViewModel.getInstance();
            IOT iot = IOT.getInstance();
            string value;
            string value2;
            while (true)
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint Remote = (EndPoint)(sender);
                recv = newsock.ReceiveFrom(data, ref Remote);
                msg = Encoding.ASCII.GetString(data, 0, recv);
                msg = 提取数据(msg);
                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input,new Action(() =>
              {

              }));

                if (msg != null)
                {
                    if (iot.Json_取数据包类型(msg) == "data")
                    {
                        if (iot.Json_取节点地址(msg) == iot.XML_获取设备节点信息("无线温度采集").nodeaddr)
                        {
                            if (iot.Json_取数值类型(msg) == "singledata" || iot.Json_取数值类型(msg) == "multidata")
                            {
                                value = iot.Json_取数值(msg, "temperature");
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.温度表.Add(new Model.温度表(value));
                                    vm.gauge.当前温度 = double.Parse(value);
                                    if(MainWindow.line1!=null)
                                    {
                                        MainWindow.line1.DataPoints = chartdata.addPoint_温度(double.Parse(value), Model.序号_温度);
                                    }
                                }));
                            }
                            else if (iot.Json_取数值类型(msg) == "querylimit")
                            {
                                value = iot.Json_取报警界限(msg, "temperature");
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.gauge.温度_下限= value.Split(',')[0];
                                    vm.gauge.温度_上限 = value.Split(',')[1];
                                }));
                            }
                            else if (iot.Json_取数值类型(msg) == "alarm")
                            {
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.温度报警表.Add(new Model.温度报警表("OutOfRange", "温度"));
                                }));
                            }
                        }
                        else if (iot.Json_取节点地址(msg) == iot.XML_获取设备节点信息("无线温湿度采集").nodeaddr)
                        {
                            if (iot.Json_取数值类型(msg) == "singledata" || iot.Json_取数值类型(msg) == "multidata")
                            {
                                value = iot.Json_取数值(msg, "temperature");
                                value2 = iot.Json_取数值(msg, "humidity");
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.温湿度表.Add(new Model.温湿度表(value, value2));
                                    MainWindow.line2_1.DataPoints = chartdata.addPoint_温湿度_温度(double.Parse(value), Model.序号_温湿度);
                                    MainWindow.line2_2.DataPoints = chartdata.addPoint_温湿度_湿度(double.Parse(value2), Model.序号_温湿度);
                                }));
                            }
                            else if (iot.Json_取数值类型(msg) == "querylimit")
                            {
                                value = iot.Json_取报警界限(msg, "temperature");
                                value2 = iot.Json_取报警界限(msg, "humidity");
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.gauge.温湿度_温度_下限 = value.Split(',')[0];
                                    vm.gauge.温湿度_温度_上限 = value.Split(',')[1];
                                    vm.gauge.温湿度_湿度_下限 = value2.Split(',')[0];
                                    vm.gauge.温湿度_湿度_上限 = value2.Split(',')[1];
                                }));
                            }
                            else if (iot.Json_取数值类型(msg) == "alarm")
                            {
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.温湿度报警表.Add(new Model.温湿度报警表("OutOfRange", "温湿度"));
                                }));
                            }
                        }
                        else if (iot.Json_取节点地址(msg) == iot.XML_获取设备节点信息("无线光照度采集").nodeaddr)
                        {
                            if (iot.Json_取数值类型(msg) == "singledata" || iot.Json_取数值类型(msg) == "multidata")
                            {
                                value = iot.Json_取数值(msg, "illuminance");
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.光照度表.Add(new Model.光照度表(value));
                                    vm.gauge.当前光照度 = double.Parse(value);
                                    MainWindow.line3.DataPoints = chartdata.addPoint_光照(double.Parse(value), Model.序号_光照度);
                                }));
                            }
                            else if (iot.Json_取数值类型(msg) == "querylimit")
                            {
                                value = iot.Json_取报警界限(msg, "illuminance");
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.gauge.光照度_下限 = value.Split(',')[0];
                                    vm.gauge.光照度_上限 = value.Split(',')[1];
                                }));
                            }
                            else if (iot.Json_取数值类型(msg) == "alarm")
                            {
                                this.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Input, new Action(() =>
                                {
                                    vm.光照度报警表.Add(new Model.光照度报警表("OutOfRange", "光照度"));
                                   
                                }));
                            }

                        }
                        else
                        {

                        }

                    }
                }




              
                
            }
        }
        public string 提取数据(string msg)
        {
            int i = 0;
            int L = -1;
            int R = -1;
            for (i = 0; i <= msg.Length - 1; i++)
            {
                if (msg[i] == '{')
                {
                    L = i;
                    break;
                }
            }
            if (L == -1) return null;
            for (i = 0; i <= msg.Length - 1; i++)
            {
                if (msg[i] == '}')
                {
                    R = i;
                }
            }
            return msg.Substring(L, R - L + 1);

        }
    }
}
