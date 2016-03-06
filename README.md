# Index

1. [ProtoBuffer](#ProtoBuffer)
2. [Nuget](#Nuget)
3. [Usage](#Usage)
4. [Methods](#Methods)
5. [License](#License)

# ProtoBuffer

A simple wrapper library for **[protobuf-net](https://github.com/mgravell/protobuf-net)** with async, gzip and
less boilerplate.

**ProtoBuffer** will remove some repetitive code declarations, like streams initializations and reading. It supports object to byte array or to file, with serialization and deserialization. It can also employ **gzip**. Just remember to keep track on which objects are gzipped or not when you deserialize them.

# Nuget

    PM> Install-Package ProtoBuffer

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

# License

The MIT License (MIT)

Copyright (c) 2016 Erik Bergstedt

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.