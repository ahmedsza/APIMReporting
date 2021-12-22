using System;
using System.Collections.Generic;
using System.Text;

namespace APIMReporting
{
    public class Rootobject
    {
        public Value[] value { get; set; }
        public int count { get; set; }
    }

    public class Value
    {
        public string apiId { get; set; }
        public string operationId { get; set; }
        public string productId { get; set; }
        public string userId { get; set; }
        public string method { get; set; }
        public string url { get; set; }
        public string ipAddress { get; set; }
        public int? backendResponseCode { get; set; }
        public int responseCode { get; set; }
        public int responseSize { get; set; }
        public DateTime timestamp { get; set; }
        public string cache { get; set; }
        public float apiTime { get; set; }
        public float serviceTime { get; set; }
        public string apiRegion { get; set; }
        public string subscriptionId { get; set; }
        public string requestId { get; set; }
        public int requestSize { get; set; }
    }

  
}
