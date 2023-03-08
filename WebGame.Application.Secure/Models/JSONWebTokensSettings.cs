using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGame.Security.Models
{
    public class JSONWebTokensSettings
    {
        public const string CONFIG_NAME = nameof(JSONWebTokensSettings);

        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public double DurationInMinutes { get; set; }
    }
}
