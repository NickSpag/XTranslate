using System;
using System.Net;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace XTranslate.iOS
{
    public class AzureAnalyzeImageResponse
    {
        [JsonProperty("recognitionResult")]
        public RecognitionResult RecognitionResult { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class RecognitionResult
    {
        [JsonProperty("lines")]
        public Line[] Lines { get; set; }
    }

    public partial class AzureOCRResponse
    {
        [JsonProperty("orientation")]
        public string Orientation { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("regions")]
        public Region[] Regions { get; set; }

        [JsonProperty("textAngle")]
        public double TextAngle { get; set; }
    }

    public partial class Region
    {
        [JsonProperty("boundingBox")]
        public long[] BoundingBox { get; set; }

        [JsonProperty("lines")]
        public Line[] Lines { get; set; }
    }

    public partial class Line
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("boundingBox")]
        public long[] BoundingBox { get; set; }

        [JsonProperty("words")]
        public Word[] Words { get; set; }
    }

    public partial class Word
    {
        [JsonProperty("boundingBox")]
        public long[] BoundingBox { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }

    public partial class Empty
    {
        public static Empty FromJson(string json) => JsonConvert.DeserializeObject<Empty>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Empty self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
