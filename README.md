# ProtoBuffer

A simple wrapper library for **[protobuf-net](https://github.com/mgravell/protobuf-net)** with async functionality and less boilerplate.

# Usage

The test files are self-explanatory. Click below to go to the test files.

**[Protobuffer.SimpleSerializer](https://github.com/ebergstedt/ProtoBuffer/blob/master/ProtoBuffer.Test/SimpleSerializer_Test.cs)** helps with serialization.

**[Protobuffer.SimpleDeserializer](https://github.com/ebergstedt/ProtoBuffer/blob/master/ProtoBuffer.Test/SimpleDeserializer_Test.cs)** helps with deserialization.

# Methods

## Protobuffer.SimpleSerializer
```C#
Task<string> SaveToFileAsync(
                             [NotNull] object item, 
                             [NotNull] string filePath, 
                             [NotNull] bool overWriteExistingFile = false);

Task<byte[]> ToByteArrayAsync([NotNull] object item);

string SaveToFile(
                  [NotNull] object item, 
                  [NotNull] string filePath, 
                  [NotNull] bool overWriteExistingFile = false);

byte[] ToByteArray([NotNull] object item);
```

## Protobuffer.SimpleDeserializer
```C#
T FromFile<T>([NotNull] string filePath);

Task<T> FromFileAsync<T>([NotNull] string filePath);

T FromByteArray<T>([NotNull] byte[] value);

Task<T> FromByteArrayAsync<T>([NotNull] byte[] value);
```

