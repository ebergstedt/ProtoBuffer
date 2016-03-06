using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ProtoBuffer
{
    public interface ISimpleSerializer
    {
        Task<string> SaveToFileAsync(
                                     [NotNull] object item, 
                                     [NotNull] string filePath, 
                                     [NotNull] bool overWriteExistingFile = false, 
                                     [NotNull] bool gzipCompress = false);

        Task<byte[]> ToByteArrayAsync(
                                      [NotNull] object item,
                                      [NotNull] bool gzipCompress = false);

        string SaveToFile(
                          [NotNull] object item, 
                          [NotNull] string filePath, 
                          [NotNull] bool overWriteExistingFile = false, 
                          [NotNull] bool gzipCompress = false);

        byte[] ToByteArray(
                           [NotNull] object item,
                           [NotNull] bool gzipCompress = false);
    }
}
