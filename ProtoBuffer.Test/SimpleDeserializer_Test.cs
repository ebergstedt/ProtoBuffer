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

        [TestCase(false)]
        [TestCase(true)]
        public void Given_an_object_Then_protobuf_serialize_and_deseserialize(bool useGzip)
        {
            var serialize = _simpleSerializer.ToByteArray(GetObjectWithProtobufContract(), gzipCompress: useGzip);

            Person deserialize = _simpleDeserializer.FromByteArray<Person>(serialize, gzipDecompress: useGzip);

            Assert.NotNull(deserialize);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void Given_an_object_Then_get_its_protobuf_serialization_in_file_Then_deserialize_it(bool useGzip)
        {
            string path = "ob1.bin";

            _simpleSerializer.SaveToFile(GetObjectWithProtobufContract(), path, gzipCompress: useGzip);

            Person person = _simpleDeserializer.FromFile<Person>(path, gzipDecompress: useGzip);

            Assert.NotNull(person);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task Given_an_object_Then_protobuf_serialize_deseserialize_async(bool useGzip)
        {
            var serialize = await _simpleSerializer.ToByteArrayAsync(GetObjectWithProtobufContract(), gzipCompress: useGzip);

            Person deserialize = await _simpleDeserializer.FromByteArrayAsync<Person>(serialize, gzipDecompress: useGzip);

            Assert.NotNull(deserialize);
        }

        [TestCase(false)]
        [TestCase(true)]
        public async Task Given_an_object_Then_get_its_protobuf_serialization_file_Then_deserialize_it_async(bool useGzip)
        {
            string path = "ob2.bin";

            await _simpleSerializer.SaveToFileAsync(GetObjectWithProtobufContract(), path, gzipCompress: useGzip);

            Person person = await _simpleDeserializer.FromFileAsync<Person>(path, gzipDecompress: useGzip);

            Assert.NotNull(person);
        }
    }
}
