using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PdfBot.Services.Amazon;
using PdfBot.Services.Configuration;
using PdfBot.Services.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace PdfBot.WebhookHandler
{
    public class Function
    {
        private readonly SNSClient _snsClient;
        private AppConfig _appConfig;
        private readonly IConfiguration _configuration;

        public Function()
        {
            _configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .Build();

            _appConfig = new AppConfig();

            _configuration.Bind(_appConfig);

            Console.WriteLine(JsonConvert.SerializeObject(_appConfig));

            _snsClient = new SNSClient(new BasicAWSCredentials(_appConfig.SNSAccessKey, _appConfig.SNSSecretKey),
                RegionEndpoint.GetBySystemName(_appConfig.SNSRegion),
                _appConfig.SNSTopic);
        }

        public async Task FunctionHandler(object input, ILambdaContext context)
        {
            context.Logger.LogLine($"Message received: {Environment.NewLine}{input}");

            try
            {
                await _snsClient.PublishAsync(new GenericMessage<object>(input));
                context.Logger.LogLine($"Message sent");
            }
            catch(Exception ex)
            {
                context.Logger.LogLine($"Error occured:{Environment.NewLine}{ex.Message}");
                throw;
            }
        }
    }
}
