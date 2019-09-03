using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NetworkCommsDotNet;
using NetworkCommsDotNet.DPSBase;
using System.Net;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Tools;
using NetworkCommsDotNet.Connections.TCP;
using NetworkCommsDotNet.Connections.UDP;
using TS_App.Model;

namespace TS_App.Controller
{
     /// <summary>
     /// In an attempt to keep things as clear as possible all shared implementation across chat examples
     /// has been provided in this base class.
     /// </summary>
     public abstract class TSBase
     {
          #region Private Fields
          /// <summary>
          /// A boolean used to track the very first initialisation
          /// </summary>
          protected bool FirstInitialisation { get; set; }

          #endregion

          #region Public Fields
          /// <summary>
          /// The type of connection currently used to send and receive messages. Default is TCP.
          /// </summary>
          public ConnectionType ConnectionType { get; set; }

          /// <summary>
          /// The serializer to use
          /// </summary>
          public DataSerializer Serializer { get; set; }

          /// <summary>
          /// The IP address of the server 
          /// </summary>
          public string ServerIPAddress { get; set; }

          /// <summary>
          /// The port of the server
          /// </summary>
          public int ServerPort { get; set; }

          /// <summary>
          /// The local name used when sending messages
          /// </summary>
          public string LocalName { get; set; }

          #endregion
          /// <summary>
          /// Constructor for SendBase
          /// </summary>
          public TSBase(string name, ConnectionType connectionType)
          {
               LocalName = name;
               ConnectionType = connectionType;
               //Initialise the default values
               ServerIPAddress = "";
               ServerPort = 10000;
               FirstInitialisation = true;
          }
          #region NetworkComms.Net Methods
          public void NetworkCommsConfiguration(int port)
          {
               #region First Initialisation
               //On first initialisation we need to configure NetworkComms.Net to handle our incoming packet types
               //We only need to add the packet handlers once. If we call NetworkComms.Shutdown() at some future point these are not removed.
               if (FirstInitialisation)
               {
                    FirstInitialisation = false;

                    //Configure NetworkComms.Net to handle any incoming packet of type 'ChatMessage'
                    //e.g. If we receive a packet of type 'ChatMessage' execute the method 'HandleIncomingChatMessage'
                    NetworkComms.AppendGlobalIncomingPacketHandler<DataReceiveModel>("ServerMessage", HandleIncomingChatMessage);
               }
               #endregion
               #region Set serializer
               //Set the default send receive options to use the specified serializer. Keep the DataProcessors and Options from the previous defaults
               NetworkComms.DefaultSendReceiveOptions = new SendReceiveOptions(Serializer, NetworkComms.DefaultSendReceiveOptions.DataProcessors, NetworkComms.DefaultSendReceiveOptions.Options);
               #endregion

               #region Listen
               //Start listening for new incoming TCP connections
               //Can replace IPAddress.Any with IPAddress.Parse("A string of specify IP address but must exsist in command ipconfig in cmd")
               Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, port));
               #endregion
          }
          /// <summary>
          /// Performs whatever functions we might so desire when we receive an incoming ChatMessage
          /// </summary>
          /// <param name="header">The PacketHeader corresponding with the received object</param>
          /// <param name="connection">The Connection from which this object was received</param>
          /// <param name="incomingMessage">The incoming ChatMessage we are after</param>
          protected virtual void HandleIncomingChatMessage(PacketHeader header, Connection connection, DataReceiveModel incomingMessage)
          {        
               DisplayValuesFromServer(incomingMessage.Value);
          }

          public void SendMessage(string numValue, string strValue)
          {
               //If we have tried to send a zero length string we just return
               if (strValue.Trim() == "" && numValue.Trim() == "") return;

               //We may or may not have entered some server connection information
               ConnectionInfo serverConnectionInfo = null;
               if (ServerIPAddress != "")
               {
                    try { serverConnectionInfo = new ConnectionInfo(ServerIPAddress, ServerPort); }
                    catch (Exception)
                    {
                         ShowMessage("Failed to parse the server IP and port. Please ensure it is correct and try again");
                         return;
                    }
               }
               // Check if input value is number
               int value = 0;
               int.TryParse(numValue, out value);
               //We wrap everything we want to send in the ChatMessage class we created
               DataSendModel message = new DataSendModel(NetworkComms.NetworkIdentifier, LocalName, value, strValue);
               //We write our own message to the chatBox
               //AppendLineToChatHistory(message.SourceName + " - " + message.Message);

               //If we provided server information we send to the server first
               if (serverConnectionInfo != null)
               {
                    //We perform the send within a try catch to ensure the application continues to run if there is a problem.
                    try
                    {
                         TCPConnection.GetConnection(serverConnectionInfo).SendObject("ClientMessage", message);
                    }
                    catch (CommsException) { }
                    catch (Exception) { }
               }
               return;
          }
          #endregion
          #region GUI Interface Methods
          /// <summary>
          /// Append the provided message to the chat history text box.
          /// </summary>
          /// <param name="message">Message to be appended</param>
          public abstract void DisplayValuesFromServer(int value);

          /// <summary>
          /// Show a message box as an alternative to writing to the chat history
          /// </summary>
          /// <param name="message">Message to be output</param>
          public abstract void ShowMessage(string message);
          #endregion
     }
}
