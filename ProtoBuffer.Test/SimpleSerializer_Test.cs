using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;
using NUnit.Framework;
using ProtoBuf;
using System.Xml;

namespace ProtoBuffer.Test
{
    [TestFixture]
    public class SimpleSerializer_Test
    {
        private readonly ISimpleSerializer _simpleSerializer;

        public SimpleSerializer_Test() : this(new SimpleSerializer())
        {
            
        }

        public SimpleSerializer_Test(ISimpleSerializer simpleSerializer)
        {
            _simpleSerializer = simpleSerializer;
        }

        private Person GetObjectWithProtobufContract()
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
        public void Given_an_object_Then_get_its_protobuf_serialize()
        {
            byte[] serialized = _simpleSerializer.ToByteArray(GetObjectWithProtobufContract());

            Assert.NotNull(serialized);
        }


        [Test]
        public void Given_an_object_Then_get_its_protobuf_serialization_in_file()
        {
            string path = "ob.bin";

            _simpleSerializer.SaveToFile(GetObjectWithProtobufContract(), path);

            var readAllText = File.ReadAllText(path);

            Assert.NotNull(readAllText);
        }


        [Test]
        public async Task Given_object_Then_get_its_protobuf_serialize_async()
        {
            byte[] serialized = await _simpleSerializer.ToByteArrayAsync(GetObjectWithProtobufContract());

            Assert.NotNull(serialized);
        }

        [Test]
        public async Task Given_an_object_Then_get_its_protobuf_serialization_in_file_async()
        {
            string path = "ob.bin";

            await _simpleSerializer.SaveToFileAsync(GetObjectWithProtobufContract(), path);

            var readAllText = File.ReadAllText(path);

            Assert.NotNull(readAllText);
        }
    }
}
