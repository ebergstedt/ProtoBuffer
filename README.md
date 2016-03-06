# ProtoBuffer

A simple wrapper library for **[protobuf-net](https://github.com/mgravell/protobuf-net)** with async functionality and less boilerplate.

# Usage

The test files are self-explanatory. Click below to go to the test files.

**[Protobuffer.SimpleSerializer](https://github.com/ebergstedt/ProtoBuffer/blob/master/ProtoBuffer.Test/SimpleSerializer_Test.cs)** helps with serialization.

**[Protobuffer.SimpleDeserializer](https://github.com/ebergstedt/ProtoBuffer/blob/master/ProtoBuffer.Test/SimpleDeserializer_Test.cs)** helps with deserialization.

Here is a sample:

```C#
private Person GetPerson()
{
    return new Person
    {
        Id = 12345,
        Name = "Fred",
        Address = new Address
        {
            Line1 = "Flat 1",
            Line2 = "The Meadows"
        }
    };
}

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

