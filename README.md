# ProtoBuffer

A simple wrapper library for **[protobuf-net](https://github.com/mgravell/protobuf-net)** with async, gzip and
less boilerplate.

**ProtoBuffer** will remove some repetitive code declarations, like streams initializations and reading. It supports object to byte array or to file, with serialization and deserialization. It can also employ **gzip**. Just remember to keep track on which objects are gzipped or not when you deserialize them.

**[Performance report](https://github.com/sidshetye/SerializersCompare)** for ProtoBuf shows that it's one of the fastest serializers for C#. But what ProtoBuf is designed for is unprecedented speed of deserialization, with a very compact format. This makes it a prime candidate for your caching solution, such as using Redis together with ProtoBuf for extremely fast data transfer and deserialization. This is as of 2016 the solution deployed in production at Stack Overflow.

# [Nuget](https://www.nuget.org/packages/ProtoBuffer/)

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
    FileMode fileMode = FileMode.Create,
    bool gzipCompress = false);

Task<string> SaveToFileAsync(
    [NotNull] object item, 
    [NotNull] string filePath, 
    FileMode fileMode = FileMode.Create,
    bool gzipCompress = false);

byte[] ToByteArray(
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

```

# Gzip?
In ProtoBuffer you may chose to employ Gzip. Your data can be Gzipped before it's serialized into the ProtoBuf format. 

Gzip's purpose is primarily used to compress strings. That is why it's the preferred serialization format for webservers to serve html/javascript/css which are in a string format. If your data contains a lot of strings, then you may see a considerable size compression when using Gzip. Be aware though that Gzip can increase the size of your data should it not contain enough strings.

# Helpful links

**[Protobuf-net: the unofficial manual](http://www.codeproject.com/Articles/642677/Protobuf-net-the-unofficial-manual)**

**[Google ProtoBuf documentation](https://developers.google.com/protocol-buffers/docs/overview)**

**[ProtoBuf vs Json vs XML](http://stackoverflow.com/questions/14028293/google-protocol-buffers-vs-json-vs-xml)**


# Contributors

[ebergstedt](https://github.com/ebergstedt)
[eridleyj](https://github.com/eridleyj)

# Contributing

**Getting started with Git and GitHub**

* **[Setting up Git for Windows and connecting to GitHub](https://help.github.com/articles/set-up-git/)**
* **[Forking a GitHub repository](https://help.github.com/articles/fork-a-repo/)**
* **[The simple guide to GIT guide](http://rogerdudler.github.io/git-guide/)**
* **[Open an issue](https://github.com/ebergstedt/ProtoBuffer/issues)** if you encounter a bug or have a suggestion for improvements/features
Once you're familiar with Git and GitHub, clone the repository and start contributing.



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