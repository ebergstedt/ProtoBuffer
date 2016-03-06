using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;

namespace ProtoBuffer.Test
{
    [TestFixture]
    public class SimpleDeserializer_Test
    {
        private readonly ISimpleSerializer _simpleSerializer;
        private readonly ISimpleDeserializer _simpleDeserializer;

        public SimpleDeserializer_Test() : this(new SimpleSerializer(), new SimpleDeserializer())
        {
            
        }

        public SimpleDeserializer_Test(ISimpleSerializer simpleSerializer, ISimpleDeserializer simpleDeserializer)
        {
            _simpleSerializer = simpleSerializer;
            _simpleDeserializer = simpleDeserializer;
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
        public void Given_an_object_Then_protobuf_serialize_and_deseserialize()
        {
            var serialize = _simpleSerializer.ToByteArray(GetObjectWithProtobufContract());

            Person deserialize = _simpleDeserializer.FromByteArray<Person>(serialize);

            Assert.NotNull(deserialize);
        }

        [Test]
        public void Given_an_object_Then_get_its_protobuf_serialization_in_file_Then_deserialize_it()
        {
            string path = "ob.bin";

            _simpleSerializer.SaveToFile(GetObjectWithProtobufContract(), path);

            Person person = _simpleDeserializer.FromFile<Person>(path);

            Assert.NotNull(person);
        }

        [Test]
        public async Task Given_an_object_Then_protobuf_serialize_deseserialize_async()
        {
            var serialize = await _simpleSerializer.ToByteArrayAsync(GetObjectWithProtobufContract());

            Person deserialize = await _simpleDeserializer.FromByteArrayAsync<Person>(serialize);

            Assert.NotNull(deserialize);
        }

        [Test]
        public async Task Given_an_object_Then_get_its_protobuf_serialization_file_Then_deserialize_it_async()
        {
            string path = "ob.bin";

            await _simpleSerializer.SaveToFileAsync(GetObjectWithProtobufContract(), path);

            Person person = await _simpleDeserializer.FromFileAsync<Person>(path);

            Assert.NotNull(person);
        }
    }
}
