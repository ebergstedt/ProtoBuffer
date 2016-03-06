using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ProtoBuffer
{
    public interface ISimpleDeserializer
    {
        T FromFile<T>([NotNull] string filePath);

        Task<T> FromFileAsync<T>([NotNull] string filePath);

        T FromByteArray<T>([NotNull] byte[] value);

        Task<T> FromByteArrayAsync<T>([NotNull] byte[] value);
    }
}