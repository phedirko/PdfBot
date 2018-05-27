using System;
using System.Collections.Generic;
using System.Text;

namespace PdfBot.Services.Configuration
{
    public class AppConfig
    {

        public string SNSTopic { get; set; }

        public string SNSRegion { get; set; }

        public string SNSAccessKey { get; set; }
        public string SNSSecretKey { get; set; }

        public static IReadOnlyDictionary<string, string> DefaultConfigurationStrings =
            new Dictionary<string, string>
            {
                ["SNSTopic"] = "pdfbot_webhooks",
                ["SNSRegion"] = "EU-Central-1",
                ["SNSAccesKey"] = "YOUR_AWS_ACCES_KEY",
                ["SNSSecretKey"] = "YOUR_AWS_SECRET_KEY"
            };
    }
}
