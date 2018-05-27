using System;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using PdfBot.Services.Models;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace PdfBot.MessageProcessor
{
    public class Function
    {
        public async Task FunctionHandler(GenericMessage<object> input, ILambdaContext context)
        {
            Console.WriteLine($"Input: {input}");
        }
    }
}
