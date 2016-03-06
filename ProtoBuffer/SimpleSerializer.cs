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
        /// <param name="overWriteExistingFile"></param>
        /// <returns>Saved filepath</returns>
        public async Task<string> SaveToFileAsync(
                                                  [NotNull] object item, 
                                                  [NotNull] string filePath,
                                                  [NotNull] bool overWriteExistingFile = false)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            if(!filePath.EndsWith(".bin"))
                throw new ArgumentException("filePath must end with .bin");

            if (overWriteExistingFile && File.Exists(filePath))
                throw new ArgumentException("file already exists");

            return await Task.Run(() => SaveToFile(item, filePath));
        }


        /// <summary>
        /// Transforms item to protobuf string
        /// </summary>
        /// <param name="item">Item to be serialized</param>
        /// <returns>String serialization of the item</returns>
        public async Task<byte[]> ToByteArrayAsync([NotNull] object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            return await Task.Run(() => ToByteArray(item));
        }


        /// <summary>
        /// Saves item to file
        /// </summary>
        /// <param name="item">Item to be saved</param>
        /// <param name="filePath">Destination filepath</param>
        /// <param name="overWriteExistingFile"></param>
        /// <returns>Saved filepath</returns>
        public string SaveToFile(
                                 [NotNull] object item, 
                                 [NotNull] string filePath,
                                 [NotNull] bool overWriteExistingFile = false)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            if (!filePath.EndsWith(".bin"))
                throw new ArgumentException("filePath must end with .bin");

            if(overWriteExistingFile && File.Exists(filePath))
                throw new ArgumentException("file already exists");

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
        public byte[] ToByteArray([NotNull] object item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            using (MemoryStream stream = new MemoryStream())
            {
                Serializer.Serialize(stream, item);
                stream.Position = 0;

                return stream.ToArray();
            }
        }
    }
}
