using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ProtoBuf;

namespace ProtoBuffer
{
    public class SimpleDeserializer : ISimpleDeserializer
    {
        public async Task<T> FromFileAsync<T>(
                                              [NotNull] string filePath,
                                              [NotNull] bool gzipDecompress = false)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            return await Task.Run(() => FromFile<T>(filePath, gzipDecompress));
        }

        public async Task<T> FromByteArrayAsync<T>(
                                                   [NotNull] byte[] value,
                                                   [NotNull] bool gzipDecompress = false)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            return await Task.Run(() => FromByteArray<T>(value, gzipDecompress));
        }

        public T FromFile<T>(
                             [NotNull] string filePath,
                             [NotNull] bool gzipDecompress = false)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            var readAllBytes = File.ReadAllBytes(filePath);

            return FromByteArray<T>(readAllBytes, gzipDecompress);
        }

        public T FromByteArray<T>(
                                  [NotNull] byte[] value,
                                  [NotNull] bool gzipDecompress = false)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            using (var ms = new MemoryStream(value))
            {
                if (gzipDecompress)
                {
                    using (var gzip = new GZipStream(ms, CompressionMode.Decompress, true))
                    {
                        return Serializer.Deserialize<T>(gzip);
                    }
                }

                return Serializer.Deserialize<T>(ms);
            }
        }
    }
}