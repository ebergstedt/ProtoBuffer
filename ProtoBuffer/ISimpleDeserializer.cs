using JetBrains.Annotations;

namespace ProtoBuffer
{
    public interface ISimpleDeserializer
    {
        T FromFile<T>(
                      [NotNull] string filePath, 
                      bool gzipDecompress = false);

        T FromByteArray<T>(
                           [NotNull] byte[] value,
                           bool gzipDecompress = false);
    }
}