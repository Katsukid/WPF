using DevExpress.Xpf.Grid;
using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using NetworkCommsDotNet.Connections;
using System.Windows;
using GV_App.Model;
using NetworkCommsDotNet.DPSBase;
using System.Windows.Threading;
using System.Threading;

namespace GV_App.Controller
{
      public class GVApp : GVBase
     {
          public TextBox txtbIP;
          public TextBox txtbPort;
          public TextBox txtbValue;
          public Button btnAdd;
          public Button btnSend;
          public GridControl gridctr;

          public GVApp(TextBox txtbIP, TextBox txtbPort, TextBox txtbValue, Button btnAdd, Button btnSend, GridControl gridctr) 
               : base(HostInfo.HostName, ConnectionType.TCP)
          {
               this.txtbIP = txtbIP;
               this.txtbPort = txtbPort;
               this.txtbValue = txtbValue;
               this.btnAdd = btnAdd;
               this.btnSend = btnSend;
               this.gridctr = gridctr;
               this.Serializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
          }

          public override void DisplayValuesFromClient(List<ClientModel> ls)
          {

               Application.Current.Dispatcher.BeginInvoke(
               new ThreadStart(() => {
                    gridctr.ItemsSource = null;
                    gridctr.ItemsSource = ls; }));
          }

          public override void ShowMessage(string message)
          {
               MessageBox.Show(message);
          }
     }
}
