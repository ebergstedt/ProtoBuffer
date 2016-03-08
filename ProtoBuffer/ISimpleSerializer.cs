using JetBrains.Annotations;

namespace ProtoBuffer
{
    public interface ISimpleSerializer
    {
        string SaveToFile(
                          [NotNull] object item,
                          [NotNull] string filePath,
                          bool overWriteExistingFile = false,
                          bool gzipCompress = false);

        byte[] ToByteArray(
                           [NotNull] object item,
                           bool gzipCompress = false);      
    }
}
