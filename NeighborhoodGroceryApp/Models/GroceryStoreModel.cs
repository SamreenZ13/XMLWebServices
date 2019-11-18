namespace GroceryStore
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class GroceryStoreModel
    {
        private long computedRegion43Wa7Qmu;
        private long zipCode;
        private BufferSize bufferSize;
        private long? licenseId;
        private Location location;
        private string censusTract;
        private string address;
        private string yCoordinate;
        private string storeName;
        private string communityAreaName;
        private long computedRegionRpca8Um6;
        private string latitude;
        private long computedRegionAwafS7Ux;
        private long communityArea;
        private string xCoordinate;
        private long ward;
        private string longitude;
        private long computedRegionBdys3D7I;
        private long computedRegion6MkvF3Dw;
        private string censusBlock;
        private long? accountNumber;
        private long computedRegionVrxfVc4K;
        private long? squareFeet;

        [JsonProperty(":@computed_region_43wa_7qmu")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ComputedRegion43Wa7Qmu { get => computedRegion43Wa7Qmu; set => computedRegion43Wa7Qmu = value; }

        [JsonProperty("zip_code")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ZipCode { get => zipCode; set => zipCode = value; }

        [JsonProperty("buffer_size")]
        public BufferSize BufferSize { get => bufferSize; set => bufferSize = value; }

        [JsonProperty("license_id", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? LicenseId { get => licenseId; set => licenseId = value; }

        [JsonProperty("location")]
        public Location Location { get => location; set => location = value; }

        [JsonProperty("census_tract")]
        public string CensusTract { get => censusTract; set => censusTract = value; }

        [JsonProperty("address")]
        public string Address { get => address; set => address = value; }

        [JsonProperty("y_coordinate")]
        public string YCoordinate { get => yCoordinate; set => yCoordinate = value; }

        [JsonProperty("store_name")]
        public string StoreName { get => storeName; set => storeName = value; }

        [JsonProperty("community_area_name")]
        public string CommunityAreaName { get => communityAreaName; set => communityAreaName = value; }

        [JsonProperty(":@computed_region_rpca_8um6")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ComputedRegionRpca8Um6 { get => computedRegionRpca8Um6; set => computedRegionRpca8Um6 = value; }

        [JsonProperty("latitude")]
        public string Latitude { get => latitude; set => latitude = value; }

        [JsonProperty(":@computed_region_awaf_s7ux")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ComputedRegionAwafS7Ux { get => computedRegionAwafS7Ux; set => computedRegionAwafS7Ux = value; }

        [JsonProperty("community_area")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CommunityArea { get => communityArea; set => communityArea = value; }

        [JsonProperty("x_coordinate")]
        public string XCoordinate { get => xCoordinate; set => xCoordinate = value; }

        [JsonProperty("ward")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long Ward { get => ward; set => ward = value; }

        [JsonProperty("longitude")]
        public string Longitude { get => longitude; set => longitude = value; }

        [JsonProperty(":@computed_region_bdys_3d7i")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ComputedRegionBdys3D7I { get => computedRegionBdys3D7I; set => computedRegionBdys3D7I = value; }

        [JsonProperty(":@computed_region_6mkv_f3dw")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ComputedRegion6MkvF3Dw { get => computedRegion6MkvF3Dw; set => computedRegion6MkvF3Dw = value; }

        [JsonProperty("census_block", NullValueHandling = NullValueHandling.Ignore)]
        public string CensusBlock { get => censusBlock; set => censusBlock = value; }

        [JsonProperty("account_number", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? AccountNumber { get => accountNumber; set => accountNumber = value; }

        [JsonProperty(":@computed_region_vrxf_vc4k")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ComputedRegionVrxfVc4K { get => computedRegionVrxfVc4K; set => computedRegionVrxfVc4K = value; }

        [JsonProperty("square_feet", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? SquareFeet { get => squareFeet; set => squareFeet = value; }
    }

    public partial class Location
    {
        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("needs_recoding")]
        public bool NeedsRecoding { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }
    }

    public enum BufferSize { A, B };

    public partial class GroceryStoreModel
    {
        public static GroceryStoreModel[] FromJson(string json) => JsonConvert.DeserializeObject<GroceryStoreModel[]>(json, GroceryStore.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this GroceryStoreModel[] self) => JsonConvert.SerializeObject(self, GroceryStore.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                BufferSizeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }

    internal class BufferSizeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(BufferSize) || t == typeof(BufferSize?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "A":
                    return BufferSize.A;
                case "B":
                    return BufferSize.B;
            }
            throw new Exception("Cannot unmarshal type BufferSize");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (BufferSize)untypedValue;
            switch (value)
            {
                case BufferSize.A:
                    serializer.Serialize(writer, "A");
                    return;
                case BufferSize.B:
                    serializer.Serialize(writer, "B");
                    return;
            }
            throw new Exception("Cannot marshal type BufferSize");
        }

        public static readonly BufferSizeConverter Singleton = new BufferSizeConverter();
    }
}
