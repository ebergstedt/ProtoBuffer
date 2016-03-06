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
    public class SimpleDeserializer : ISimpleDeserializer
    {
        public async Task<T> FromFileAsync<T>([NotNull] string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            return await Task.Run(() => FromFile<T>(filePath));
        }

        public async Task<T> FromByteArrayAsync<T>([NotNull] byte[] value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return await Task.Run(() => FromByteArray<T>(value));
        }

        public T FromFile<T>([NotNull] string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }

        public T FromByteArray<T>([NotNull] byte[] value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            using (MemoryStream stream = new MemoryStream())
            {                
                stream.Write(value, 0, value.Length);
                stream.Position = 0;

                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}
