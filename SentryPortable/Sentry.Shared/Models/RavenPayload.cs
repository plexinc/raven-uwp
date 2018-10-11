﻿using Newtonsoft.Json;
using Sentry.Helpers;
using System;
using System.Collections.Generic;

namespace Sentry.Models
{
    public class RavenPayload
    {
        [JsonProperty("event_id")]
        public string EventID { get; set; }

        [JsonProperty("project")]
        public string Project { get; set; }

        [JsonProperty("release")]
        public string Release { get; set; }

        [JsonProperty("level", Required = Required.Always)]
        [JsonConverter(typeof(RavenLogLevelJsonConverter))]
        public RavenLogLevel? Level { get; set; }

        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime Timestamp { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("logger", NullValueHandling = NullValueHandling.Ignore)]
        public string Logger { get; set; }        

        [JsonProperty("culprit", NullValueHandling = NullValueHandling.Ignore)]
        public string Culprit { get; set; }

        [JsonProperty("stacktrace", NullValueHandling = NullValueHandling.Ignore)]
        public RavenStacktrace Stacktrace { get; set; }

        [JsonProperty("exception", NullValueHandling = NullValueHandling.Ignore)]
        public List<RavenException> Exceptions { get; set; }

        [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
        public RavenUser User { get; set; }

        [JsonProperty("tags", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, string> Tags { get; set; }

        [JsonProperty("extra", NullValueHandling = NullValueHandling.Ignore)]
        public IDictionary<string, object> Extra { get; set; }

        /// <summary>Gets or sets the fingerprint used for custom grouping</summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore, PropertyName = "fingerprint")]
        public string[] Fingerprint { get; set; }

        public override int GetHashCode()
        {
            return EventID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            RavenPayload payload = obj as RavenPayload;
            return payload != null && payload.EventID == EventID;
        }
    }
}
