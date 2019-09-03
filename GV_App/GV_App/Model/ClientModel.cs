using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GV_App.Model
{
     public class ClientModel
     {
          public ClientModel(string iP, int port, string name, int value, string value2)
          {
               IP = iP;
               Port = port;
               Name = name;
               Value = value;
               Value2 = value2;
          }
          public ClientModel() { }
          public string IP { get; set; }
          public int Port { get; set; }
          public string Name { get; set; }
          public int Value { get; set; }
          public string Value2 { get; set; }
     }
}
