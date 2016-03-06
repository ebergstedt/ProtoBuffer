using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ProtoBuf;

namespace ProtoBuffer
{
    public class SimpleSerializer : ISimpleSerializer
    {
        /// <summary>
        /// Saves item to file
        /// </summary>
        /// <param name="item">Item to be saved</param>
        /// <param name="filePath">Destination filepath</param>
        /// <returns>Saved filepath</returns>
        public async Task<string> SaveToFileAsync(
                                                  [NotNull] object item, 
                                                  [NotNull] string filePath)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            if(!filePath.EndsWith(".bin"))
                throw new ArgumentException("filePath must end with .bin");            

            return await Task.Run(() => SaveToFile(item, filePath));
        }


        /// <summary>
        /// Transforms item to protobuf string
        /// </summary>
        /// <param name="item">Item to be serialized</param>
        /// <returns>String serialization of the item</returns>
        public async Task<string> ToStringAsync([NotNull] object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.SerializeWithLengthPrefix(
                                                     stream,
                                                     item,
                                                     PrefixStyle.Base128);

                await stream.WriteAsync(
                             stream.GetBuffer(),
                             0,
                             (int)stream.Position);

                stream.Position = 0;
                var sr = new StreamReader(stream);

                return await sr.ReadToEndAsync();
            }
        }


        /// <summary>
        /// Saves item to file
        /// </summary>
        /// <param name="item">Item to be saved</param>
        /// <param name="filePath">Destination filepath</param>
        /// <returns>Saved filepath</returns>
        public string SaveToFile(
                                 [NotNull] object item, 
                                 [NotNull] string filePath)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            if (!filePath.EndsWith(".bin"))
                throw new ArgumentException("filePath must end with .bin");

            using (var file = File.Create(filePath))
            {
                ProtoBuf.Serializer.Serialize(file, item);
            }

            return filePath;
        }


        /// <summary>
        /// Transforms item to protobuf string
        /// </summary>
        /// <param name="item">Item to be serialized</param>
        /// <returns>String serialization of the item</returns>
        public string ToString([NotNull] object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.SerializeWithLengthPrefix(
                                                     stream, 
                                                     item, 
                                                     PrefixStyle.Base128);

                stream.Write(
                             stream.GetBuffer(), 
                             0, 
                             (int)stream.Position);

                stream.Position = 0;
                var sr = new StreamReader(stream);
                return sr.ReadToEnd();
            }
        }
    }
}
