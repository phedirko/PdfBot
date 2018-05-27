using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Newtonsoft.Json;
using PdfBot.Services.Configuration;

namespace PdfBot.Services.Amazon
{
    public class SNSClient
    {
        private readonly AmazonSimpleNotificationServiceClient _client;
        private readonly string _topic;

        public SNSClient(AWSCredentials credentials, RegionEndpoint region, string topic)
        {
            _client = new AmazonSimpleNotificationServiceClient(credentials, region);
            _topic = topic;
        }

        public async Task<PublishResponse> PublishAsync<T>(T message)
        {
            var json = JsonConvert.SerializeObject(message, SerializingConfiguration.TypeHandling);

            return await _client.PublishAsync(_topic, json);
        }
    }
}
