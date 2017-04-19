using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProtoBuffer
{
    public interface ISimpleSerializer
    {
        string SaveToFile(
            object item,
            string filePath,
            FileMode fileMode = FileMode.Create,
            bool gzipCompress = false);

        Task<string> SaveToFileAsync(
            object item, 
            string filePath,
            FileMode fileMode = FileMode.Create, 
            bool gzipCompress = false);

        byte[] ToByteArray(
            object item,
            bool gzipCompress = false);

        string ToStringValue(
            object item,
            bool gzipCompress = false);
    }
}
