using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Dal
{
    public class AppConfig
    {


        [JsonProperty("ConnectionString")]
        public string ConnectionString { get; set; }
    }
}
