using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

using ProtoBuf;

namespace ProtoBuffer
{
    public class SimpleSerializer : ISimpleSerializer
    {
        private const int GZIP_BUFFER_SIZE = 64*1024;
        
        /// <summary>
        ///     Saves item to file
        /// </summary>
        /// <param name="item">Item to be saved</param>
        /// <param name="filePath">Destination filepath</param>
        /// <param name="overWriteExistingFile"></param>
        /// <param name="gzipCompress">Use gzip compression</param>
        /// <returns>Saved filepath</returns>
        public string SaveToFile(
            object item,
            string filePath,
            FileMode fileMode = FileMode.Create,
            bool gzipCompress = false)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            if (!filePath.EndsWith(".bin"))
                throw new ArgumentException("filePath must end with .bin");

            var byteArray = ToByteArray(item, gzipCompress);

            File.WriteAllBytes(filePath, byteArray);

            return filePath;
        }

        /// <summary>
        ///     Saves item to file
        /// </summary>
        /// <param name="item">Item to be saved</param>
        /// <param name="filePath">Destination filepath</param>
        /// <param name="overWriteExistingFile"></param>
        /// <param name="gzipCompress">Use gzip compression</param>
        /// <returns>Saved filepath</returns>
        public async Task<string> SaveToFileAsync(
            object item,
            string filePath,
            FileMode fileMode = FileMode.Create,
            bool gzipCompress = false)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            if (!filePath.EndsWith(".bin"))
                throw new ArgumentException("filePath must end with .bin");

            var byteArray = ToByteArray(item, gzipCompress);

            using (var fs = new FileStream(filePath, fileMode))
            {
                await fs.WriteAsync(byteArray, 0, byteArray.Length);
            }

            return filePath;
        }

        /// <summary>
        ///     Transforms item to protobuf byte array
        /// </summary>
        /// <param name="item">Item to be serialized</param>
        /// <param name="gzipCompress">Use gzip compression</param>
        /// <returns>String serialization of the item</returns>
        public byte[] ToByteArray(
            object item,
            bool gzipCompress = false)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));

            using (var ms = new MemoryStream())
            {
                if (gzipCompress)
                {
                    using (var gzip = new GZipStream(ms, CompressionMode.Compress, true))
                    using (var bs = new BufferedStream(gzip, GZIP_BUFFER_SIZE))
                    {
                        Serializer.Serialize(bs, item);
                    } //flush gzip                                     
                }
                else
                {
                    Serializer.Serialize(ms, item);
                }

                return ms.ToArray();
            }
        }

        public string ToStringValue(
            object item,
            bool gzipCompress = false)
        {
            return Convert.ToBase64String(
                ToByteArray(item, 
                gzipCompress));
        }
    }
}