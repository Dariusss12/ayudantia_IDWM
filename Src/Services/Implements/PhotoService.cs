using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ayudantia_IDWM.Src.Helpers;
using ayudantia_IDWM.Src.Services.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Options;

namespace ayudantia_IDWM.Src.Services.Implements
{
    public class PhotoService : IPhotoService
    {
        private readonly Cloudinary _cloudinary;

        public PhotoService(IOptions<CloudinarySettings> config)
        {
            var account = new Account
            (
                config.Value.CloudName,
                config.Value.ApiKey,
                config.Value.ApiSecret
            );

            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> AddPhoto(IFormFile photo)
        {
            var uploadResult = new ImageUploadResult();
            if(photo.Length > 0)
            {
                using var stream = photo.OpenReadStream();
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(photo.FileName,stream),
                    Transformation = new Transformation()
                       .Height(500)
                       .Width(500)
                       .Crop("fill")
                       .Gravity("face"),
                    Folder = "Ayudantia"
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);
            }

            return uploadResult;
        }

        public async Task<DeletionResult> DeletePhoto(string publicId)
        {
            var deleteParams = new DeletionParams(publicId);

            return await _cloudinary.DestroyAsync(deleteParams);
        }
    }
}