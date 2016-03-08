using System;
using System.IO;
using System.Security.Cryptography;
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


        [TestCase(false)]
        [TestCase(true)]
        public void Given_an_object_Then_get_its_protobuf_serialize(bool useGzip)
        {
            byte[] serialized = _simpleSerializer.ToByteArray(GetObjectWithProtobufContract(), gzipCompress: useGzip);            

            Assert.NotNull(serialized);
        }


        [TestCase(false)]
        [TestCase(true)]
        public void Given_an_object_Then_get_its_protobuf_serialization_in_file(bool useGzip)
        {
            string path = "ob5.bin";

            _simpleSerializer.SaveToFile(GetObjectWithProtobufContract(), path, gzipCompress: useGzip);

            var readAllText = File.ReadAllText(path);

            Assert.NotNull(readAllText);
        }
    }
}
