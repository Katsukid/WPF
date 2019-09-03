using NetworkCommsDotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TS_App.Controller;

namespace TS_App
{
     public partial class Form1 : Form
     {
          TSApp tsApp;
          public Form1()
          {
               InitializeComponent();

               tsApp = new TSApp(txtbIP, txtbPort, txtbClientPort, txtbReceive, txtbSend, cmbbSend, this);

               tsApp.NetworkCommsConfiguration(3200);
          }
          #region Event Handlers
          /// <summary>
          /// Send any entered message when we click the send button.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void SendMessageButton_Click(object sender, EventArgs e)
          {
               tsApp.SendMessage(txtbSend.Text, cmbbSend.SelectedValue.ToString());
          }

          private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
          {
               //Ensure we shutdown comms when we are finished
               NetworkComms.Shutdown();
          }
          /// <summary>
          /// Update the server IP if changed
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void ServerIP_LostFocus(object sender, EventArgs e)
          {
               tsApp.ServerIPAddress = txtbIP.Text.Trim();
          }

          /// <summary>
          /// Update the server port if changed
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void ServerPort_LostFocus(object sender, EventArgs e)
          {
               int portNumber;
               if (int.TryParse(txtbPort.Text, out portNumber))
                    tsApp.ServerPort = portNumber;
               else
                    txtbPort.Text = "";
          }
          /// <summary>
          /// Update the server port if changed
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void txtbSend_LostFocus(object sender, EventArgs e)
          {
               var temp = cmbbSend.Text;
               tsApp.SendMessage(txtbSend.Text, cmbbSend.Text);
          }

          private void cmbbSend_LostFocus(object sender, EventArgs e)
          {
               tsApp.SendMessage(txtbSend.Text, cmbbSend.Text);
          }
          #endregion

          private void TxtbClientPort_LostFocus(object sender, EventArgs e)
          {
               int port;
               if (txtbClientPort.Text.Trim() != "" && int.TryParse(txtbClientPort.Text, out port))
                    tsApp.NetworkCommsConfiguration(port);
          }
     }
}
