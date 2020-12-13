using Amazon;

namespace Julius2GrowTest.Infrastructure.S3
{
    public class S3Options
    {
        public const string S3 = "S3";

        public static readonly RegionEndpoint BucketRegion = RegionEndpoint.USEast2;

        public string BucketName { get; set; }
        public string AccessKeyId { get; set; }
        public string SecretKey { get; set; }
        public string BucketUri { get; set; }
    }
}
