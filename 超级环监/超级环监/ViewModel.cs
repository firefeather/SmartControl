using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
namespace 超级环监
{
 public class ViewModel
    {
 
     private static ViewModel Instance = null;
     public ObservableCollection<Model.温度表> 温度表 { get; set; }
     public ObservableCollection<Model.温度报警表> 温度报警表 { get; set; }
     public ObservableCollection<Model.温湿度表> 温湿度表 { get; set; }
     public ObservableCollection<Model.温湿度报警表> 温湿度报警表 { get; set; }
     public ObservableCollection<Model.光照度表> 光照度表 { get; set; }
     public ObservableCollection<Model.光照度报警表> 光照度报警表 { get; set; }


     public Model model { get; set; }
     public Gauge gauge { get; set; }
     public static ViewModel  getInstance()
     {
         if (Instance != null) return Instance;
         Instance = new ViewModel();
         return Instance;
     }
    private ViewModel()
     {
         this.model = new Model();
         this.gauge = new Gauge();
         温度表 = new ObservableCollection<Model.温度表>();
         温度报警表 = new ObservableCollection<Model.温度报警表>();
         温湿度表 = new ObservableCollection<Model.温湿度表>();
         温湿度报警表 = new ObservableCollection<Model.温湿度报警表>();
         光照度表 = new ObservableCollection<Model.光照度表>();
         光照度报警表 = new ObservableCollection<Model.光照度报警表>();
     }
       
        
        
    }
}
