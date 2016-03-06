# ProtoBuffer

A simple wrapper library for **[protobuf-net](https://github.com/mgravell/protobuf-net)** with async functionality, gzip and
less boilerplate.

**ProtoBuffer** will remove some repetitive code declarations, like streams initializations and reading. It supports object to byte array or to file, with serialization and deserialization. It can also employ **gzip**. Just remember to keep track on which objects are gzipped or not when you deserialize them.

# Usage

The test files are self-explanatory. Click below to go to the test files.

**[Protobuffer.SimpleSerializer](https://github.com/ebergstedt/ProtoBuffer/blob/master/ProtoBuffer.Test/SimpleSerializer_Test.cs)** helps with serialization.

**[Protobuffer.SimpleDeserializer](https://github.com/ebergstedt/ProtoBuffer/blob/master/ProtoBuffer.Test/SimpleDeserializer_Test.cs)** helps with deserialization.

Here is a sample:

```C#
[Test]
public void Given_an_object_Then_protobuf_serialize_and_deseserialize()
{
    var serialize = _simpleSerializer.ToByteArray(GetPerson());

    Person deserialize = _simpleDeserializer.FromByteArray<Person>(serialize);

    Assert.NotNull(deserialize); // true!
}
```

# Methods

## Protobuffer.SimpleSerializer
```C#
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
```

## Protobuffer.SimpleDeserializer
```C#
T FromFile<T>(
			  [NotNull] string filePath, 
			  bool gzipDecompress = false);

Task<T> FromFileAsync<T>(
						 [NotNull] string filePath,
						 bool gzipDecompress = false);

T FromByteArray<T>(
				   [NotNull] byte[] value,
				   bool gzipDecompress = false);

Task<T> FromByteArrayAsync<T>(
							  [NotNull] byte[] value,
							  bool gzipDecompress = false);
```

