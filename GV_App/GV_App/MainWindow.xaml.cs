using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using DevExpress.Xpf.Grid;
using GV_App.Controller;
using GV_App.Model;
using NetworkCommsDotNet;

namespace GV_App
{
     /// <summary>
     /// Interaction logic for MainWindow.xaml
     /// </summary>
     public partial class MainWindow : Window
     {
          GVApp gvApp;
          public MainWindow()
          {
               InitializeComponent();
               
               //Initialise the GV application
               gvApp = new GVApp(txtbIP, txtbPort, txtbValue, btnAdd, btnSend, gridctr);
               //Initialise the NetworkComms.Net settings
               gvApp.NetworkCommsConfiguration();
          }
          #region Event Handlers
          /// <summary>
          /// Update the server IP if changed
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void ServerIP_LostFocus(object sender, RoutedEventArgs e)
          {
               gvApp.ServerIPAddress = txtbIP.Text.Trim();
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
                    gvApp.ServerPort = portNumber;
               else
                    txtbPort.Text = "";
          }

          /// <summary>
          /// Send any entered message when we click the send button.
          /// </summary>
          /// <param name="sender"></param>
          /// <param name="e"></param>
          private void BtnAdd_Click(object sender, RoutedEventArgs e)
          {
               gvApp.SendMessage("1");
          }

          private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
          {
               //Ensure we shutdown comms when we are finished
               NetworkComms.Shutdown();
          }

          private void BtnSend_Click(object sender, RoutedEventArgs e)
          {
               gvApp.SendMessage(txtbValue.Text);
          }
          #endregion

          private void DataGrid_Loaded(object sender, RoutedEventArgs e)
          {
               var items = new List<ClientModel>();
               items.Add(new ClientModel("192.168.43.189", 3100, "HK", 123, "12333"));
               items.Add(new ClientModel("192.168.43.189", 3100, "HK", 123, "12333"));
               items.Add(new ClientModel("192.168.43.189", 3100, "HK", 123, "12333"));
               items.Add(new ClientModel("192.168.43.189", 3100, "HK", 123, "12333"));

               // ... Assign ItemsSource of DataGrid.
               var grid = sender as GridControl;
               grid.ItemsSource = items;
          }
     }
}
