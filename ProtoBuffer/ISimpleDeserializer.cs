using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ProtoBuffer
{
    public interface ISimpleDeserializer
    {
        T FromFile<T>(
                      [NotNull] string filePath, 
                      [NotNull] bool gzipDecompress = false);

        Task<T> FromFileAsync<T>(
                                 [NotNull] string filePath,
                                 [NotNull] bool gzipDecompress = false);

        T FromByteArray<T>(
                           [NotNull] byte[] value,
                           [NotNull] bool gzipDecompress = false);

        Task<T> FromByteArrayAsync<T>(
                                      [NotNull] byte[] value,
                                      [NotNull] bool gzipDecompress = false);
    }
}