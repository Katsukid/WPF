using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using NetworkCommsDotNet.Connections;
using System.Windows;
using GN_App.Model;
using NetworkCommsDotNet.DPSBase;
using System.Threading;

namespace GN_App.Controller
{
     public class GNApp :GNBase
     {

          public TextBox txtbIP { get; set; }
          public TextBox txtbPort { get; set; }
          public TextBox txtbClientPort { get; set; }
          public TextBox txtbReceive { get; set; }
          public TextBox txtbSend { get; set; }
          public ComboBox cmbbSend { get; set; }

          public GNApp(TextBox txtbIP, TextBox txtbPort, TextBox txtbClientPort, TextBox txtbReceive, TextBox txtbSend, ComboBox cmbbSend)
               : base(HostInfo.HostName, ConnectionType.TCP)
          {
               this.txtbIP = txtbIP;
               this.txtbPort = txtbPort;
               this.txtbClientPort = txtbClientPort;
               this.txtbReceive = txtbReceive;
               this.txtbSend = txtbSend;
               this.cmbbSend = cmbbSend;
               this.Serializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
          }
          public override void DisplayValuesFromServer(int value)
          {
               Application.Current.Dispatcher.BeginInvoke(
               new ThreadStart(() => {
                    this.txtbReceive.Text = value.ToString();
               }));
          }

          public override void ShowMessage(string message)
          {
               MessageBox.Show(message);
          }
     }
}
