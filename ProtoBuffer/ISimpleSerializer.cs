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
                                     [NotNull] string filePath);

        Task<string> ToStringAsync([NotNull] object item);

        string SaveToFile(
                          [NotNull] object item,
                          [NotNull] string filePath);

        string ToString([NotNull] object item);
    }
}
