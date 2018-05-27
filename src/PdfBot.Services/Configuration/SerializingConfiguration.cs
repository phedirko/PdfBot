using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PdfBot.Services.Configuration
{
    public static class SerializingConfiguration
    {
        public static JsonSerializerSettings TypeHandling
            => new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };
    }
}
