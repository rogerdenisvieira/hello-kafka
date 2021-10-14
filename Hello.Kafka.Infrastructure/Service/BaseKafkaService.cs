using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace Hello.Kafka.Infrastructure.Service
{
    public class BaseKafkaService
    {
        private IConfiguration _configuration;
        private IProducer<Null, string> _producer;

        public BaseKafkaService(IConfiguration configuration)
        {
            this._configuration = configuration;

            var bootstrapServer = this._configuration.GetSection("Kafka:bootstrapServer").Value;

            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = bootstrapServer
            };

            this._producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        }

        public bool ProduceAsync(string topic, object content)
        {

            Message<Null, string> message = new Message<Null, string>()
            {
                Value = Json.Encode(content)
            };

            try
            {
               var result = this._producer.ProduceAsync(topic, message);

                return result != null;

            }
            catch (Exception)
            {
                return false;
            }


        }
    }
}
