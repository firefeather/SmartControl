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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF.Themes;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Media.Animation;
using Visifire.Charts;
namespace 超级环监
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isloaded = false;
        private System.Windows.Forms.Integration.WindowsFormsHost host = null;
        private AxCMTECHVIDEOLib.AxCMTechVideo sp = null;
        ViewModel vm = ViewModel.getInstance();
        IOT iot = IOT.getInstance();
        Storyboard 窗帘开=new Storyboard();
        Storyboard 窗帘停=new Storyboard();
        Storyboard 窗帘关=new Storyboard();
        public static DataSeries line1 = new DataSeries() { RenderAs = RenderAs.Spline };
        public static DataSeries line2_1 = new DataSeries() { RenderAs = RenderAs.Spline };
        public static DataSeries line2_2 = new DataSeries() { RenderAs = RenderAs.Spline };
        public static DataSeries line3 = new DataSeries() { RenderAs = RenderAs.Spline };
        public static Chart c1;
        public static Chart c2;
        public static Chart c3;
        public MainWindow()
        {
          
            
            this.DataContext = ViewModel.getInstance();
            登录 a = new 登录();
            a.Show();

            InitializeComponent();


            DoubleAnimation 动画 = new DoubleAnimation();
            动画.To = 100;
            动画.Duration = TimeSpan.FromMilliseconds(43.0 * (100 - progress.Value));
            Storyboard.SetTargetName(动画, progress.Name);
            Storyboard.SetTargetProperty(动画, new PropertyPath(ProgressBar.ValueProperty));
            窗帘开.Children.Add(动画);
            动画 = new DoubleAnimation();
            动画.To = 0;
            动画.Duration = TimeSpan.FromMilliseconds(43.0 * progress.Value);
            Storyboard.SetTargetName(动画, progress.Name);
            Storyboard.SetTargetProperty(动画, new PropertyPath(ProgressBar.ValueProperty));
            窗帘关.Children.Add(动画);

            c1 = chart1;
            c2 = chart2;
            c3 = chart3;
            c1.View3D = true;
            c2.View3D = true;
            c3.View3D = true;
            c1.Series.Add(line1);
            c2.Series.Add(line2_1);
            c2.Series.Add(line2_2);
            c3.Series.Add(line3);
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

        private void setting_click(object sender, MouseButtonEventArgs e)
        {
            setting a=new setting();
            a.ShowDialog();
        }

        private void video_open(object sender, RoutedEventArgs e)
        {
            if (isloaded == false)
            {
                host = new System.Windows.Forms.Integration.WindowsFormsHost();
                sp = new AxCMTECHVIDEOLib.AxCMTechVideo();
                host.Child = sp;
                video.Children.Add(host);
            }
            sp.OpenSrvCam(vm.model.IP, vm.model.用户名, vm.model.密码, int.Parse(vm.model.nvsid));
        }

        private void video_close(object sender, RoutedEventArgs e)
        {
            sp.CloseCam();
        }

  



        private void 温度_查询范围(object sender, RoutedEventArgs e)
        {
            
        }

        private void about_click(object sender, MouseButtonEventArgs e)
        {
            关于 a = new 关于();
            a.Show();
        }

        private void 登录测试(object sender, RoutedEventArgs e)
        {
            
            
            登录 a = new 登录();
            a.Show();
            
        }

        private void 实验箱开关(object sender, RoutedEventArgs e)
        {
            if(箱开关.IsChecked==true)
            iot.实验箱开启();
            else
            {
                iot.实验箱关闭();
            }

        }

        private void 灯1开关(object sender, RoutedEventArgs e)
        {
            if (灯1.IsChecked == true)
                iot.开灯(3);
            else
                iot.关灯(3);
        }

        private void 灯2开关(object sender, RoutedEventArgs e)
        {
            if (灯2.IsChecked == true)
                iot.开灯(2);
            else
                iot.关灯(2);
        }

        private void 灯3开关(object sender, RoutedEventArgs e)
        {
            if (灯3.IsChecked == true)
                iot.开灯(1);
            else
                iot.关灯(1);
        }

        private void 智能插座开关(object sender, RoutedEventArgs e)
        {
            if (智能插座.IsChecked == true)
                iot.电源开启();
            else
                iot.电源关闭();
        }

        private void 窗帘_开(object sender, RoutedEventArgs e)
        {
       
            窗帘开.Begin(this,true);
            
            
            iot.打开窗帘();
            
           
        }

        private void 窗帘_停(object sender, RoutedEventArgs e)
        {
            窗帘开.Pause(this);
            窗帘停.Pause(this);
            iot.暂停窗帘();
        }

        private void 窗帘_关(object sender, RoutedEventArgs e)
        {
        
            窗帘关.Begin(progress,true);


            iot.关闭窗帘();
        }

        private void 开启多次温度取样(object sender, RoutedEventArgs e)
        {
            iot.开启温度连续取样();
        }

        private void 关闭多次温度取样(object sender, RoutedEventArgs e)
        {
            iot.关闭温度连续取样();
        }

        private void 温度单次取样(object sender, RoutedEventArgs e)
        {
            iot.温度单次取样();
        }

        private void 开启多次温湿度取样(object sender, RoutedEventArgs e)
        {
            iot.开启温湿度连续取样();
        }

        private void 关闭多次温湿度取样(object sender, RoutedEventArgs e)
        {
            iot.关闭温湿度连续取样();
        }

        private void 单次温湿度取样(object sender, RoutedEventArgs e)
        {
            iot.温湿度单次取样();
        }

        private void 开启多次光照度取样(object sender, RoutedEventArgs e)
        {
            iot.开启光照连续取样();
        }

        private void 关闭多次光照度取样(object sender, RoutedEventArgs e)
        {
            iot.关闭光照连续取样();
        }

        private void 单次光照度取样(object sender, RoutedEventArgs e)
        {
            iot.光照单次取样();
        }

      

        private void 温度应用范围(object sender, RoutedEventArgs e)
        {
            iot.设置温度报警范围();
            vm.gauge.当前温度 = -5;
        }



   
        private void 光照度应用范围(object sender, RoutedEventArgs e)
        {
            iot.设置光照报警范围();
        }

        private void 光照度查询范围(object sender, RoutedEventArgs e)
        {
            iot.查询光照报警范围();
        }

        private void 温度查询范围(object sender, RoutedEventArgs e)
        {
            iot.查询温度报警范围();
        }

        private void 温湿度查询范围(object sender, RoutedEventArgs e)
        {
            iot.查询温湿度报警范围();
        }

        private void 温湿度设置范围(object sender, RoutedEventArgs e)
        {
            iot.设置温湿度报警范围();
        }

        private void 报警(object sender, RoutedEventArgs e)
        {
            iot.警笛(int.Parse(time.Text));
        }

        private void 关闭报警(object sender, RoutedEventArgs e)
        {
            iot.警笛(100);
        }

    }
}
