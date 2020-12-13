using System;
using System.IO;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Julius2GrowTest.Application.Services;
using Microsoft.Extensions.Options;
using OneOf;
using OneOf.Types;

namespace Julius2GrowTest.Infrastructure.S3.Services
{
    public class ImageService : IImageService
    {
        private readonly IAmazonS3 _s3Client;
        private readonly IOptions<S3Options> _options;

        public ImageService(IOptions<S3Options> options)
        {
            _options = options;
            _s3Client = new AmazonS3Client(_options.Value.AccessKeyId,
                _options.Value.SecretKey,
                S3Options.BucketRegion);
        }

        public async Task<OneOf<Success, Error<string>>> UploadAsync(string name, Stream image)
        {
            try
            {
                var fileTransferUtility = new TransferUtility(_s3Client);

                await fileTransferUtility.UploadAsync(image, _options.Value.BucketName, name);

                return new Success();
            }
            catch (AmazonS3Exception e)
            {
                return new Error<string>($"Error encountered on server. Message:'{e.Message}' when writing an object");
            }
            catch (Exception e)
            {
                return new Error<string>($"Unknown encountered on server. Message:'{e.Message}' when writing an object");
            }
        }

        public async Task<OneOf<Success, Error<string>>> RemoveAsync(string name)
        {
            try
            {
                var request = new DeleteObjectRequest
                {
                    BucketName = _options.Value.BucketName,
                    Key = name
                };

                await _s3Client.DeleteObjectAsync(request);

                return new Success();
            }
            catch (AmazonS3Exception e)
            {
                return new Error<string>($"Error encountered on server. Message:'{e.Message}' when deleting an object");
            }
            catch (Exception e)
            {
                return new Error<string>($"Unknown encountered on server. Message:'{e.Message}' when deleting an object");
            }
        }

        public string CreateUri(string name) => $"{_options.Value.BucketUri}{name}";
    }
}
