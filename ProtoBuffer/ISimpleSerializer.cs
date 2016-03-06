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
        string SaveToFile(
                          [NotNull] object item,
                          [NotNull] string filePath,
                          bool overWriteExistingFile = false,
                          bool gzipCompress = false);

        Task<string> SaveToFileAsync(
                                     [NotNull] object item, 
                                     [NotNull] string filePath, 
                                     bool overWriteExistingFile = false, 
                                     bool gzipCompress = false);

        byte[] ToByteArray(
                           [NotNull] object item,
                           bool gzipCompress = false);

        Task<byte[]> ToByteArrayAsync(
                                      [NotNull] object item,
                                      bool gzipCompress = false);        
    }
}
