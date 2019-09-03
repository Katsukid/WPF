using NetworkCommsDotNet.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetworkCommsDotNet.Connections;
using System.Windows;
using TS_App.Model;
using NetworkCommsDotNet.DPSBase;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
namespace TS_App.Controller
{
     public class TSApp : TSBase
     {

          public TextBox txtbIP { get; set; }
          public TextBox txtbPort { get; set; }
          public TextBox txtbClientPort { get; set; }
          public TextBox txtbReceive { get; set; }
          public TextBox txtbSend { get; set; }
          public ComboBox cmbbSend { get; set; }
          public Form form { get; set; }

          public TSApp(TextBox txtbIP, TextBox txtbPort, TextBox txtbClientPort, TextBox txtbReceive, TextBox txtbSend, ComboBox cmbbSend,Form form)
               : base(HostInfo.HostName, ConnectionType.TCP)
          {
               this.txtbIP = txtbIP;
               this.txtbPort = txtbPort;
               this.txtbClientPort = txtbClientPort;
               this.txtbReceive = txtbReceive;
               this.txtbSend = txtbSend;
               this.cmbbSend = cmbbSend;
               this.form = form;
               this.Serializer = DPSManager.GetDataSerializer<ProtobufSerializer>();
          }
          public override void DisplayValuesFromServer(int value)
          {
               this.form.Invoke(new ThreadStart(() => { txtbReceive.Text = value.ToString(); }));
          }

          public override void ShowMessage(string message)
          {
               System.Windows.MessageBox.Show(message);
          }
     }
}
