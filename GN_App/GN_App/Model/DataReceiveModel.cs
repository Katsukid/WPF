using NetworkCommsDotNet.DPSBase;
using NetworkCommsDotNet.Tools;
using Newtonsoft.Json;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GN_App.Model
{
     [ProtoContract]
     [JsonObject(MemberSerialization.OptIn)]
     public class DataReceiveModel : IExplicitlySerialize
     {
          /// <summary>
          /// The source identifier of this ChatMessage.
          /// We use this variable as the constructor for the ShortGuid.
          /// The [ProtoMember(1)] attribute informs the serialiser that when
          /// an object of type ChatMessage is serialised we want to include this variable
          /// </summary>
          [ProtoMember(1)]
          [JsonProperty]
          string _sourceIdentifier;

          /// <summary>
          /// The source identifier is accessible as a ShortGuid
          /// </summary>
          public ShortGuid SourceIdentifier { get { return new ShortGuid(_sourceIdentifier); } }

          /// <summary>
          /// The name of the source of this ChatMessage. 
          /// We use shorthand declaration, get and set.
          /// The [ProtoMember(2)] attribute informs the serialiser that when
          /// an object of type ChatMessage is serialised we want to include this variable 
          /// </summary>
          [ProtoMember(2)]
          [JsonProperty]
          public string SourceName { get; private set; }

          /// <summary>
          /// The actual message.
          /// </summary>
          [ProtoMember(3)]
          [JsonProperty]
          public int Value { get; private set; }

          //[ProtoMember(4)]
          //[JsonProperty]
          //public string Value2 { get; private set; }
          /// <summary>
          /// We must include a private constructor to be used by the deserialisation step.
          /// </summary>
          private DataReceiveModel() { }

          /// <summary>
          /// Create a new ChatMessage
          /// </summary>
          /// <param name="sourceIdentifier">The source identifier</param>
          /// <param name="sourceName">The source name</param>
          /// <param name="message">The message to be sent</param>
          public DataReceiveModel(ShortGuid sourceIdentifier, string sourceName, int value1)
          {
               this._sourceIdentifier = sourceIdentifier;
               this.SourceName = sourceName;
               this.Value = value1; // test int number
               //this.Value2 = value2; // test string value
          }
          public void Serialize(System.IO.Stream outputStream)
          {
               List<byte[]> data = new List<byte[]>();

               byte[] sourceIDData = Encoding.UTF8.GetBytes(_sourceIdentifier);
               byte[] sourceIDLengthData = BitConverter.GetBytes(sourceIDData.Length);

               data.Add(sourceIDLengthData); data.Add(sourceIDData);

               byte[] sourceNameData = Encoding.UTF8.GetBytes(SourceName);
               byte[] sourceNameLengthData = BitConverter.GetBytes(sourceNameData.Length);

               data.Add(sourceNameLengthData); data.Add(sourceNameData);

               byte[] value1Data = BitConverter.GetBytes(Value);

               data.Add(value1Data);

               foreach (byte[] datum in data)
                    outputStream.Write(datum, 0, datum.Length);
          }

          public void Deserialize(System.IO.Stream inputStream)
          {
               byte[] sourceIDLengthData = new byte[sizeof(int)]; inputStream.Read(sourceIDLengthData, 0, sizeof(int));
               byte[] sourceIDData = new byte[BitConverter.ToInt32(sourceIDLengthData, 0)]; inputStream.Read(sourceIDData, 0, sourceIDData.Length);
               _sourceIdentifier = new String(Encoding.UTF8.GetChars(sourceIDData));

               byte[] sourceNameLengthData = new byte[sizeof(int)]; inputStream.Read(sourceNameLengthData, 0, sizeof(int));
               byte[] sourceNameData = new byte[BitConverter.ToInt32(sourceNameLengthData, 0)]; inputStream.Read(sourceNameData, 0, sourceNameData.Length);
               SourceName = new String(Encoding.UTF8.GetChars(sourceNameData));

               byte[] value1Data = new byte[sizeof(int)]; inputStream.Read(value1Data, 0, sizeof(int));
               Value = BitConverter.ToInt32(value1Data, 0);
          }

          public static void Deserialize(System.IO.Stream inputStream, out DataReceiveModel result)
          {
               result = new DataReceiveModel();
               result.Deserialize(inputStream);
          }
     }
}
