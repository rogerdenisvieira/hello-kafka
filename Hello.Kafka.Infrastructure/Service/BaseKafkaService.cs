using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace Hello.Kafka.Infrastructure.Service
{
    public class BaseKafkaService
    {
        private IConfiguration _configuration;
        private IProducer<Null, string> _producer;

        public BaseKafkaService(IConfiguration configuration)
        {
            this._configuration = configuration;

            var bootstrapServer = this._configuration.GetSection("Kafka:bootstrapServers").Value;

            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = bootstrapServer
            };

            this._producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        }

        public bool Produce(string topic, object content)
        {

            Message<Null, string> message = new()
            {
                //Value = Json.Encode(content)
                Value = JsonSerializer.Serialize(content)
                
            };

            try
            {
               _producer.Produce(topic, message);

                return true;

            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
