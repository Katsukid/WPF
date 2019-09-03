using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
using GN_App.Controller;
using GN_App.Model;
using NetworkCommsDotNet;

namespace GN_App
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow : Window
     {
          GNApp gnApp;
          public MainWindow()
          {
               InitializeComponent();

               gnApp = new GNApp(txtbIP, txtbPort, txtbClientPort, txtbReceive,txtbSend, cmbbSend);

               gnApp.NetworkCommsConfiguration(3100);
          }

          #region Event Handlers
          /// <summary>
          /// Send any entered message when we click the send button.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void SendMessageButton_Click(object sender, RoutedEventArgs e)
          {
               gnApp.SendMessage(txtbSend.Text,cmbbSend.SelectedValue.ToString());
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
          private void ServerIP_LostFocus(object sender, RoutedEventArgs e)
          {
               gnApp.ServerIPAddress = txtbIP.Text.Trim();
          }

          /// <summary>
          /// Update the server port if changed
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void ServerPort_LostFocus(object sender, RoutedEventArgs e)
          {
               int portNumber;
               if (int.TryParse(txtbPort.Text, out portNumber))
                    gnApp.ServerPort = portNumber;
               else
                    txtbPort.Text = "";
          }
          /// <summary>
          /// Update the server port if changed
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void txtbSend_LostFocus(object sender, RoutedEventArgs e)
          {
               var temp = cmbbSend.Text;
               gnApp.SendMessage(txtbSend.Text, cmbbSend.Text);
          }

          private void cmbbSend_LostFocus(object sender, RoutedEventArgs e)
          {
               gnApp.SendMessage(txtbSend.Text, cmbbSend.Text);
          }
          #endregion

          private void TxtbClientPort_LostFocus(object sender, RoutedEventArgs e)
          {
               int port;
               if (txtbClientPort.Text.Trim()!="" && int.TryParse(txtbClientPort.Text, out port))
                    gnApp.NetworkCommsConfiguration(port);
          }
     }
}
