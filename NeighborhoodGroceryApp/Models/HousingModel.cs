namespace Housing
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class HousingModel
    {
        private string communityArea;
        private long communityAreaNumber;
        private string propertType;
        private string propertName;
        private string address;
        private long zipCode;
        private string phoneNumber;
        private string managementCompany;
        private long units;
        private string bufferSize;
        private long licenseId;
        private long censusTract;
        private string storeName;
        private long ward;
        private double longtitude;
        private string censusBlock;
        private long accountNumber;
        private string squareFeet;

        [JsonProperty("Community_Area")]
        public string CommunityArea { get => communityArea; set => communityArea = value; }

        [JsonProperty("community_area_number")]
        public long CommunityAreaNumber { get => communityAreaNumber; set => communityAreaNumber = value; }

        [JsonProperty("property_type")]
        public string PropertType { get => propertType; set => propertType = value; }

        [JsonProperty("property_name")]
        public string PropertName { get => propertName; set => propertName = value; }

        [JsonProperty("address")]
        public string Address { get => address; set => address = value; }

        [JsonProperty("zip_code")]
        public long ZipCode { get => zipCode; set => zipCode = value; }

        [JsonProperty("Phone_Number")]
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

        [JsonProperty("management_company")]
        public string ManagementCompany { get => managementCompany; set => managementCompany = value; }

        [JsonProperty("Units")]
        public long Units { get => units; set => units = value; }

        [JsonProperty("Buffer_Size")]
        public string BufferSize { get => bufferSize; set => bufferSize = value; }

        [JsonProperty("License_ID")]
        public long LicenseId { get => licenseId; set => licenseId = value; }

        [JsonProperty("Census_Tract")]
        public long CensusTract { get => censusTract; set => censusTract = value; }

        [JsonProperty("Store_Name")]
        public string StoreName { get => storeName; set => storeName = value; }

        [JsonProperty("Ward")]
        public long Ward { get => ward; set => ward = value; }

        [JsonProperty("Longtitude")]
        public double Longtitude { get => longtitude; set => longtitude = value; }

        [JsonProperty("Census_Block")]
        public string CensusBlock { get => censusBlock; set => censusBlock = value; }

        [JsonProperty("Account_Number")]
        public long AccountNumber { get => accountNumber; set => accountNumber = value; }

        [JsonProperty("Square_feet")]
        public string SquareFeet { get => squareFeet; set => squareFeet = value; }
    }

    public partial class HousingModel
    {
        public static HousingModel[] FromJson(string json) => JsonConvert.DeserializeObject<HousingModel[]>(json, Housing.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this HousingModel[] self) => JsonConvert.SerializeObject(self, Housing.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
